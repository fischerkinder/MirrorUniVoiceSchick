using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : NetworkBehaviour
{
    [SerializeField] float sensitivityX = 150f;
    [SerializeField] float sensitivityY = 0.5f;
    [SerializeField] float yawClamp = 85;
    private float _mouseX;
    private float _mouseY;
    private float _yaw;
    [SerializeField] Transform playerCamera;



    public void ReceiveInput(Vector2 mouseInput)
    {
        _mouseX = mouseInput.x * sensitivityX;
        _mouseY = mouseInput.y * sensitivityY;
    }

    
    private void Update()
    {
        transform.Rotate(Vector3.up, _mouseX * Time.deltaTime);
        
        // Reverse axis
        _yaw -= _mouseY;
        // Assign maximum rotations
        _yaw = Mathf.Clamp(_yaw, -yawClamp, yawClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = _yaw;
        playerCamera.eulerAngles = targetRotation;
    }
}
