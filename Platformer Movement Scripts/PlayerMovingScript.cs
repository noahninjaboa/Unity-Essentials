using UnityEngine;        
using UnityEngine.InputSystem;
public class PlayerMovingScript : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;


    [SerializeField] float jumpStrength = 5f;

    [SerializeField] private int direction = 0;

    [SerializeField] private float frictionMultiplierX = 0.95f;  //friction multiplier comes into effect when player isn't trying to move

    private Rigidbody2D rb;

    [SerializeField] private bool grounded = false;

    public void changeGrounded(bool value)
    {
        grounded = value;

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   

    void Update()
    {
        
    

        if (Keyboard.current.dKey.isPressed)
        {
            direction = 1;

            
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            direction = -1;

        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (grounded)
            {
                rb.linearVelocityY = jumpStrength;
            }
        }
    }

    private void FixedUpdate()
    {
       if (direction != 0)
        {
            rb.linearVelocityX = speed * direction;

            direction = 0;
        }
        else
        {
            rb.linearVelocityX = rb.linearVelocityX * frictionMultiplierX;
        }

            


    }







}
