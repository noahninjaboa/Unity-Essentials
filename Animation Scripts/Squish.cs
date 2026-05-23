using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    [SerializeField] private float squishSpeed = 1f;
    [SerializeField] private float squishMax = 0.1f;

    [SerializeField] private float rotateSpeed = 2f;
    [SerializeField] private float rotateMax = 2f;


    private void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {


        float wave = Mathf.Sin(Time.time * squishSpeed);
        float scale = Mathf.Lerp(1f - squishMax, 1f + squishMax, (wave + 1f) * 0.5f);

        transform.localScale = new Vector3(
            transform.localScale.x,
            scale,
            transform.localScale.z
        );

        float rotateWave = Mathf.Sin(Time.time * rotateSpeed);
        float rotate = rotateWave * rotateMax;

        transform.rotation = Quaternion.Euler(0, 0, rotate);










    }
}
