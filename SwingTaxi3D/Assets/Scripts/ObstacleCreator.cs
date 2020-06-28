using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    [SerializeField] GameObject[] ObstaclePrefab;
    [SerializeField] Transform Finish;
    float xPos;
    float zPos = 10f;
    private void OnEnable()
    {
        CreateObstacle();
    }
    private void OnDisable()
    {
        ClearAllObstacle();
    }

    void CreateObstacle()
    {
        Instantiate(ObstaclePrefab[Random.Range(0,ObstaclePrefab.Length)],this.transform);
    
    }
    void ClearAllObstacle()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}

    #region  OldCodes
    // for (int i = 0; i < 50; i++)
        // {
        //     xPos = Random.Range(0, 2) == 0 ? Random.Range(1.5f, 2.5f) : Random.Range(6.5f, 8f);
        //     zPos += Random.Range(5, 10);
        //     if (zPos > Finish.position.z) { break; }
        //     Transform tempObs = Instantiate(ObstaclePrefab, new Vector3(xPos, -1.9f, zPos), Quaternion.identity).transform;
        //     tempObs.parent = this.transform;
        // }
        // xPos = 0;
        // zPos = 10f;
        #endregion
