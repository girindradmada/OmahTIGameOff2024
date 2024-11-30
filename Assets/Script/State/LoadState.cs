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
    [SerializeField] TMP_Text EndlessButton;
    [SerializeField] TMP_Text Score;
    [SerializeField] State state;

    private void Start()
    {
        state = State.Instance;
        SoundManager.Instance.ChangeBGM(0);
        sentence.text = text[state.cause];
        if (state.won)
        {
            SoundManager.Instance.PlaySFX(14);
            sentenceButton.text = "Next";
            State.Instance.day += 1;
            State.Instance.day %= 6;
        }
        else 
        {
            SoundManager.Instance.PlaySFX(5);
        sentenceButton.text = "Retry";
        }

        if (State.Instance.endless)
        {
            Score.text = "You have survived for " + state.day + " day\nYour Score is " + state.score + " that is quite impresive one way or another\nbut alas in the end you are still a human that will make mistake\nAnd This Is a last message For U";
            sentenceButton.transform.parent.gameObject.SetActive(false);
            MainMenuButton.transform.parent.gameObject.SetActive(false);
            EndlessButton.transform.parent.gameObject.SetActive(true);
        }
    }
        public void Next()
        {
            SceneManager.LoadScene("Stage" + State.Instance.day);
        }
        public void MainMenu()
        {
            SceneManager.LoadScene("Stage0");
        }

}
