using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myBod;
    ParticleSystem myPart;
    AudioSource myAudio;
    Animator myAnim;

    InventoryManager invMgr;

    public int health;
    public float speed;
    public float jumpSpeed;
    public int maxJumps;
    private int jumpsLeft;

 // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody2D>();
        myPart = GetComponent<ParticleSystem>();
        myAudio = GetComponent<AudioSource>();
        myAnim = GetComponent<Animator>();

        invMgr = GameObject.Find("Inventory").GetComponent<InventoryManager>();

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
            myPart.Play();
            myAudio.Play();
            v.y = jumpSpeed;
            jumpsLeft--;
        }

        myBod.velocity = v;

        //animation and direction
        if(h > 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if (h < 0){
            transform.localScale = new Vector3(1, 1, 1);
        }
        myAnim.SetBool("RUNNING", h!=0);

        if(Input.GetButtonDown("Fire1")) {
            myAnim.SetTrigger("ATTACKING");
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        
        GameObject otherGO = other.gameObject;
        if(otherGO.name == "Ground" || otherGO.name == "Ground(1)") {
            jumpsLeft = maxJumps;
        }
        else if(otherGO.tag == "PickUpAble") {
            PickUpController puCon = otherGO.GetComponent<PickUpController>();
            puCon.pickUp();
           
        }
    }
}
