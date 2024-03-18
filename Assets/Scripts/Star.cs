using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class Star : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float lifetime;
    private float speed;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        Invoke("DestroySelf", lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * -speed* Time.deltaTime);
    }

    //private IEnumerator SlowDownStar(float duration)
    //{
    //    float timeElapsed = 0;
    //    float startSpeed = speed; 

    //    while (timeElapsed < duration)
    //    {
    //        timeElapsed += Time.deltaTime;
    //        speed = Mathf.Lerp(startSpeed, 0, timeElapsed / duration);
    //        yield return null;
    //    }

    //    speed = 0;
    //}

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
