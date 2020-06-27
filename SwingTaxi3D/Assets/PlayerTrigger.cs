using UnityEngine.UI;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    Move movingScript;
    Rigidbody rb;
    float FearMeter;
    [SerializeField]Image FearMeterImage;
    [SerializeField] float FearMeterMax;

    private void Awake()
    {
        movingScript = GetComponent<Move>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WallRight")
        {
            rb.AddForce(transform.right * -700);
            movingScript.YDegree = 0;
            transform.rotation = Quaternion.Euler(0, 0, 0);

            Debug.Log("girdi");
        }
        if (other.tag == "WallLeft")
        {
            rb.AddForce(transform.right * 700);
            movingScript.YDegree = 0;
            transform.rotation = Quaternion.Euler(0, 0, 0);

            Debug.Log("girdi");
        }
        if (other.tag == "Obstacle")
        {
            Debug.Log("obstacle");
            FearMeter += 5f;
            FearMeterImage.fillAmount=FearMeter/FearMeterMax;
            if (FearMeter >= FearMeterMax)
            {
                //levelEnd
            }
        }
    }
}
