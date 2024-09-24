using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myBod;
    public int health;
    public float speed;
    public float jumpSpeed;
    public int maxJumps;
    private int jumpsLeft;


    private GameObject[] allHearts;
    private int heartCount;

    // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody2D>();
        jumpsLeft = 10;

        allHearts = GameObject.FindGameObjectsWithTag("Heart");
        heartCount = allHearts.Length;
        print("Game starts with " + heartCount + " hearts");
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

    void OnTriggerEnter2D(Collider2D other) {
        GameObject otherGO = other.gameObject;
        if(otherGO.name == "Ground") {
            jumpsLeft = maxJumps;
        }
        else if(otherGO.tag == "Heart") {
            HeartController heartCon = otherGO.GetComponent<HeartController>();
            heartCon.hide();
            health += heartCon.healthVal;
        }
    }
}
