using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] private int valueAmount = 1;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float lifetime;
    [SerializeField] private float speed;

    [Header("References")]
    [SerializeField] private SelfDestructor selfDestructor;
    [SerializeField] private GameObject brokenObjectPrefab;
    [SerializeField] private GameObject parentToBrokenObjects;



    private float amplitude = .05f; // Amplitude of the sine wave
    private float frequency = 7f; // Frequency of the sine wave
    private float yOffset; // Offset to store the initial y position

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        Invoke("DestroySelf", lifetime);
    //    yOffset = transform.position.y;

    }


    private void Update()
    {
        // Move left
        transform.Translate(Vector2.right * -speed * Time.deltaTime);

        // Calculate the new y position using a sine wave
  //      float y = yOffset + amplitude * Mathf.Sin(Time.time * frequency);

        // Update the position of the coin
        //transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //PlayerBank playerBank = collision.GetComponent<PlayerBank>();
                


            if(PlayerBank.Instance != null)
            {
                PlayerBank.Instance.IncreaseBankAmount(valueAmount);
                StartCoroutine(testthingy());
                Instantiate(brokenObjectPrefab, transform.position, transform.rotation);
                selfDestructor.DestroyOneself();
            }
            else
            {
                Debug.LogWarning("Unable to increase player's bank as player bank is null");
            }
        }
    }

    IEnumerator testthingy()
    {
        //yield return new WaitForSeconds(.025f);
        yield return new WaitForSeconds(.001f);
    }


}
