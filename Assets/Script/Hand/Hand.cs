using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hand : MonoBehaviour
{

    private static Hand _instance;
    public Camera _camera;
    [SerializeField] GameObject[] jatuh;
    [SerializeField] GameObject jat;
    [SerializeField] int at;
    public Customer[] customers;
    public Customer[] Ncustomers;
    public int current = 0;
    public bool is_endless;
    [SerializeField] Item hand;
    [SerializeField] GameObject OnHand;
    [SerializeField] SpriteRenderer HandRenderer;
    [SerializeField] bool full;
    [SerializeField] Box Box;
    [SerializeField] int Ntype = 7;
    [SerializeField] int itype = 8;
    [SerializeField] Loader loader;
    [SerializeField] int emplo;
    [SerializeField] int cctv;
    [SerializeField] drugClientsHandler Nlist;
    public bool done = false;
    public int stage = 1;
    [SerializeField]bool cantake=false;
    public static Hand Instance { get { return _instance; } }
    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    private void Start()
    {
        jatuh = new GameObject[10];
        for (int i = 0; i < 10; i++)
        {
            jatuh[i] = Instantiate(jat, transform);
        }
        OnHand.SetActive(false);
        stage = 0;
        NewDay();
        SoundManager.Instance.ChangeBGM(1);
    }
    public void NewDay()
    {
        current = 0;
        if (is_endless)
        { Load(); stage++; UIManager.Instance.dayChange(stage); }
        else { StageLoad(); }
        UIManager.Instance.nextTopScreenText(customers[current]);

    }
    private void OnDestroy()
    {
        _instance = null;
    }

    public void OnHandChange(Item item)
    {
        hand = item;
        HandRenderer.sprite = hand.sprite;
        HandRenderer.color = Color.white;
        OnHand.SetActive(true);
    }
    private void FixedUpdate()
    {

        var mouseWorldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        OnHand.transform.position = mouseWorldPos;
    }
    private void Update()
    {
        HandleChange();
        HandleClose();
    }
    void HandleChange()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit2D hit = Physics2D.Raycast(OnHand.transform.position - Vector3.back * 2, OnHand.transform.position + Vector3.back * 2);
            if (hit)
            {
                if (hit.collider.TryGetComponent<Tray>(out Tray T)&&cantake)
                {
                    T.Change();
                    full = true;
                }
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            if (full)
            {
                HandleJatuh(hand);
                OnHand.SetActive(false);
            }
        }
    }
    public void ItemEnter(Item a)
    {
        if (a.Normal)
            customers[current].items[a.ItemInt]--;
        else
            customers[current].Nitems[a.ItemInt]--;
    }
    void Load()
    {
        loader.Change(10 + 3 * stage / 10, 5 + stage / 5, 1, 1 + stage / 5, 1, 1 + stage / 5);
        emplo = 1 + stage / 3;
        cctv = 1 + stage / 4;
        Gamemanager.Instance.WHandler.Set(emplo, cctv);
        StartCoroutine(wait(customers));
        UIManager.Instance.startTimer(169 + stage * 3);
        Nlist.getNCustomers(Ncustomers);
    }
    void StageLoad()
    {
        stage = State.Instance.day;
        customers = Gamemanager.Instance.CustomerScripO.GetCustomer(true);
        Ncustomers = Gamemanager.Instance.CustomerScripO.GetCustomer(false);
        Gamemanager.Instance.WHandler.Set(emplo, cctv);
        Nlist.getNCustomers(Ncustomers);
    }
    void HandleClose()
    {
        if (Input.GetButtonDown("Jump") && !Box.loading)
        {
            Box.Close();
            if (current + 1 < customers.Length)
            {
                current = current + 1;
                UIManager.Instance.nextTopScreenText(customers[current]);
            }
            else
            {
                done = true;
                CheckScore();
            }
        }

    }
    void CheckScore()
    {

        for (int i = 0; i < customers.Length; i++)
        {
            bool wrong1 = false;
            bool wrong2 = false;
            for (int j = 0; j < itype; j++)
            {
                if (customers[i].items[j] != 0) { wrong1 = true; break; }

            }
            for (int j = 0; j < Ntype; j++)
            {
                if (customers[i].Nitems[j] != 0) { wrong2 = true; break; }

            }
            Gamemanager.Instance.Hasil(wrong1, wrong2);
        }
    }
    IEnumerator wait(Customer[] a)
    {
        while (a == null)
        {
            yield return 0.1f;
        }
    }
    public void HandleJatuh(Item hand)
    {
        jatuh[at].GetComponent<Jatuh>().Item = hand;
        jatuh[at].transform.position = OnHand.transform.position;
        jatuh[at].SetActive(true);
        at += 1;
        if (at > 9) at = 0;
        full = false;
    }
    public void take(bool a)
        {
        cantake = a;
        }
}
public struct Customer 
{
    public string name;
    public int[] items;
    public int[] Nitems;
}
