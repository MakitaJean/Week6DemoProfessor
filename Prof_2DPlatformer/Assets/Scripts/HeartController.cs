using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    SpriteRenderer myRend;
    BoxCollider2D myTrig;

    public int healthVal;

    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<SpriteRenderer>();
        myTrig = GetComponent<BoxCollider2D>();
    }

    public void hide() {
        myRend.enabled = false;
        myTrig.enabled = false;
    }
}
