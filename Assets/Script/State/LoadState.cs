using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadState : MonoBehaviour
{
    public string[] text;
    [SerializeField] TMP_Text sentence;
    [SerializeField] TMP_Text sentenceButton;
    [SerializeField] TMP_Text MainMenuButton;
    [SerializeField] TMP_Text Score;
    [SerializeField] State state;

    private void Start()
    {
        state= State.Instance;
        sentence.text = text[state.cause];
        if (state.won)
        {
            sentenceButton.text = "Next";
            State.Instance.day += 1;
            State.Instance.day %= 6;
        }
        else sentenceButton.text = "Retry";
        if (State.Instance.endless) 
        {
            Score.text = "You have survived for "+state.day+"day \n Your Score is "+state.score+"\n but in the end you are still a human that will make mistake";
            
        }
    }
    public void Next() 
    {
        SceneManager.LoadScene("Stage"+State.Instance.day);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Stage0");
    }

}
