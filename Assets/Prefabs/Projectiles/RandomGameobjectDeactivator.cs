using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGameobjectDeactivator : MonoBehaviour
{
    public GameObject[] gameObjects; // Assign your 6 GameObjects in the Inspector

    void Start()
    {
        // Check if there are enough GameObjects
        if (gameObjects.Length > 0)
        {
            // Select a random index
            int randomIndex = Random.Range(0, gameObjects.Length);

            // Deactivate the selected GameObject
            if (gameObjects[randomIndex] != null)
            {
                gameObjects[randomIndex].SetActive(false);
            }
        }
        else
        {
            Debug.LogError("No GameObjects assigned to the array.");
        }
    }
}
