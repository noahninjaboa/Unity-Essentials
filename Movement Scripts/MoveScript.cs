using UnityEngine;          //this is a simple platformer script with movement, running, and flipping when changing directions
using UnityEngine.InputSystem;
using System;
public class MoveScript : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float moveDirection = 0;
    [SerializeField] float runSpeed = 15f;
    public float direction = 1;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }    
    void Start()
    { 

    }


    void Update()
    {
        speed = 5f;
        moveDirection = 0f;
        
        if (Keyboard.current.shiftKey.isPressed)
        {
            speed = runSpeed;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            moveDirection = 1f;
            if (transform.localScale != new Vector3(1, 1, 1))
            {
                transform.localScale = new Vector3(1, 1, 1);
                direction = 1;
                
            }
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            moveDirection = -1f;
            transform.localScale = new Vector3(-1, 1, 1);
            direction = -1;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection * speed, rb.linearVelocity.y);
    }
}
