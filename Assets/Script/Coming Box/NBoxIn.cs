using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBoxIn : MonoBehaviour
{
    public int[] Nitems;
    public bool on_top;
    [SerializeField]float click_time;
    public float close_time=0;
    [SerializeField]bool still_hit=false;
    [SerializeField] Sprite Close;
    [SerializeField] Sprite Open;
    [SerializeField] SpriteRenderer SR;
    bool is_open;
    [SerializeField] Nitem[] nitems;
    [SerializeField]Collider2D coll;
    private void Start()
    {
        nitems = GetComponentsInChildren<Nitem>(true);
    }
    public void Activated(int[] N) 
    {
        Nitems = N;
        gameObject.SetActive(true);
        CloseTheBox();
    }
    public void Switch(NBoxIn S) 
    {
    S.Activated(Nitems);
    gameObject.SetActive (false);
    }
    public void OpenBox() 
    {
        
    still_hit = true;
    OpenTheBox();
    click_time = 0;
        
    }
    public void OpenTheBox()
    {coll.enabled = false;

        close_time = 3;
        SR.sprite = Open;
        is_open = true;
        for (int i = 0; i < nitems.Length; i++) nitems[i].activate();
    }
    public void CloseTheBox()
    {        
        coll.enabled=true;
        is_open=false;
        SR.sprite = Close;
        for (int i = 0; i < nitems.Length; i++) nitems[i].deactivate();
    }
    private void Update()
    {
        if (still_hit) 
        {
            if (Input.GetButtonUp("Fire1")) 
            {
                if (click_time < 1) 
                {
                still_hit=false;
                }
            }
        if(Input.GetButton("Fire1"))
        {
        click_time += Time.deltaTime;
            if (click_time > 1) 
            {
                click_time = 0;
                Gamemanager.Instance.Nbox.GOOn(Close,this);
                still_hit=false;
                for (int i = 0; i < nitems.Length; i++) nitems[i].deactivate();
                CloseTheBox();
                still_hit = false;
                gameObject.SetActive(false);
            }
        }
        }
        if(is_open)close_time-=Time.deltaTime;
        if (close_time <= 0) 
        {
            CloseTheBox();
        }
    }
}
