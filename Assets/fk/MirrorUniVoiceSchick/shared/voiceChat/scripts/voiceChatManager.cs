using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Adrenak.UniVoice;
using System;
using UnityEngine.Events;
using Adrenak.UniVoice.InbuiltImplementations;
using System.Linq;

public class voiceChatManager : MonoBehaviour
{
    [Header("Menu")]
    public GameObject menuGO;
    public InputField inputField;
    public Button hostButton;
    public Button joinButton;
    public Button exitButton;
    public Text menuMessage;

    [Header("AudioChannelMenu")]
    public GameObject aCMenuGO;
    public Transform peerViewContainer;
    public PeerView peerViewTemplate;
    public Text chatroomMessage;
    public Toggle muteSelfToggle;
    public Toggle muteOthersToggle;

    ChatroomAgent agent;
    Dictionary<short, PeerView> peerViews = new Dictionary<short, PeerView>();

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        InitializeInput();
        InitializeAgent();

        // Initialize Menu View and Callbacks for toggle buttons
        menuGO.SetActive(true);
        aCMenuGO.SetActive(false);

        muteSelfToggle.SetIsOnWithoutNotify(!agent.MuteSelf);
        muteSelfToggle.onValueChanged.AddListener(value => agent.MuteSelf = !value);

        muteOthersToggle.SetIsOnWithoutNotify(!agent.MuteOthers);
        muteOthersToggle.onValueChanged.AddListener(value => agent.MuteOthers = !value);
    }
    private void InitializeInput()
    {
        hostButton.onClick.AddListener(HostVoiceChat);
        joinButton.onClick.AddListener(JoinVoiceChat);
        exitButton.onClick.AddListener(ExitVoiceChat);
    }

    private void ExitVoiceChat()
    {
        Debug.Log(agent.CurrentMode);
        if (agent.CurrentMode == ChatroomAgentMode.Host)
            agent.Network.CloseChatroom();
        else if (agent.CurrentMode == ChatroomAgentMode.Guest)
            agent.Network.LeaveChatroom();
    }

    private void JoinVoiceChat()
    {
        var channelName = inputField.text;
        agent.Network.JoinChatroom(channelName);
    }

    private void HostVoiceChat()
    {
        var channelName = inputField.text;
        agent.Network.HostChatroom(channelName);
    }

    private void InitializeAgent()
    {
        // 167.71.17.13:11000 is a test server hosted by the creator of UniVoice.
        // This server should NOT be used in any serious application or production as it
        // is neither secure nor gaurunteed to be online which will cause your
        // apps to fail. 
        // 
        // Host your own signalling server on something like DigitalOcean, AWS etc.
        // The test server is node based and its code is here: github.com/adrenak/airsignal
        agent = new InbuiltChatroomAgentFactory("ws://167.71.17.13:11000").Create();

        // HOSTING
        agent.Network.OnCreatedChatroom += () => {
            var chatroomName = agent.Network.CurrentChatroomName;
            ShowMessage($"Chatroom \"{chatroomName}\" created!\n" +
            $" You are Peer ID 0");
            menuGO.SetActive(false);
            aCMenuGO.SetActive(true);
        };

        agent.Network.OnChatroomCreationFailed += ex => {
            ShowMessage("Chatroom creation failed");
        };

        agent.Network.OnlosedChatroom += () => {
            ShowMessage("You closed the chatroom! All peers have been kicked");
            menuGO.SetActive(true);
            aCMenuGO.SetActive(false);
        };

        // JOINING
        agent.Network.OnJoinedChatroom += id => {
            var chatroomName = agent.Network.CurrentChatroomName;
            ShowMessage("Joined chatroom " + chatroomName);
            ShowMessage("You are Peer ID " + id);

            menuGO.SetActive(false);
            aCMenuGO.SetActive(true);
        };

        agent.Network.OnChatroomJoinFailed += ex => {
            ShowMessage(ex);
        };

        agent.Network.OnLeftChatroom += () => {
            ShowMessage("You left the chatroom");

            menuGO.SetActive(true);
            aCMenuGO.SetActive(false);
        };

        // PEERS
        agent.Network.OnPeerJoinedChatroom += id => {
            var view = Instantiate(peerViewTemplate, peerViewContainer);
            view.IncomingAudio = !agent.PeerSettings[id].muteThem;
            view.OutgoingAudio = !agent.PeerSettings[id].muteSelf;

            view.OnIncomingModified += value =>
                agent.PeerSettings[id].muteThem = !value;

            view.OnOutgoingModified += value =>
                agent.PeerSettings[id].muteSelf = !value;

            peerViews.Add(id, view);
            view.SetPeerID(id);
        };

        agent.Network.OnPeerLeftChatroom += id => {
            var peerViewInstance = peerViews[id];
            Destroy(peerViewInstance.gameObject);
            peerViews.Remove(id);
        };
    }

    private void ShowMessage(object obj)
    {
        Debug.Log("<color=blue>" + obj + "</color>");
        menuMessage.text = obj.ToString();
        if (agent.CurrentMode != ChatroomAgentMode.Unconnected)
            chatroomMessage.text = obj.ToString();
    }

    void Update()
    {
        foreach (var output in agent.PeerOutputs)
        {
            if (peerViews.ContainsKey(output.Key))
            {
                /*
                 * This is an inefficient way of showing a part of the 
                 * audio source spectrum. AudioSource.GetSpectrumData returns
                 * frequency values up to 24000 Hz in some cases. Most human
                 * speech is no more than 5000 Hz. Showing the entire spectrum
                 * will therefore lead to a spectrum where much of it doesn't
                 * change. So we take only the spectrum frequencies between
                 * the average human vocal range.
                 * 
                 * Great source of information here: 
                 * http://answers.unity.com/answers/158800/view.html
                 */
                var size = 512;
                var minVocalFrequency = 50;
                var maxVocalFrequency = 8000;
                var sampleRate = AudioSettings.outputSampleRate;
                var frequencyResolution = sampleRate / 2 / size;

                var audioSource = (output.Value as InbuiltAudioOutput).AudioSource;
                var spectrumData = new float[size];
                audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

                var indices = Enumerable.Range(0, size - 1).ToList();
                var minVocalFrequencyIndex = indices.Min(x => (Mathf.Abs(x * frequencyResolution - minVocalFrequency), x)).x;
                var maxVocalFrequencyIndex = indices.Min(x => (Mathf.Abs(x * frequencyResolution - maxVocalFrequency), x)).x;
                var indexRange = maxVocalFrequencyIndex - minVocalFrequency;

                spectrumData = spectrumData.Select(x => 1000 * x)
                    .ToList()
                    .GetRange(minVocalFrequency, indexRange)
                    .ToArray();
                peerViews[output.Key].DisplaySpectrum(spectrumData);
            }
        }
    }
}
