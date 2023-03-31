using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private bool isCursorOnRightSide = false; // variable to store whether cursor is on right side
    private bool wasCursorOnRightSide = false; // variable to store previous state of cursor

    private Vector2 input;
    private CharacterHandler handler;

    private void Start()
    {

        handler = GetComponent<CharacterHandler>();


    }
    // Update is called once per frame
    void Update()
    {

        input = new Vector2(Input.GetAxis("Horizontal") , Input.GetAxis("Vertical"));
        if (Input.GetButtonDown("Fire1"))
        {
            handler.AttackRequest();
        }        
        handler.MoveRequestDirection(input);
        

        // get the x-coordinate of the cursor
        float cursorX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

        // get the x-coordinate of the character - this script is in character
        float playerX = transform.position.x;

        // compare the two coordinates to determine if cursor is on right or left side
        if (cursorX > playerX)
        {
            isCursorOnRightSide = true;
        }
        else
        {
            isCursorOnRightSide = false;
        }

        // check if cursor has moved to a different side than before
        if (isCursorOnRightSide != wasCursorOnRightSide)
        {
            // call the ChangeLookingSide function with the new side
            handler.ChangeLookingSide(isCursorOnRightSide);
        }

        // update the previous state of the cursor
        wasCursorOnRightSide = isCursorOnRightSide;
    }
    void ChangeLookingSide(bool isLookingRight)
    {
        // do something here  based on the new side
        Debug.Log(Input.mousePosition);
    }
}