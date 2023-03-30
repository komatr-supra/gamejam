using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Action onMovementComplete;
    private SpriteAnimator1 animator;
    private bool _isMoving;
    public bool IsMoving
    {
        get
        {
            
            return _isMoving;                
        }
        private set
        {
            
            _isMoving = value;
            animator.SetAnimation(_isMoving ? ANIMATION.WALK : ANIMATION.IDLE);
        }
    }
    private Vector3 targetPosition;
    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<SpriteAnimator1>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
        //test
        if(Input.GetMouseButtonDown(0)) MoveRequestPosition(MouseCursor.Instance.WorldMousePosition);
        if(IsMoving) PerformMovement();
    }

    public void ChangeLookingSide(bool isLookingRight)
    {
        transform.localScale = new Vector3(isLookingRight ? 1 : -1, 1, 1);
    }

    //test
    private void PerformMovement()
    {
        float speed = 2;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        rb2d.MovePosition(newPosition);
        if(Vector3.Distance(transform.position, targetPosition) < 0.01f) MovementEnded();
    }
    
    private void MovementEnded()
    {
        onMovementComplete?.Invoke();
        IsMoving = false;
        
    }
    public void MoveRequestDirection(Vector2 direction)
    {           
        targetPosition = (Vector2)transform.position + direction;
        IsMoving = true;
    }
    public void MoveRequestPosition(Vector2 target)
    {   
        targetPosition = target;
        IsMoving = true;
    }
    
    public void AttackRequest()
    {
        Debug.Log("here will be called shoot script");
        //callback if bullet was shoot?
    }
}
