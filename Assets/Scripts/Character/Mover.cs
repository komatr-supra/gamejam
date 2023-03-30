using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private Vector3 targetPosition;
    private Rigidbody2D rb2d;
    private bool IsMoving;
    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(IsMoving && Vector3.Distance(transform.position, targetPosition) > 0.01f) IsMoving = false;
    }
    public void Move(Vector2 direction)
    {
        targetPosition = transform.position + (Vector3)direction;
        IsMoving = true;
    }
    private void FixedUpdate() {
        rb2d.MovePosition(Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * 0.1f));
    }

    
}
