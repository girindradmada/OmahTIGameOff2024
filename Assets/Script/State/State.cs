using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class State : MonoBehaviour
{
    private static State _instance;
    public static State Instance { get { return _instance; } }
    public bool won;
    public int cause;
    public bool endless;
    public int day;
    public int score;
    public string Name;
    public int Score; 
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
        DontDestroyOnLoad(gameObject);
    }
   }
