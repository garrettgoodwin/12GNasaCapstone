using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondHazard : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float lifetime;
    private float speed;

    [Header("References")]
    [SerializeField] private SelfDestructor selfDestructor;


    [SerializeField] private GameObject brokenObjectPrefab;
    [SerializeField] private GameObject parentToBrokenObjects;
    [SerializeField] private GameObject whiteAsteroid;

    [SerializeField] private Animator anim;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        int  randNimb = Random.Range(0, 2);
        if(randNimb == 0)
        {
            anim.SetBool("CCW", true);

        }
        else
        {
            anim.SetBool("CCW", false);
        }
        speed = Random.Range(minSpeed, maxSpeed);
        Invoke("DestroySelf", lifetime);

        // Move right to left
        rb.velocity = new Vector2(-speed, 0);
    }

    private void Update()
    {
       // transform.Translate(Vector2.right * -speed * Time.deltaTime);
    }


    IEnumerator testthingy()
    {
        whiteAsteroid.SetActive(true);
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        //parentToBrokenObjects.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.025f);
        whiteAsteroid.SetActive(false);
        Instantiate(brokenObjectPrefab, transform.position, parentToBrokenObjects.transform.rotation);
        selfDestructor.DestroyOneself();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {

                StartCoroutine(testthingy());
                // Instantiate(brokenObjectPrefab, transform.position, parentToBrokenObjects.transform.rotation);

                playerHealth.DecreaseHealth(damageAmount);
                // selfDestructor.DestroyOneself();

            }
            else
            {

                Debug.LogWarning("Unable to increase player's health as player health is null");
            }
        }
        else if (collision.gameObject.tag == "Missile")
        {
            StartCoroutine(testthingy());

            //Instantiate(brokenObjectPrefab, transform.position, parentToBrokenObjects.transform.rotation);
            //selfDestructor.DestroyOneself();


        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
