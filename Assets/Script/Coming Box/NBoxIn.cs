using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBoxIn : MonoBehaviour
{
    [SerializeField]int[] Nitems;
    public bool on_top;
    [SerializeField]float click_time;
    [SerializeField]float close_time=0;
    [SerializeField]bool still_hit=false;
    [SerializeField] Sprite Close;
    [SerializeField] Sprite Open;
    [SerializeField] SpriteRenderer SR;
    bool is_open;
    public void Activated(int[] N) 
    {
        SR.sprite = Close;
        Nitems = N;
        gameObject.SetActive(true);
    }
    public void Switch(NBoxIn S) 
    {
    S.Activated(Nitems);
    gameObject.SetActive (false);
    }
    public void OpenBox() 
    {
    still_hit = true;
    click_time = 0;
    }
    public void OpenTheBox()
    {
        close_time = 3;
        SR.sprite = Open;
    }
    public void CloseTheBox()
    {
        SR.sprite = Close;
    }
    private void FixedUpdate()
    {
        if (still_hit) 
        { 
        if(Input.GetButton("Fire1"))
        {
        click_time += Time.deltaTime;
            if (click_time > 1) 
            {
                click_time = 0;
                Gamemanager.Instance.Nbox.GOOn(Close,this);
                still_hit=false;
                gameObject.SetActive(false);
            }
        }
        if (Input.GetButtonUp("Fire1")) 
        {
            if (click_time < 1) 
            {OpenTheBox();
             still_hit = false;
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
