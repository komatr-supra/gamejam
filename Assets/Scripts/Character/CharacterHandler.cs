using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHandler : MonoBehaviour
{
    
    [SerializeField] Transform bulletSpawnPoint;
    private Mover mover;
    public Action onMovementComplete;
    private SpriteAnimator1 animator;
    private WeaponRotation weapon;
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
        weapon = GetComponentInChildren<WeaponRotation>();
    }
    public void ChangeLookingSide(bool isLookingRight)
    {
        GetComponent<SpriteRenderer>().flipX = !isLookingRight;
        weapon.GetComponent<SpriteRenderer>().flipY = !isLookingRight;
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
    
    public void AttackRequest(Vector3 mousePosition)
    {
        //Debug.Log("here will be called shoot script");
        //callback if bullet was shoot?
        weapon.Shoot();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            Destroy(gameObject);
            SceneManager.LoadScene("EndScene");
        }
    }
}
