using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCollisionSound : MonoBehaviour
{
    private Camera mainCamera;
    public AudioSource audioSource;


    private void Start()
    {
        mainCamera = Camera.main; // Assuming there's only one main camera
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Check if the object is visible by the main camera
        //if (IsObjectVisible(collision.gameObject))
       // {
            // Play sound only if the object is visible
            audioSource.Play();
        //}
    }

    bool IsObjectVisible(GameObject obj)
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(obj.transform.position);
        // Check if the screenPoint is within the viewport bounds (x and y between 0 and 1)
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
    }
}
