using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : MonoBehaviour
{
    System.Random rand;
    public int Number;
    [SerializeField]float StartSee;
    float SeeTime;
    float WalkTime;
    [SerializeField]float WalkAgain;
    float walk;
    bool SEE;
    bool startwalking;
    bool HasSee;
    bool FromLeft;
    bool call;
    [SerializeField]Sprite looking;
    [SerializeField]Sprite walking;
    [SerializeField]SpriteRenderer RD;
    // Start is called before the first frame update
    void Awake()
    {
        rand = Gamemanager.Instance.rand;
        Randomize();
    }

    void Randomize() 
    {
        WalkAgain=rand.Next(30)+10*Number;
        Number = rand.Next(4)+1;
        WalkTime=5+rand.Next(20);
        StartSee=rand.Next((int)WalkTime-2)+1;
        SeeTime=rand.Next(30)/3;
        SEE = false;
        HasSee=false;
        startwalking = false;
        FromLeft= rand.Next(4) % 2 == 1;
        walk = 20 / WalkTime/transform.localScale.x;
        if(!FromLeft)walk=-walk;
        call = false;
    }
    private void FixedUpdate()
    {
        if (!startwalking)
        {
            WalkAgain -= Time.deltaTime;
            if (WalkAgain <= 0)
            {
                startwalking = true;
                Vector3 po = transform.position;
                if (FromLeft) po.x = -10;
                else po.x = 10;
                po.y = 0;
                transform.position = po;
                RD.sprite = walking;
            }
            else if (WalkAgain <= 3&&!call)
            {
                call = true;
                Coroutine showWarning = StartCoroutine(UIManager.Instance.warningCoroutine(0, FromLeft ? new Vector2(-9, 0) : new Vector2(9, 0), 3));
            }

        }
        else
        if (startwalking && !SEE)
        {
            if (StartSee > 0)
            {
                StartSee -= Time.deltaTime;
                transform.position += Vector3.right * walk * Time.deltaTime;
                WalkTime -= Time.deltaTime;
            }
            else
            if (StartSee <= 0 && !HasSee)
            {

                if (Gamemanager.Instance.seen_time < SeeTime)
                {
                    Gamemanager.Instance.seen_time = SeeTime;     
                    Gamemanager.Instance.is_seen = true;                    
                }

                SEE = true;
                RD.sprite = looking;
            }
            else
            {
            WalkTime -= Time.deltaTime;
                transform.position += Vector3.right * walk * Time.deltaTime;
            } 
        }
        else if(SEE) 
        {
            SeeTime -= Time.deltaTime;
            if (SeeTime < 0) 
            {
                HasSee = true;
            SEE=false;
            RD.sprite = walking;
            }
        }
        if (WalkTime <= 0) 
        {
        transform.position += Vector3.up*20;
        Randomize();
        }
    }
}
