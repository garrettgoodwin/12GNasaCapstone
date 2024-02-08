using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("General Enemy Statistics")]

    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;
    [SerializeField] protected float stopDistance;

    [Header("General Enemy References")]

    [SerializeField] private GameObject destroyParticles;
    [SerializeField] protected Animator anim;
    protected Transform player;
    protected PlayerHealth playerHealthScript;
    [SerializeField] protected SelfDestructor selfDestructor;

    void Start()
    {
        InitializeEnemy();
    }

    void InitializeEnemy()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        if(player != null)
        {
            playerHealthScript = player.gameObject.GetComponent<PlayerHealth>();

            if(playerHealthScript == null)
            {
                Debug.LogWarning("Player Health Script is not found in Enemy Script");
            }
        }
        else
        {
            Debug.LogWarning("Player Script is not found in Enemy Script");
        }
    }

    protected void DecreaseHealth(int amount)
    {
        health = health - amount;

        if (health <= 0)
        {
            Die();
        }
    }

    protected void InflictDamage(int amount)
    {
        if(playerHealthScript != null)
        {
            playerHealthScript.DecreaseHealth(amount);
        }
        else
        {
            Debug.LogWarning("Not able to inflict damage as PlayerHealthScript is null");
        }
    }

    protected void Die()
    {
        selfDestructor.DestroyOneself();
    }

    protected void FollowPlayerWithinRange()
    {
        if (player != null)
        {
            if (Vector2.Distance(player.position, transform.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
    }
}
