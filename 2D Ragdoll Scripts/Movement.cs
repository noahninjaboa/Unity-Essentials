using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public GameObject leftLeg;
    public GameObject rightLeg;
    Rigidbody2D leftLegRb;
    Rigidbody2D rightLegRb;

    [SerializeField] float speed = 1.5f;
    [SerializeField] float stepWait = 0.5f;
    [SerializeField] float jumpForce = 7f;

    [SerializeField] Rigidbody2D bodyRb;
    bool isGrounded;

    private bool isSteppingRight = false;
    private bool isSteppingLeft = false;

    public Animator anim;
    void Start()
    {
        leftLegRb = leftLeg.GetComponent<Rigidbody2D>();
        rightLegRb = rightLeg.GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        if (Keyboard.current.dKey.isPressed)
        {
            if (!isSteppingRight)
            {
                anim.Play("WalkRight");
                StartCoroutine(MoveRight(stepWait));
            }
           
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            if (!isSteppingLeft)
            {
                anim.Play("WalkLeft");
                StartCoroutine(MoveLeft(stepWait));
            }
        }




    
        else
        {
            anim.Play("Idle");
        }
    }
    IEnumerator MoveRight(float seconds)
    {

        isSteppingLeft = false;
        leftLegRb.AddForce(Vector2.right * (speed*1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        rightLegRb.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
        isSteppingRight = false;

    }
    IEnumerator MoveLeft(float seconds)
    {
        isSteppingRight = false;

        rightLegRb.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        leftLegRb.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);

        isSteppingLeft = false;


    if (Keyboard.current.spaceKey.isPressed)
    {
            bodyRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }   
     


    }






    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<JumpAble>(out var jumpAble))
        {
            isGrounded = true;
        }
    }
}
