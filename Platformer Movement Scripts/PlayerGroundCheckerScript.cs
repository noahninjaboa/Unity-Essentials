using UnityEngine;

public class PlayerGroundCheckerScript : MonoBehaviour
{

    [SerializeField] private PlayerMovingScript playerMovingScript;


   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IsGround>(out var _))
        {
            playerMovingScript.changeGrounded(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IsGround>(out var _))
        {
            Debug.Log("exit");
            playerMovingScript.changeGrounded(false);
        }
    }

}
