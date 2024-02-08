using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairManager : MonoBehaviour
{
    public Image crosshairImage;
    public SpriteRenderer crosshairSpriteRenderer;

    private void Start()
    {
        Cursor.visible = false;
       // SetCrosshair();
    }

    private void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        Vector2 mousePos = Input.mousePosition;

        Vector2 crosshairPos = Camera.main.ScreenToWorldPoint(mousePos);

        crosshairSpriteRenderer.transform.position = crosshairPos;
    }

    //private void SetCrosshair()
    //{
    //    crosshairImage.sprite = crosshairSprite;
    //}

}
