using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform Taxi;
    float distance;
     private void Awake() {
        distance=transform.position.z-Taxi.position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position=new Vector3(transform.position.x,transform.position.y,Taxi.position.z+distance);
    }
}
