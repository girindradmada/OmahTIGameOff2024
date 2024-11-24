using UnityEngine;
using UnityEngine.UI;

public class CreditBarHandler : MonoBehaviour
{ 
    public Image bar;

    private void Start()
    {
        bar = GetComponent<Image>();
    }

    public void creditScore (float addScore)
    {
        UIManager.creditHealth += addScore;
        bar.fillAmount = UIManager.creditHealth/100;
    }

    [ContextMenu("debug")]
    public void debugCreditBar()
    {
        creditScore(-10);
    }
}
