using UnityEngine.UI;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    Move movingScript;
    Rigidbody rb;
    public float FearMeter;
    [SerializeField] Image FearMeterImage;
    [SerializeField] float FearMeterMax;
    [SerializeField] IS_VoidEvent FailEvent, FinishEvent;

    private void Awake()
    {
        movingScript = GetComponent<Move>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WallRight")
        {
            CheckFearMeter();
            rb.AddForce(transform.right * -700);
            movingScript.YDegree = 0;
            transform.rotation = Quaternion.Euler(0, 0, 0);

            Debug.Log("girdi");
        }
        if (other.tag == "WallLeft")
        {
            CheckFearMeter();
            rb.AddForce(transform.right * 700);
            movingScript.YDegree = 0;
            transform.rotation = Quaternion.Euler(0, 0, 0);

            Debug.Log("girdi");
        }
        if (other.tag == "Obstacle")
        {
            Debug.Log("obstacle");
            CheckFearMeter();
        }
        if (other.tag == "Finish")
        {

            FinishEvent.Raise();
        }
    
    }

    void CheckFearMeter()
    {
        FearMeter += 5f;
        FearMeterImage.fillAmount = FearMeter / FearMeterMax;
        if (FearMeter >= FearMeterMax)
        {
            FailEvent.Raise();
        }
    }
}
