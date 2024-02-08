using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class MeleeEnemy : Enemy
{

    bool isFacingRight = false;

    [SerializeField] private GameObject visualIndicator;

    protected void FollowPlayerWithinRanges()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(player.position, transform.position);

            if (distanceToPlayer > stopDistance)
            {
                // Move towards the player
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                // Determine the vertical threshold for rotation
                float verticalThreshold = 0.3f; // You can adjust this value to increase/decrease the buffer zone

                // Calculate the vertical distance to the player
                float verticalDistance = player.position.y - transform.position.y;

                // Determine the horizontal distance to check if the player is behind
                float horizontalDistance = player.position.x - transform.position.x;



                // Determine the angle we want to rotate to based on the player's position
                float targetAngle = 90; // Player is within the buffer zone


                if (verticalDistance > verticalThreshold)
                {
                    targetAngle = isFacingRight ? 110 : 70;
                }
                else if (verticalDistance < -verticalThreshold)
                {
                    targetAngle = isFacingRight ? 70 : 110;
                }



                // Check if the player is behind the enemy to flip the sprite
                if (Mathf.Abs(horizontalDistance) < 0.5f) // Behind threshold, adjust as necessary
                {
                    if ((horizontalDistance > 0 && !isFacingRight) || (horizontalDistance < 0 && isFacingRight))
                    {
                        // Flip the enemy to face the player
                        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
                        isFacingRight = !isFacingRight; // Update the facing direction
                    }
                }

                transform.rotation = Quaternion.Euler(0, 0, targetAngle);
            }
        }
    }



    void Update()
    {
        FollowPlayerWithinRanges();
    }

    void Blinking()
    {
        //visualIndicator
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player != null)
        {
            if (collision.gameObject == player.gameObject)
            {
                playerHealthScript.DecreaseHealth(damage);
                CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
                Die();
            }
        }

        if(collision.gameObject.tag == "Enemy")
        {
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
            Die();
        }
    }
}
