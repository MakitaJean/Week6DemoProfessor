using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myBod;
    public float speed;

    public float jumpSpeed;
    public int maxJumps;
    private int jumpsLeft;


    // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody2D>();
        jumpsLeft = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = myBod.velocity;
        float h = Input.GetAxis("Horizontal");

        //move
        v.x = h * speed;

        //jump
        if(jumpsLeft > 0 && Input.GetButtonDown("Jump")) {
            v.y = jumpSpeed;
            jumpsLeft--;
        }

        myBod.velocity = v;
    }

    void OnTriggerStay2D(Collider2D other) {
        GameObject otherGO = other.gameObject;
        if(otherGO.name == "Ground") {
            jumpsLeft = maxJumps;
        }
    }
}
