using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Upgrade : MonoBehaviour
{

    // public static int speedLevel = gameManager.speedLevel;
    public static int currentSpeed = 0;

    public int speedUpgradeCost = 50;
    void Start()
    // Start is called before the first frame updatevoid Start()
    {
        currentSpeed = 0;
    }

    void Update()
    {
        // Move the player based on the current speed
        // float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetAxis("Vertical");
        // Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * currentSpeed * Time.deltaTime;
        // transform.Translate(movement);
    }

    public void OnTextClick()
    {
        // Increase speed when the TextMeshPro Text is clicked
        currentSpeed = 20;
    }

    void OnMouseDown()
    {
        OnTextClick();
    }

}
