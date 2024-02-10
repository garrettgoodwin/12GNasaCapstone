using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MucisTest : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        audioSource.time = 17.5f; // Set the start time to 17 seconds
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
