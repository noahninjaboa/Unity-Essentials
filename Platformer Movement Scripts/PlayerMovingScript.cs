using UnityEngine;        
using UnityEngine.InputSystem;
using System;
public class PlayerMovingScript : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float moveDirection = 0;
    [SerializeField] float stepSpeed = 0f;

    public float direction = 1;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
    }
    void Start()
    {

    }


    void Update()
    {

    

        if (Keyboard.current.dKey.isPressed)
        {
            moveDirection = 1f;
           
            transform.localScale = new Vector3(1, 1, 1);
            direction = 1;

            
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            moveDirection = -1f;
            transform.localScale = new Vector3(-1, 1, 1);
            direction = -1;
        }
        if (Keyboard.current.spaceKey.isPressed)
        {
            //jumping logic
        }
    }

    private void FixedUpdate()
    {
        stepSpeed = speed * moveDirection;

        if ( grounded())
        {
            rb.linearVelocityX = stepSpeed;

        }



        stepSpeed = 0f;
        moveDirection = 0f;
    }

    private bool grounded()
    {
        float extraHeight = 0.1f;

        RaycastHit2D raycast = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + extraHeight);

        Color rayColor = Color.red;


        if (raycast.collider != null)
        {
            rayColor = Color.green;
            Debug.DrawRay(boxCollider2d.bounds.center, Vector2.down * boxCollider2d.bounds.extents.y, rayColor);

            return true;
        }
        else
        {
            rayColor = Color.red;
            Debug.DrawRay(boxCollider2d.bounds.center, Vector2.down * boxCollider2d.bounds.extents.y, rayColor);

            return false;
        }



    }

}
