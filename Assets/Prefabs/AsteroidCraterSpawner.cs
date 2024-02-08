using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCraterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnables;
    [SerializeField] private CircleCollider2D boundary;

    [SerializeField] private int numberToSpawn;

    [SerializeField] private GameObject parentObject;


    private void Awake()
    {
        SpawnCraters();
    }


    public void SpawnCraters()
    {
        GameObject gameobjectToSpawn;

        float screenX, screenY;
        Vector2 posiiton;
        GameObject spawnedObject;


        int spawnAmount = Random.Range(3, numberToSpawn);

        for (int i = 0; i < spawnAmount; i++)
        {
            gameobjectToSpawn = spawnables[Random.Range(0, spawnables.Length)];
            screenX = Random.Range(boundary.bounds.min.x + .05f, boundary.bounds.max.x - .05f);
            screenY = Random.Range(boundary.bounds.min.y + .05f, boundary.bounds.max.y - .05f);

            posiiton = new Vector2(screenX, screenY);

            spawnedObject = Instantiate(gameobjectToSpawn, posiiton, transform.rotation, parentObject.transform);

            BoxCollider2D tmpYCollider = spawnedObject.GetComponent<BoxCollider2D>();
            tmpYCollider.enabled = false; // Disable object's own collider to prevent detecting itself

            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(spawnedObject.transform.position, .05f);

            foreach (var hitCollider in hitColliders)
            {

                if (hitCollider.gameObject.tag == "AsteroidCrater")
                {
                    Destroy(spawnedObject);
                }
            }

            tmpYCollider.enabled = true; // enable the collider again

        }
    }

}
