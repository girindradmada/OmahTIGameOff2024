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
    [SerializeField] State state;

    private void Awake()
    {
        state= GameObject.FindWithTag("State").GetComponent<State>();
        sentence.text = text[state.cause];
        if (state.won)
        {
            sentenceButton.text = "Next";
            State.Instance.day += 1;
            State.Instance.day %= 7;
        }
        else sentenceButton.text = "Retry";
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
