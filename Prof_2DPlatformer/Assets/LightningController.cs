using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : PickUpController
{  
    public int speedVal;

    // Start is called before the first frame update
    public override void invClick(GameObject invIconGO)
    {
        base.invClick(invIconGO);//Tells game to do the all the basics in pickupcontroller needs to be run
        // heal the player.
        PlayerController p = GameObject.FindGameObjectWithTag("Player")
            .GetComponent<PlayerController>();

        p.speed = p.speed * 2;
    }
}
