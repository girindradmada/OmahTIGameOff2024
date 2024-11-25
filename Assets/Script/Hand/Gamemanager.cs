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
        Debug.Log(imistake + " " + Nmistake);
    }
}
