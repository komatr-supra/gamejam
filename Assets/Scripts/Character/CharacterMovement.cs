using System;
using UnityEngine;
public class CharacterMovement : MonoBehaviour
{
    public float PlayerSpeed;
    private Rigidbody2D _body ;
    public Vector2 moveDirection;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        Move();
        Vector2 lookDir = MouseCursor.Instance.WorldMousePosition- _body.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        _body.rotation = angle;
    }

    private void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void Move()
    {
        _body.velocity = new Vector2(moveDirection.x * PlayerSpeed, moveDirection.y * PlayerSpeed);
    }
}