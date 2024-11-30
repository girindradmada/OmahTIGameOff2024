using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    private static Gamemanager _instance;
    public static Gamemanager Instance { get { return _instance; } }
    public Hand Hand;
    public Loader Loader;
    public int imistake;
    public int Nmistake;
    public Nbox Nbox;
    public SOCust CustomerScripO;
    public bool is_seen;
    public float seen_time;
    public WHandler WHandler;
    public SuperViser SuperViser;
    public System.Random rand;
    public bool isunder;
    public float timer;
    int score;
    int TolerableN;
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
        rand = new System.Random();
        score = 0;
        TolerableN = 15;
    }
    private void OnDestroy()
    {
        _instance = null;
    }
    public void Hasil(bool a, bool b)
    {
        if (a) imistake++;
        if (b) Nmistake++;
    }
    public void FinalizeHasil() 
    {
        if (!Hand.is_endless)
        {
            if (imistake > 0) { Load(2); }
            else
            if (Nmistake > 0) { Load(3); }
            else
            { Load(0); }
        }
        else 
        {
            TolerableN -= Nmistake;
            if (TolerableN <= 0) Load(3);
            UIManager.Instance.creditUpdate(-imistake*3);
            score += (Hand.customers.Length-imistake) * Hand.stage * 5;
            score += (Hand.Ncustomers.Length-Nmistake) * Hand.stage * 10;
            UIManager.Instance.dayChange(Hand.stage+1);
            UIManager.Instance.SetScore(score);
            Hand.NewDay();
        }
    }
    private void FixedUpdate()
    {
        if (is_seen) 
        {
        seen_time -= Time.deltaTime;
        if(seen_time<=0)is_seen = false;        
        }
    }
    public void Load(int why) 
    {
    State.Instance.cause = why;
    if(why==0)State.Instance.won = true;
    else State.Instance.won = false;
    State.Instance.day = Hand.stage;
    State.Instance.endless = Hand.is_endless;
        SceneManager.LoadScene("State");
    }
}
