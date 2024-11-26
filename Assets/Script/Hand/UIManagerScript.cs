using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour 
{
    public static UIManager _instance;
    public static UIManager Instance{ get { return _instance; } }

    [SerializeField] Canvas _canvas;

    [SerializeField] CreditBarHandler creditBarHandler;
    public static float creditHealth = 100;

    [SerializeField] SusBarHandler susBarHandler;
    public static float susAmount = 0;

    public static int[] drugOrderAmount;
    public static int orderLimit = 10;

    [SerializeField] GameObject[] warningPopUp; //0 employee //1 supervisor //2 cctv

    private void Awake()
    {
        if(_instance)
        {
            Destroy(gameObject);
        } else
        {
            _instance = this;
        }
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    private void Start()
    {
        drugOrderAmount = new int[5];
        for(int i = 0; i < drugOrderAmount.Length; i++)
        {
            drugOrderAmount[i] = 0;
        }
    }

    public void creditUpdate(float scoreUpdate)
    {
        creditBarHandler.creditScore(scoreUpdate);
    }

    public void susUpdate(float scoreUpdate)
    {
        susBarHandler.susScore(scoreUpdate);
    }

    public IEnumerator warningCoroutine(int popUpIndex, Vector2 popUpPostion, float waitTime)
    {
        GameObject popUp = Instantiate(warningPopUp[popUpIndex], _canvas.transform);

        RectTransform rectTransform = popUp.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = popUpPostion;

        yield return new WaitForSeconds(waitTime);
        Destroy(popUp);
    }
}
