using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    private Mover mover;
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
    private void Awake() {
        mover = GetComponent<Mover>();
        animator = GetComponent<SpriteAnimator1>();
    }
    public void ChangeLookingSide(bool isLookingRight)
    {
        transform.localScale = new Vector3(isLookingRight ? 1 : -1, 1, 1);
    }
    
    
    private void MovementEnded()
    {
        onMovementComplete?.Invoke();
        IsMoving = false;
        
    }
    public void MoveRequestDirection(Vector2 direction)
    {
        mover.Move(direction.normalized);
        IsMoving = true;
    }
    public void MoveRequestPosition(Vector2 target)
    {   
        IsMoving = true;
    }
    
    public void AttackRequest()
    {
        Debug.Log("here will be called shoot script");
        //callback if bullet was shoot?
    }
}
