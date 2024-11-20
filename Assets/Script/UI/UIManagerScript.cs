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

    private void Awake()
    {
        if(_instance)
        {
            Destroy(gameObject);
        } else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        creditBar = GameObject.Find("Credit Bar");
        creditBarHandler = creditBar.GetComponent<CreditBarHandler>();

        susBar = GameObject.Find("Sus Bar");
        susBarHandler = susBar.GetComponent<SusBarHandler>();
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
