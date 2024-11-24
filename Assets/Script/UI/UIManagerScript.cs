using UnityEngine;

public class UIManager : MonoBehaviour 
{
    public static UIManager _instance;
    public static UIManager Instance{ get { return _instance; } }

    public static GameObject creditBar;
    public static CreditBarHandler creditBarHandler;
    public static float creditHealth = 100;

    public static GameObject susBar;
    public static SusBarHandler susBarHandler;
    public static float susAmount = 0;

    public static int[] drugOrderAmount;

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
        creditBar = GameObject.Find("Credit Bar");
        creditBarHandler = creditBar.GetComponent<CreditBarHandler>();

        susBar = GameObject.Find("Sus Bar");
        susBarHandler = susBar.GetComponent<SusBarHandler>();

        drugOrderAmount = new int[5];
        for(int i = 0; i < drugOrderAmount.Length; i++)
        {
            drugOrderAmount[i] = 0;
        }
    }

    public static void creditUpdate(float scoreUpdate)
    {
        creditBarHandler.creditScore(scoreUpdate);
    }

    public static void susUpdate(float scoreUpdate)
    {
        susBarHandler.susScore(scoreUpdate);
    }


}
