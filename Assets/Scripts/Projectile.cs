using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Shoudl add this but lazy
public class Projectile : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private int damage;
    [SerializeField] private bool hitObject;

    [Header("References")]
    [SerializeField] private SelfDestructor selfDestructor;

    void Start()
    {
        Invoke(nameof(DestroyProjectile), lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime); // Framerate independent time.deltaTime
    }

    void DestroyProjectile()
    {
        if (gameObject != null)
        {
            selfDestructor.DestroyOneself();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.DecreaseHealth(damage);
                selfDestructor.DestroyOneself();
            }
            else
            {
                Debug.LogWarning("Unable to increase player's health as player health is null");
            }
        }
    }
}
