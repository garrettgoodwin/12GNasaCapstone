using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class chooseSprite : MonoBehaviour
{
    public SpriteLibrary spriteLibrary;
    public SpriteLibraryAsset[] shipRefs;

    //the variables in the Animator determine what sprite the player ship is 
    [SerializeField] private Animator playerMovementAnims;


    // Update is called once per frame
    // function updates the sprite whenever a variable changes
    void Update()
    {
        //case for armor
        if (playerMovementAnims.GetBool("isArmored") && !playerMovementAnims.GetBool("shieldUp") && !(playerMovementAnims.GetBool("hasBoost") || playerMovementAnims.GetBool("isBoosting")))
        {
            spriteLibrary.spriteLibraryAsset = shipRefs[1];
        }
        //case for armor and shield
        else if (playerMovementAnims.GetBool("isArmored") && playerMovementAnims.GetBool("shieldUp") && !(playerMovementAnims.GetBool("hasBoost") || playerMovementAnims.GetBool("isBoosting")))
        {
            spriteLibrary.spriteLibraryAsset = shipRefs[2];
        }
        //case for boost
        else if (!playerMovementAnims.GetBool("isArmored") && !playerMovementAnims.GetBool("shieldUp") && (playerMovementAnims.GetBool("hasBoost") || playerMovementAnims.GetBool("isBoosting")))
        {
            spriteLibrary.spriteLibraryAsset = shipRefs[3];
        }
        //case for boost armor
        else if (playerMovementAnims.GetBool("isArmored") && !playerMovementAnims.GetBool("shieldUp") && (playerMovementAnims.GetBool("hasBoost") || playerMovementAnims.GetBool("isBoosting")))
        {
            spriteLibrary.spriteLibraryAsset = shipRefs[4];
        }
        //case for boost armor shield
        else if (playerMovementAnims.GetBool("isArmored") && playerMovementAnims.GetBool("shieldUp") && (playerMovementAnims.GetBool("hasBoost") || playerMovementAnims.GetBool("isBoosting")))
        {
            spriteLibrary.spriteLibraryAsset = shipRefs[5];
        }
        //case for boost shield
        else if (!playerMovementAnims.GetBool("isArmored") && playerMovementAnims.GetBool("shieldUp") && (playerMovementAnims.GetBool("hasBoost") || playerMovementAnims.GetBool("isBoosting")))
        {
            spriteLibrary.spriteLibraryAsset = shipRefs[6];
        }
        //case for shiled
        else if (!playerMovementAnims.GetBool("isArmored") && playerMovementAnims.GetBool("shieldUp") && !(playerMovementAnims.GetBool("hasBoost") || playerMovementAnims.GetBool("isBoosting")))
        {
            spriteLibrary.spriteLibraryAsset = shipRefs[7];
        }
        //case for no upgrades (default case)
        else
        {
            spriteLibrary.spriteLibraryAsset = shipRefs[0];
        }
          
    }
}
