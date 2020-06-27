using UnityEngine;
using UnityEngine.UI;

public class ResetFearmeter : MonoBehaviour
{
 private void OnEnable() {
     GetComponent<Image>().fillAmount=0;
 }
}
