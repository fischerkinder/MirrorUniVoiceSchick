// GENERATED AUTOMATICALLY FROM 'Assets/fk/MirrorDemo/shared/visitor/input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""VisitorControls"",
            ""id"": ""9f9041dc-e2fc-4b24-8c68-a31e12ed620c"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""094e9cde-9ba3-4751-83be-183b32be43b8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GazeX"",
                    ""type"": ""PassThrough"",
                    ""id"": ""80b776c4-9a67-4fd0-b1da-793300f96ed9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GazeY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f0249782-5b37-4600-a19f-00f2d826ebda"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bc66b99b-0f40-46c7-a635-b1002eb74ffc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""View"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d060727d-2c45-4d01-a648-651293b60183"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD Keys"",
                    ""id"": ""45614442-3f5e-42d4-88d4-a776d52cbca6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cb1fa981-202e-4289-a9df-d5bbd27496ee"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""216642f5-b638-4dd4-bddb-88a04217139d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9a68e46c-1cb3-4e63-9663-f7cde36581c8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""717af7b0-b127-40d4-876c-0bae71c59cbc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Mouse"",
                    ""id"": ""e74cd36a-468f-4133-99e7-36c713dc11a6"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GazeX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""58434710-1f25-4638-a05f-492bb68d06f3"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GazeX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""7d639375-b67d-4726-8aeb-4b7d6ff4d8cf"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GazeX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Mouse"",
                    ""id"": ""e04cf0d8-9100-4cfe-ba46-4cea9937ecf0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GazeY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""a1f7f048-8040-47a8-8e4c-663b1bdfbfe0"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GazeY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""62b0fdf8-85ef-47df-b3b9-53a2e7f78dfe"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GazeY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c564492e-180e-48f1-ad1b-b12578d7041d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44064cd6-ad06-4ae3-8787-8d7c0e0748a2"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""View"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // VisitorControls
        m_VisitorControls = asset.FindActionMap("VisitorControls", throwIfNotFound: true);
        m_VisitorControls_Movement = m_VisitorControls.FindAction("Movement", throwIfNotFound: true);
        m_VisitorControls_GazeX = m_VisitorControls.FindAction("GazeX", throwIfNotFound: true);
        m_VisitorControls_GazeY = m_VisitorControls.FindAction("GazeY", throwIfNotFound: true);
        m_VisitorControls_Jump = m_VisitorControls.FindAction("Jump", throwIfNotFound: true);
        m_VisitorControls_View = m_VisitorControls.FindAction("View", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // VisitorControls
    private readonly InputActionMap m_VisitorControls;
    private IVisitorControlsActions m_VisitorControlsActionsCallbackInterface;
    private readonly InputAction m_VisitorControls_Movement;
    private readonly InputAction m_VisitorControls_GazeX;
    private readonly InputAction m_VisitorControls_GazeY;
    private readonly InputAction m_VisitorControls_Jump;
    private readonly InputAction m_VisitorControls_View;
    public struct VisitorControlsActions
    {
        private @PlayerControls m_Wrapper;
        public VisitorControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_VisitorControls_Movement;
        public InputAction @GazeX => m_Wrapper.m_VisitorControls_GazeX;
        public InputAction @GazeY => m_Wrapper.m_VisitorControls_GazeY;
        public InputAction @Jump => m_Wrapper.m_VisitorControls_Jump;
        public InputAction @View => m_Wrapper.m_VisitorControls_View;
        public InputActionMap Get() { return m_Wrapper.m_VisitorControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VisitorControlsActions set) { return set.Get(); }
        public void SetCallbacks(IVisitorControlsActions instance)
        {
            if (m_Wrapper.m_VisitorControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_VisitorControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_VisitorControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_VisitorControlsActionsCallbackInterface.OnMovement;
                @GazeX.started -= m_Wrapper.m_VisitorControlsActionsCallbackInterface.OnGazeX;
                @GazeX.performed -= m_Wrapper.m_VisitorControlsActionsCallbackInterface.OnGazeX;
                @GazeX.canceled -= m_Wrapper.m_VisitorControlsActionsCallbackInterface.OnGazeX;
                @GazeY.started -= m_Wrapper.m_VisitorControlsActionsCallbackInterface.OnGazeY;
                @GazeY.performed -= m_Wrapper.m_VisitorControlsActionsCallbackInterface.OnGazeY;
                @GazeY.canceled -= m_Wrapper.m_VisitorControlsActionsCallbackInterface.OnGazeY;
                @Jump.started -= m_Wrapper.m_VisitorControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_VisitorControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_VisitorControlsActionsCallbackInterface.OnJump;
                @View.started -= m_Wrapper.m_VisitorControlsActionsCallbackInterface.OnView;
                @View.performed -= m_Wrapper.m_VisitorControlsActionsCallbackInterface.OnView;
                @View.canceled -= m_Wrapper.m_VisitorControlsActionsCallbackInterface.OnView;
            }
            m_Wrapper.m_VisitorControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @GazeX.started += instance.OnGazeX;
                @GazeX.performed += instance.OnGazeX;
                @GazeX.canceled += instance.OnGazeX;
                @GazeY.started += instance.OnGazeY;
                @GazeY.performed += instance.OnGazeY;
                @GazeY.canceled += instance.OnGazeY;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @View.started += instance.OnView;
                @View.performed += instance.OnView;
                @View.canceled += instance.OnView;
            }
        }
    }
    public VisitorControlsActions @VisitorControls => new VisitorControlsActions(this);
    public interface IVisitorControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnGazeX(InputAction.CallbackContext context);
        void OnGazeY(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnView(InputAction.CallbackContext context);
    }
}
