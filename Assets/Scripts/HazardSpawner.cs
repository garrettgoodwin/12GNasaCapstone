using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] private float spawnCooldown;
    [SerializeField] private float initialSpawnTime;
    [SerializeField] private float timeDecreaseRate;
    [SerializeField] float initialSpawnTimeDelayInSec;
    private float timeUntilNextSpawn;

    [Header("References")]
    [SerializeField] private Transform[] spawnpointTransforms;
    [SerializeField] private GameObject[] hazardPrefabs;

    private bool initialSSpawnDelayCompleted = false;

    public bool isStarSpawner = false;


    public bool shouldHaveInitialClick = false;

    void Update()
    {

        if(shouldHaveInitialClick)
        {
            Debug.Log("1");
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("3");
                StartCoroutine(InitialSpawnTimeDelay(initialSpawnTimeDelayInSec));
                shouldHaveInitialClick = false;
            }
        }
        else
        {
            StartCoroutine(InitialSpawnTimeDelay(initialSpawnTimeDelayInSec));
        }

        if (initialSSpawnDelayCompleted && timeUntilNextSpawn <= 0)
        {
            SpawnHazardAtRandomSpawnPoint();

            if (initialSpawnTime > spawnCooldown)
            {
                initialSpawnTime -= timeDecreaseRate;
            }

            timeUntilNextSpawn = initialSpawnTime;
        }
        else
        {
            timeUntilNextSpawn -= Time.deltaTime;
        }
    }

    /// <summary>
    /// This function selects a random spawnpoint from the array of available spawnpoints
    /// and instantiates a hazards prefab at that spawnpoint.
    /// </summary>
    void SpawnHazardAtRandomSpawnPoint()
    {
        Transform randomSpawnpoint = spawnpointTransforms[Random.Range(0, spawnpointTransforms.Length)];
        GameObject randomHazard = hazardPrefabs[Random.Range(0, hazardPrefabs.Length)];
        GameObject spawnedObject = Instantiate(randomHazard, randomSpawnpoint.position, Quaternion.identity);
        DontDestroyOnLoad(spawnedObject);
    }

    IEnumerator InitialSpawnTimeDelay(float delay)
    {
        Debug.Log("4");
        yield return new WaitForSeconds(delay);
        initialSSpawnDelayCompleted = true;
    }

    public void SlowDownAndStop()
    {
      //  StartCoroutine(SlowDownCoroutine());
        initialSpawnTime = 999999;

    }
}
