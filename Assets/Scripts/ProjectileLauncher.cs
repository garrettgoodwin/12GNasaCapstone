using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileLauncher : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected float launchCooldown;
    protected float lastLaunchedTime;

    [Header("References")]
    [SerializeField] protected GameObject projectileObj;
    [SerializeField] protected AudioSource[] launchSounds;


    public abstract void LaunchAt(Transform target);

    public float Rotation(Transform target)
    {
        if (target != null)
        {
            //Subtracts the mouses position by the launch Cannons original position
            Vector2 direction = target.position - transform.position;

            //Atan2 -Output is in radians then multiplied to degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return angle;
        }
        return 0;
    }
}
