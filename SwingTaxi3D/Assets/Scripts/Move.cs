using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    bool RightDown, LeftDown;
    [SerializeField] float DegreeIncrease = 50f;
    [HideInInspector]
    public float YDegree;
    int FrameCounter;
    float SwingForce;
    int SwingAxis;
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("ChooseAxisAndForce", 2f, 1f);
    }
    private void OnDisable() {
        rb.velocity=Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FrameCounter++;
        #region Changing taxi rotation each frame
        if (RightDown)
        {
            YDegree += DegreeIncrease;
        }
        else if (LeftDown)
        {
            YDegree -= DegreeIncrease;

        }
        transform.rotation = Quaternion.Euler(0, YDegree, 0);
        #endregion

        //Moving Forward
        rb.velocity = transform.forward * 15f;
        rb.AddForce((SwingAxis*transform.right)*SwingForce);

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

    void ChooseAxisAndForce()
    {
        SwingForce = Random.Range(50, 150);
        SwingAxis = Random.Range(0, 2) == 0 ?  -1:1;
    }

    

}
