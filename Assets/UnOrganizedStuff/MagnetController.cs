using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{


    [SerializeField] private float radiusOfAttraction;
    [SerializeField] private float attractionForce;
    [SerializeField] private float magnetDuration;
    [SerializeField] private bool isMagnetActive;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isMagnetActive)
        {
            AttractMagneticItems();
        }
    }


    public void EnableMagnet()
    {
        isMagnetActive = true;
        Invoke("DisableMagnet", magnetDuration);
    }

    void DisableMagnet()
    {
        isMagnetActive = false;
    }

    void AttractMagneticItems()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, radiusOfAttraction);

        foreach(var hitCollider in collider2Ds)
        {
            if(hitCollider.CompareTag("Coin"))
            {
                Rigidbody2D coinRb = hitCollider.GetComponent<Rigidbody2D>();
                Vector2 direction = (Vector2)transform.position - (Vector2)hitCollider.transform.position;

                float distance = direction.magnitude;
                float forceMagnitude = Mathf.Lerp(attractionForce, 0, distance / radiusOfAttraction);

                float maxVelocity = 3f;

                if(coinRb.velocity.magnitude > maxVelocity)
                {
                    coinRb.velocity *= 0.9f;
                }


                coinRb.AddForce(direction.normalized * forceMagnitude);






                //Vector2 direction = (Vector2)transform.position - (Vector2)hitCollider.transform.position;
            }
        }
    }
}
