using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Shrink : MonoBehaviour
{

    [SerializeField] private float shrinkRate;
    [SerializeField] private float minScale = 0.1f;


    private void Start()
    {
        StartCoroutine(ShrinkOverTime());
    }

    IEnumerator ShrinkOverTime()
    {

        while(transform.localScale.x > minScale)
        {
            Vector3 newScale = transform.localScale;
            newScale.x -= shrinkRate * Time.deltaTime;
            newScale.y -= shrinkRate * Time.deltaTime;
            newScale.z -= shrinkRate * Time.deltaTime;
            newScale.x = Mathf.Max(newScale.x, minScale);
            newScale.y = Mathf.Max(newScale.y, minScale);
            newScale.z = Mathf.Max(newScale.z, minScale);

            transform.localScale = newScale;
            yield return null;
        }
    }
}
