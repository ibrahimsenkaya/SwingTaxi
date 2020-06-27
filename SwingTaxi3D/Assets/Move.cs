using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    public bool RightDown, LeftDown;
    [SerializeField] float DegreeIncrease = 10f;
    public float YDegree;
    int FrameCounter;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FrameCounter++;
        if (RightDown)
        {
            YDegree += DegreeIncrease;
        }
        else if (LeftDown)
        {
            YDegree -= DegreeIncrease;

        }
        transform.rotation = Quaternion.Euler(0, YDegree, 0);
        rb.velocity = transform.forward * 15f;
        if (FrameCounter % 100 <= 50)
        {
            rb.AddForce(transform.right * Random.Range(25, 50));
        }
        else
        {
            rb.AddForce(transform.right * -Random.Range(25, 50));
        }
    }


    public void RightClickDown()
    {
        RightDown = true;
    }
    public void RightClickUp()
    {
        RightDown = false;
    }
    public void LeftClickDown()
    {
        LeftDown = true;
    }
    public void LeftClickUp()
    {
        LeftDown = false;
    }

   
}
