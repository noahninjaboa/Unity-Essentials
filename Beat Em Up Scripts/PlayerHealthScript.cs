using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField] private float health = 100f;

    private ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }



    public class TakeDamageEvent : UnityEvent<float, string, GameObject> { }


    public TakeDamageEvent TakeDamage = new TakeDamageEvent();
    public void DealDamage(float amount, string type, GameObject sender)
    {
        TakeDamage.Invoke(amount, type, sender);
    }

    private void OnEnable()
    {
        TakeDamage.AddListener(OnTakeDamage);
    }

    private void OnDisable()
    {
        TakeDamage.RemoveListener(OnTakeDamage);
    }

    void OnTakeDamage(float amount, string type, GameObject sender)
    {
        health -= amount;
        Debug.Log($"{gameObject} took {amount} of {type} damage from {sender}. {gameObject} new health is {health}");
        ps.Play();

    }
}