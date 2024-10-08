using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    SpriteRenderer myRend;
    BoxCollider2D myTrig;
    
    InventoryManager invMgr;

    // Start is called before the first frame update
    public virtual void Start()
    {
        myRend = GetComponent<SpriteRenderer>();
        myTrig = GetComponent<BoxCollider2D>();

        invMgr = GameObject.Find("Inventory").GetComponent<InventoryManager>();
    }

    public virtual void hide() {
        myRend.enabled = false;
        myTrig.enabled = false;
    }

    public virtual void pickUp() {
        hide();
        invMgr.buildIcon(gameObject);
    }
}
