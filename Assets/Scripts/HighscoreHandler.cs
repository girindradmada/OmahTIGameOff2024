using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System;


public class HighscoreHandler : MonoBehaviour {
    [ContextMenu("sa")]
    void a () 
    {
    NewFile("Test",1,1);    
    }
    [ContextMenu("sas")]
    void b()
    {
        Sort();
    }
    string saveFile;
    [SerializeField] HighscoreUI ui;
    HighscoreElement[] HS;
        private void Awake()
    {
        saveFile = $"{Application.persistentDataPath}/scoreboard";
        HS = new HighscoreElement[8];
        for (int i = 0; i < 8; i++) 
        {
            if (!File.Exists(saveFile+i+".json"))
            {
                StartFile("name",0,0, saveFile + i + ".json");

            }
            HS[i] = Read(saveFile + i + ".json");
        }
        ui.UpdateUI(HS);
    }
    void Start()
    {
        if (State.Instance.endless)
        {
            NewFile(State.Instance.name, State.Instance.day, State.Instance.score);
        }
        Sort();
    }
    private void StartFile(string n,int day,int score,string path)
    {
        HighscoreElement a = new HighscoreElement("name",0,0);
        string json=JsonUtility.ToJson(a);
        File.Create(saveFile).Close();
        Write(json,path);
    }
    HighscoreElement Read(string path) 
    {
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<HighscoreElement>(json);
    }
    void Write(string json, string file) 
    {
        File.WriteAllText(file, json);
    }
    void NewFile(string n, int day, int score) 
    {
        HighscoreElement a = new HighscoreElement(n, day, score);
        string json = JsonUtility.ToJson(a);
        Write(json, saveFile + 7 + ".json");
    }
    void Sort() 
    {
        compare comp = new compare();
        System.Array.Sort(HS, comp);
        ui.UpdateUI(HS);
        for (int i = 0; i < HS.Length; i++)
            Write(JsonUtility.ToJson(HS[i]), saveFile + i + ".json");
    }

}