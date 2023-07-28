using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 2f;
    [SerializeField] float _turnSpeed = 100f;

    private Vector2 _moveInput;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Read movement input using the new Input System
        _moveInput = new Vector2(Keyboard.current.aKey.isPressed ? -1f : Keyboard.current.dKey.isPressed ? 1f : 0f,
                                 Keyboard.current.sKey.isPressed ? -1f : Keyboard.current.wKey.isPressed ? 1f : 0f);
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    public void Move()
    {
        // calculate the move amount
        Vector3 moveOffset = new Vector3(_moveInput.x, 0, _moveInput.y) * _moveSpeed * Time.fixedDeltaTime;
        // apply vector to the rigidbody
        _rb.MovePosition(_rb.position + moveOffset);
    }

    public void Turn()
    {
        // calculate the turn amount
        float turnAmountThisFrame = _moveInput.x * _turnSpeed * Time.fixedDeltaTime;
        // create a Quaternion from amount and direction (x,y,z)
        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
        // apply quaternion to the rigidbody
        _rb.MoveRotation(_rb.rotation * turnOffset);
    }
}
