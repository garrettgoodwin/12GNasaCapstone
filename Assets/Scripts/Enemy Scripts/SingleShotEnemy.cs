using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotEnemy : Enemy
{
    [Header("Single-Shot References")]

    [SerializeField] private ProjectileLauncher projectileLauncher;

    public enum EnemyState
    {
        None,
        Move,
        PrepareToShoot,
        Shoot,
        PrepareToRetreat,
        Retreat,
        Done
    }

    private EnemyState currentEnemyState = EnemyState.None;

    [SerializeField] private float moveTime = 2f;
    [SerializeField] private float preparteToShootTime = 2f;
    [SerializeField] private float prepareToRetreatTime = 2f;
    [SerializeField] private float retreatTime = 2f;

    private float enemyStateTransitionATimer = 0f;

    void Start()
    {
        currentEnemyState = EnemyState.Move;
    }

    void Update()
    {
        switch (currentEnemyState)
        {
            case EnemyState.None:
                //Do Nothing
                break;

            case EnemyState.Move:
                transform.Translate(Vector2.right * -speed * Time.deltaTime);
                if(enemyStateTransitionATimer >= moveTime)
                {
                    currentEnemyState = EnemyState.PrepareToShoot;
                    enemyStateTransitionATimer = 0;
                }
                break;

            case EnemyState.PrepareToShoot:
                if (enemyStateTransitionATimer >= preparteToShootTime)
                {
                    currentEnemyState = EnemyState.Shoot;
                    enemyStateTransitionATimer = 0;
                }
                break;

            case EnemyState.Shoot:
                anim.SetBool("shoot", true);
                //anim.SetBool("shoot", false);
                projectileLauncher.LaunchAt(player);
                currentEnemyState = EnemyState.PrepareToRetreat;
                enemyStateTransitionATimer = 0;
                break;

            case EnemyState.PrepareToRetreat:
                if (enemyStateTransitionATimer >= prepareToRetreatTime)
                {
                    currentEnemyState = EnemyState.Retreat;
                    enemyStateTransitionATimer = 0;
                }
                break;


            case EnemyState.Retreat:

                transform.localScale = new Vector3(-1f, 1f, 1f);
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                if (enemyStateTransitionATimer >= retreatTime)
                {
                    currentEnemyState = EnemyState.Done;
                    enemyStateTransitionATimer = 0;
                }
                break;

            case EnemyState.Done:
                Die();
                break;
        }

        enemyStateTransitionATimer += Time.deltaTime;
    }
}
