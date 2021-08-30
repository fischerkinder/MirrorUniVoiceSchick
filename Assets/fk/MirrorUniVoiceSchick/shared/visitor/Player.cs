using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : NetworkBehaviour
{
    private float _moveSpeed = 0.01F;
    private Vector2 _currentMove;
    private float _gazeSpeed = 0.01F;
    private Vector2 _currentGazeMove;
    private Camera _playerCamera = null;
    private AudioListener _audioListener = null;


    public void OnGazeX(InputAction.CallbackContext context)
    {
        _currentGazeMove.x += context.ReadValue<float>();
        Debug.Log("x: " + _currentGazeMove.x);
    }

    public void OnGazeY(InputAction.CallbackContext context)
    {
        _currentGazeMove.y = context.ReadValue<float>();
        Debug.Log("y: " + _currentGazeMove.y);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (isLocalPlayer)
        {
            _currentMove = context.ReadValue<Vector2>();
            /*
            float moveX = value.ReadValue<Vector2>().x;
            float moveZ = value.ReadValue<Vector2>().y;
            Vector3 movement = new Vector3(moveX * _playerSpeed, 0, moveZ * _playerSpeed);
            transform.position = transform.position + movement;

            // Set camera to active if player is local
            playerCamera = gameObject.GetComponent<Camera>();
            playerCamera.enabled = true;

            // Set audiolistener to active  if player is local
            audioListener = gameObject.GetComponent<AudioListener>();
            audioListener.enabled = true;
            */
           
        }
    }

    private void Update()
    {
        /*  Vector3 moveVelocity = _moveSpeed * (_currentMove.x * Vector3.right +
                                               _currentMove.y * Vector3.forward);
          Vector3 moveThisFrame = Time.deltaTime * moveVelocity;*/

        float moveX = _currentMove.x;
        float moveZ = _currentMove.y;
        Vector3 movement = new Vector3(moveX * _moveSpeed, 0, moveZ * _moveSpeed);
        transform.position = transform.position + movement;


        //transform.Rotate(0f, _currentGazeMove.x, _currentGazeMove.y);
        transform.Rotate(Vector3.up, _currentGazeMove.x);
    }
}
