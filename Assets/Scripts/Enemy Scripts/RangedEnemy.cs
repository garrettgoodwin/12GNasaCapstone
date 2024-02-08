using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public bool inRange;
    [SerializeField] private ProjectileLauncher projectileLauncher;

    void Update()
    {
        FollowPlayerAtADistance();

        if(!inRange)
        {
            projectileLauncher.LaunchAt(player);
        }
    }

    void FollowPlayerAtADistance()
    {
        if (player != null)
        {
            if (Vector2.Distance(player.position, transform.position) >= stopDistance + .1)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                speed = 2;
                inRange = false;
            }
            else if (Vector2.Distance(player.position, transform.position) < stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
                speed = 3;
                inRange = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player != null)
        {
            if (collision.gameObject == player.gameObject)
            {
                playerHealthScript.DecreaseHealth(damage);
                Die();
            }
        }
        else
        {
            Debug.LogWarning("Player is null in RangedEnemy screipt");
        }
    }
}
