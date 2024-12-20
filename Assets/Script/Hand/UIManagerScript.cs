using System.Collections;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour 
{
    public static UIManager _instance;
    public static UIManager Instance{ get { return _instance; } }

    [SerializeField] Gamemanager gamemanager;

    [SerializeField] Canvas _canvas;

    [SerializeField] public Item[] listOfDrugs;
    [SerializeField] public Item[] listOfItems;

    [SerializeField] CreditBarHandler creditBarHandler;
    public static float creditHealth = 100;

    [SerializeField] SusBarHandler susBarHandler;
    public static float susAmount = 0;

    public static int[] drugOrderAmount;
    public static int orderLimit = 10;

    [SerializeField] GameObject[] warningPopUp; //0 employee //1 supervisor //2 cctv

    [SerializeField] TextMeshPro topScreenText;

    [SerializeField] TextMeshPro computerMessage;
    [SerializeField] TextMeshPro timerText;
    public static float timerValue;
    public static Coroutine timer;

    [SerializeField] TextMeshProUGUI dayText;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        if(_instance)
        {
            Destroy(gameObject);
        } else
        {
            _instance = this;
        }

        connectManagers();
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    private void connectManagers()
    {
        GameObject _handObject = GameObject.FindGameObjectWithTag("Hand");

        if (_handObject != null)
        {
            gamemanager = _handObject.GetComponent<Gamemanager>();
        }
        else
        {
            Debug.Log("hah?");
        }
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
    public void nextTopScreenText(Customer cus)
    {
        topScreenText.text = cus.name + "\n\n";
        
       for(int i = 0; i < listOfItems.Length; i++)
        {
            if (cus.items[i] > 0)
            {
                if (cus.items[i] > 1)
                {
                    topScreenText.text += cus.items[i].ToString() + " ";
                }

                topScreenText.text += listOfItems[i].TheName;
                if (i<listOfItems.Length-1)
                if (cus.items[i + 1] > 0)
                {
                    topScreenText.text += ", ";
                }
            }
        }
    }

    public void showMessage(string message)
    {
        computerMessage.text = message;
        Coroutine wait = StartCoroutine(messageCoroutine(3));
    }

    private IEnumerator messageCoroutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        computerMessage.text = "";
    }

    public void startTimer(float time)
    {
        timerText.text = time.ToString();
        timer = StartCoroutine(timerCoroutine());
    }

    private IEnumerator timerCoroutine()
    {
        while(float.TryParse(timerText.text, out timerValue) && timerValue > 0)
        {
            yield return new WaitForSeconds(1);
            timerValue--;
            if (timerValue <= 0) Hand.Instance.NewDay();
            timerText.text = timerValue.ToString();
        }
    }

    public void stopTimer()
    {
        if (timer != null)
        {
            StopCoroutine(timer);
            timer = null;
        }
    }

    public void dayChange(int day)
    {
        dayText.text = "Day " + day.ToString();
    }

    public void SetScore(int add)
    {
        scoreText.text = add.ToString();
    }
}
