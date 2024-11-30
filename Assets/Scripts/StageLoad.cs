using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageLoad : MonoBehaviour
{
    public void LoadStage() 
    {
        State.Instance.day = 0;
        State.Instance.endless = false;
        SceneManager.LoadScene("Stage1");
    }
    public void LoadEndless() 
    {
        State.Instance.day = 0;
        State.Instance.endless = true;
        SceneManager.LoadScene("Endless");
    }
}
