using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTaxiSituation : MonoBehaviour
{
    [SerializeField] BoxCollider ClearCollider;
    public void GameOver()
    {
        GetComponent<Move>().enabled = false;

    }
    public void Retry()
    {
        GetComponent<PlayerTrigger>().FearMeter = 0;
        transform.position = new Vector3(4.5f, -1.9f, -11f);
        ClearCollider.enabled=true;
        GetComponent<Move>().enabled = true;
    }
}
