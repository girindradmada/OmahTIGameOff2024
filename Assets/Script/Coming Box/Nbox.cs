using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.XR;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.PlayerSettings;

public class Nbox : MonoBehaviour
{
    [ContextMenu("Do Something")]
    void DoSomething()
    {
        int[]v = {4,5,3,2,5};
        Order(v);
    }
    [SerializeField] NBoxIn[] TBox;
    [SerializeField] NBoxIn T1;
    [SerializeField] NBoxIn T2;
    [SerializeField] NBoxIn T3;
    [SerializeField] NBoxIn[] BBox;
    [SerializeField] NBoxIn B1;
    [SerializeField] NBoxIn B2;
    [SerializeField] NBoxIn B3;
    [SerializeField] int topfull=0;
    public int botfull=0;
    System.Random rand=new System.Random();
    int a;
    [SerializeField]Camera cam;
    int l;
    Vector3 Pos;
    [SerializeField] GameObject GO;
    [SerializeField] SpriteRenderer SRGo;
    bool dont_drop=true;
    [SerializeField] Trash Tra;
    public  Queue<Item> NitemList = new Queue<Item>();
    public int iteminq=0;
    [SerializeField] float wait;
    [SerializeField] Rigidbody2D GORB;
    [SerializeField] float In_cooldown=0;
    [SerializeField] float drop_time;
    private void Awake()
    {
        GORB = GO.GetComponent<Rigidbody2D>();
        BBox = new NBoxIn[3];
        TBox = new NBoxIn[3];
        TBox[0] = T1;
        TBox[1] = T2;
        TBox[2] = T3;
        BBox[0] = B1;
        BBox[1] = B2;
        BBox[2] = B3;
        Pos = cam.ScreenToWorldPoint(Input.mousePosition);
        Pos.z = 0;
    }
    public void OrderDef() 
    {
        Order(UIManager.drugOrderAmount);
    }
    public void Order(int[] Nitem) 
    {
        if (In_cooldown > 0) Debug.Log("wait"+(int)In_cooldown);//Call UI
        else
        if (topfull <= 0)
        {
            int[] ints = new int[Nitem.Length];
            int[] ints1 = new int[Nitem.Length];
            int[] ints2 = new int[Nitem.Length];
            for (int i = 0; i < Nitem.Length; i++)
            {
                while (Nitem[i] > 0)
                {
                    Nitem[i]--;
                    a = rand.Next(3);
                    if (a == 0) ints[i]++;
                    else if (a == 1) ints1[i]++;
                    else ints2[i]++;
                }
            }
            TBox[0].Activated(ints);
            TBox[1].Activated(ints2);
            TBox[2].Activated(ints1);
            topfull = 3;
        }
        else Debug.Log("Table Full");//Call UI
        In_cooldown = 120;
        for (int i = 0; i < Nitem.Length; i++) Nitem[i] = 0;
    }
    private void Update()
    {
        HandleChange();
        if (Input.GetButtonUp("Fire1") && GO.activeSelf)
        {
            Physics2D.IgnoreLayerCollision(8, 8, false);
            GORB.gravityScale = 1;
            dont_drop = false;
        }
    }
    private void FixedUpdate()
    {
        Pos = cam.ScreenToWorldPoint(Input.mousePosition);
        Pos.z = 0;
        if(dont_drop)
        GO.transform.position = Pos;
        In_cooldown-=Time.deltaTime;
        drop_time -= Time.deltaTime;
    }
    void HandleChange()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit2D hit = Physics2D.Raycast(Pos - Vector3.back * 2, Pos + Vector3.back * 2);
            if (hit)
            {
                if (hit.collider.TryGetComponent<NBoxIn>(out NBoxIn T))
                {
                    
                    if ( T.on_top)
                    {
                        if (botfull == 3) Debug.Log("Full");//Call UI
                        else
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (!BBox[i].gameObject.activeSelf)
                                {
                                    T = BBox[i];
                                    break;
                                }
                            }
                            for (int i = 0; i < 3; i++)

                            {
                                if (TBox[i].gameObject.activeSelf)
                                {
                                    TBox[i].Switch(T);
                                    botfull++;
                                    topfull--;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    if (!T.on_top)
                    {
                        T.OpenBox();
                    }
                }else
                if (hit.collider.TryGetComponent<Nitem>(out Nitem A))
                {
                    A.GotClick();
                }
            }
            
        }
        if (Input.GetButtonDown("Fire2")) 
        {
            if(drop_time<=0)
            if (NitemList.TryDequeue(out Item ou)) 
            {
            Hand.Instance.HandleJatuh(ou);
                iteminq--;
                drop_time = 1;
            }
        }
    }
    public void GOOn(Sprite s,NBoxIn a)
    {
        SRGo.sprite = s;
        Physics2D.IgnoreLayerCollision(8, 8, true);
        GO.transform.position = Pos;
        dont_drop = true;
        Tra.N = a;
        GORB.gravityScale = 0;
        GO.SetActive(true);
    }
}
