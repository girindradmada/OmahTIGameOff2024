using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (imistake > 0) { Debug.Log("You ake a mistake in order"); }//Call Ui 
            if (Nmistake > 0) { Debug.Log("You ake a mistake in SPECIAL order"); }//Call UI
        }
    }
}
