using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    private Rigidbody2D rb2d;
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
        if(input != Vector2.zero) Move(input);
    }
    public void Move(Vector2 direction)
    {        
        Debug.Log("here will be called move script");

        //test
        float speed = 2;
        Vector2 targetPosition = (Vector2)transform.position + direction;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        rb2d.MovePosition(newPosition);
    }
    public void Attack()
    {
        Debug.Log("here will be called shoot script");
    }
}
