using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class DoorScript : MonoBehaviour
{
    [SerializeField] private string targetSpawnId;
    public static string NextSpawnId;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out var player))
        {
            if (Keyboard.current.upArrowKey.isPressed)

            {
                
                SceneTransition.NextSpawnId = targetSpawnId;
                SceneManager.LoadScene("MainScene");

            }
        }
    }
}
