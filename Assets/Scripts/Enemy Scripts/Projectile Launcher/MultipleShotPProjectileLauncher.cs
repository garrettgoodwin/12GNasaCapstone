using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleShotPProjectileLauncher : ProjectileLauncher
{
    public override void LaunchAt(Transform target)
    {
        Quaternion rotation = Quaternion.AngleAxis(Rotation(target) + 90, Vector3.forward);
        transform.rotation = rotation;
        float multishotangleDifference = 10f;

        if (Time.time >= lastLaunchedTime)
        {
            for (int i = -1; i <= 1; i++)
            {
                Quaternion offsetRotation = Quaternion.Euler(0, 0, multishotangleDifference * i);
                Quaternion modifiedRotation = transform.rotation * offsetRotation;
                Instantiate(projectileObj, spawnPoint.position, modifiedRotation);
            }
            lastLaunchedTime = Time.time + launchCooldown;
        }
    }
}
