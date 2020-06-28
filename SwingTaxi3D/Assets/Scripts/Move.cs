using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    bool RightDown, LeftDown;
    [SerializeField] float TouchDegreeIncrease = 50f;
    [SerializeField] float SwingMin, Swingmax;
    [HideInInspector]
    public float YDegree;
    [HideInInspector]
    public int FrameCounter;
    float SwingForce;
    int SwingAxis;
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        //InvokeRepeating("ChangeAxis", 4f, 4f);
        ChooseAxis();
    }
    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FrameCounter++;
        #region Changing taxi rotation each frame
        if (RightDown)
        {
            YDegree += TouchDegreeIncrease;
        }
        else if (LeftDown)
        {
            YDegree -= TouchDegreeIncrease;

        }
        //Swing Axis
        YDegree += SwingAxis * Random.Range(SwingMin, Swingmax);
        transform.rotation = Quaternion.Euler(0, YDegree, 0);
        #endregion
        #region Changing MoveAxis by Degree or Time
        if (YDegree >= 17f || YDegree <= -17f) { ChangeAxis(); FrameCounter = 0; }
        else if (FrameCounter % 250 == 0) { ChangeAxis(); }
        #endregion


        //Moving Forward
        rb.velocity = transform.forward * 15f;

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

    void ChooseAxis()
    {
        SwingAxis = Random.Range(0, 2) == 0 ? -1 : 1;
    }
    public void ChangeAxis()
    {
        SwingAxis = SwingAxis == -1 ? 1 : -1;
    }



}
