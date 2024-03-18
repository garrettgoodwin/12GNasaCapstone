using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Upgrade : MonoBehaviour
{
    //public int speedUpgradeCost = 50;
    void Start()
    // Start is called before the first frame updatevoid Start()
    {
        //currentSpeed = speedLevel+10;
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
        //currentSpeed = increasedSpeed;
    }

    void OnMouseDown()
    {
        OnTextClick();
    }

}
