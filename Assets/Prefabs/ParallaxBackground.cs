using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    public float scrollSpeed = 0.5f;
    public SpriteRenderer[] backgroundSprites;

    private float spriteHeight;

    void Start()
    {
        spriteHeight = backgroundSprites[0].bounds.size.y;
        PositionSprites();
    }

    void Update()
    {
        foreach (var sprite in backgroundSprites)
        {
            // Move each sprite downwards
            sprite.transform.Translate(0, -scrollSpeed * Time.deltaTime, 0);

            // If a sprite goes below a certain point, it's repositioned to the top
            if (sprite.transform.position.y < -spriteHeight)
            {
                Vector3 newPos = sprite.transform.position;
                newPos.y += spriteHeight * backgroundSprites.Length;
                sprite.transform.position = newPos;
            }
        }
    }

    private void PositionSprites()
    {
        for (int i = 0; i < backgroundSprites.Length; i++)
        {
            Vector3 position = new Vector3(0, i * spriteHeight, 0);
            backgroundSprites[i].transform.position = position;
        }
    }
}
