using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool isMoving;
    public bool IsMoving
    {
        get
        {
            //animator moving
            return isMoving;                
        }
        private set
        {
            //animator idle
            isMoving = value;
        }
    }
    private Vector3[] targetPositions;
    private int index;
    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        //test
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(input != Vector2.zero) MoveRequestDirection(input);
        if(Input.GetMouseButtonDown(0)) MoveRequestPosition(MouseCursor.Instance.WorldMousePosition);
        if(IsMoving) PerformMovement();
    }
    //test
    private void PerformMovement()
    {
        float speed = 2;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPositions[index], speed * Time.deltaTime);
        rb2d.MovePosition(newPosition);
        if(Vector3.Distance(transform.position, targetPositions[index]) < 0.01f) MovementEnded();
    }
    
    private void MovementEnded()
    {
        if(++index >= targetPositions.Length)
        {
            IsMoving = false;
            index = 0;
        } 
        else Debug.Log("pick new element in array, its for pathfinder");
        //also check AI if want move anywhere else or do something else
    }
    public void MoveRequestDirection(Vector2 direction)
    {           
        targetPositions = new Vector3[] {(Vector2)transform.position + direction};
        IsMoving = true;
    }
    public void MoveRequestPosition(Vector2 target)
    {   
        targetPositions = new Vector3[] {target};
        IsMoving = true;
    }
    
    public void AttackRequest()
    {
        Debug.Log("here will be called shoot script");
        //callback if bullet was shoot?
    }
}
