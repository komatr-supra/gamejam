using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private Vector2 input;
    private CharacterHandler handler;
    private void Start()
    {
        handler = GetComponent<CharacterHandler>();
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            handler.AttackRequest();
        }
        if (input!=Vector2.zero)
        {
            handler.MoveRequestDirection(input);
         }
    }
}
