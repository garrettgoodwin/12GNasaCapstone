using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public enum UpgradeType
    {
        Health,
        Magnet
    }

    [Header("Statistics")]
    [SerializeField] private int valueAmount = 1;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float lifetime;
    [SerializeField] private float speed;

    [Header("References")]
    [SerializeField] private SelfDestructor selfDestructor;

    [SerializeField] private float amplitude = .05f; // Amplitude of the sine wave
    [SerializeField] private float frequency = 7f; // Frequency of the sine wave
    [SerializeField] private float yOffset; // Offset to store the initial y position

    [Header("Upgrade Settings")]
    [SerializeField] private UpgradeType upgradeType;



    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        Invoke("DestroySelf", lifetime);
        yOffset = transform.position.y;
    }

    private void Update()
    {
        // Move left
        transform.Translate(Vector2.right * -speed * Time.deltaTime);

        // Calculate the new y position using a sine wave
        float y = yOffset + amplitude * Mathf.Sin(Time.time * frequency);

        // Update the position of the coin
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            switch(upgradeType)
            {
                case UpgradeType.Health:

                    PlayerHealth playerhealth = collision.GetComponent<PlayerHealth>();

                    if (playerhealth != null)
                    {
                        playerhealth.IncreaseHealth(1);
                        selfDestructor.DestroyOneself();
                    }
                    else
                    {
                        Debug.LogWarning("Unable to increase player's bank as player bank is null");
                    }
                    break;

                case UpgradeType.Magnet:

                    collision.GetComponent<MagnetController>().EnableMagnet();
                    selfDestructor.DestroyOneself();
                    break;
            }
        }
    }
}
