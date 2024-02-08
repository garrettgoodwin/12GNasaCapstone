using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    [SerializeField] private float aliveTime;
    void Start()
    {
        Invoke("DestroyMyself", aliveTime);
    }

    void DestroyMyself()
    {
        Destroy(gameObject);
    }
}
