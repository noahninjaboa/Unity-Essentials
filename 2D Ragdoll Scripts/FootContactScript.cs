using UnityEngine;

public class FootContactScript : MonoBehaviour
{

    [SerializeField] Movement movement; 
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<JumpAble>(out var jumpable))
        {
            movement.isGrounded = true;
        }
        
    }
}
