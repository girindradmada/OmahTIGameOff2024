using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SusBarHandler : MonoBehaviour
{
    [SerializeField] Image bar;
    [SerializeField] float waitTime = 2;

    private Coroutine susCoroutine;
    [SerializeField] bool waitOver;
    [SerializeField] float susDepleteAmount = 1;
    

    //public float temp = 0;

    private void Start()
    {
        bar = GetComponent<Image>();
        waitOver = false;
    }

    public void susScore(float addscore)
    {
        UIManager.susAmount += addscore;
        bar.fillAmount = UIManager.susAmount/100;

        //temp += addscore;
        //bar.fillAmount = temp / 100;

        if (susCoroutine != null)
        {
            StopCoroutine(susCoroutine);
            susCoroutine = null;
        }

        susCoroutine = StartCoroutine(wait());
        waitOver = false;
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(waitTime);
        waitOver = true;
    }

    private void FixedUpdate()
    {
        if(waitOver && UIManager.susAmount > 0)
        {
            UIManager.susAmount -= susDepleteAmount;
            bar.fillAmount = UIManager.susAmount / 100;

            if (UIManager.susAmount <= 0)
            {
                waitOver = false;
            }
        }
    }
}
