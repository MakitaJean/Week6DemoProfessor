using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public float speed;
    public Vector3 vec;

    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 dir;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = startPos + vec;
        distance = Vector3.Distance(startPos, endPos);
        dir = vec.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position + (dir * speed * Time.deltaTime);
        if (Vector3.Distance(temp, startPos) < distance)
        {
            transform.position = temp;
        }
        else
        {
            dir = -dir; //reverse direction
        }

    }
}
