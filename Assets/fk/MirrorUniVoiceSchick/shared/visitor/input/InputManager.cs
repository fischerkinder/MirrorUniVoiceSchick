using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : NetworkBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;
    
    PlayerControls controls;
    PlayerControls.VisitorControlsActions visitorControlsActions;

    private Vector2 _currentMove;
    private Vector2 _gazeMove;

    // Neds to be deactivated when loaded and activated only for one player
    public Camera playerCamera;
    

    public override void OnStartAuthority()
    {
        // Set camera to active if player is local
        //_playerCamera = gameObject.GetComponent<Camera>();
        playerCamera.enabled = true;

    }


    private void Awake()
    {
        controls = new PlayerControls();
        visitorControlsActions = controls.VisitorControls;

        // If there are actions performed specified in the PlayerControls Action map
        // such as Movement. Read the value and store it temporarily in a class variable, which is then 
        // in the Update funktion passed to the appropritate model.
        visitorControlsActions.Movement.performed += ctx => _currentMove = ctx.ReadValue<Vector2>();
        visitorControlsActions.Jump.performed += _ => movement.OnJumpPressed();
        visitorControlsActions.View.performed += ctx => _gazeMove = ctx.ReadValue<Vector2>();
        
    }

    private void Update()
    {
        movement.ReceiveInput(_currentMove);
        mouseLook.ReceiveInput(_gazeMove);
    }


    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
