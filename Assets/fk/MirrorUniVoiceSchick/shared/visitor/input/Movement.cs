using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : NetworkBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;
    [SerializeField] float gravity = -15f;
    private Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float jumpHeight = 3.5f;

    private bool _jump;
    private bool _isGrounded;
    private Vector2 _currentMove;

    public override void OnStartAuthority()
    {
        controller.enabled = true;
    }


    private void Update()
    {
        _isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);

        if (_isGrounded)
        {
            verticalVelocity.y = 0;
        }

        Vector3 horizonatlVelocity = (transform.right * _currentMove.x + transform.forward * _currentMove.y) * speed;
        controller.Move(horizonatlVelocity * Time.deltaTime);

        
        //Jump: v = sqrt(-2 * jumpHeight * gravity)
        if (_jump)
        {
            if (_isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);    
            }
            _jump = false;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }
    public void ReceiveInput (Vector2 currentMove)
    {
        _currentMove = currentMove;
    }

    public void OnJumpPressed()
    {
        _jump = true;
    }
}
