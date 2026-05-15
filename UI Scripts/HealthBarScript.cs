using UnityEngine;
using UnityEngine.UI;



public class HealthBarScript : MonoBehaviour
{
    private Image image;

    [SerializeField] private PlayerHealthScript healthScript;

    [SerializeField] private float changeSpeed = 0.1f;

    private float targetFill;

    
    private void Awake()
    {
        image = GetComponent<Image>();
    }
   

    void Update()
    {
        targetFill = healthScript.health / healthScript.maxHealth;

        if (image.fillAmount != targetFill)
        {
            image.fillAmount = Mathf.MoveTowards(image.fillAmount, targetFill, changeSpeed);
        }
    }
}
