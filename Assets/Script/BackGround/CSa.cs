using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSa : MonoBehaviour
{
    [SerializeField] GameObject screen;
    [SerializeField] GameObject lookButton;
    bool a=  false;

    public void screenPopUp()
    { if (a) exitScreen(); else 
        {
        SoundManager.Instance.PlaySFX(10);
        screen.SetActive(true);
        lookButton.SetActive(false);
            a = true;
        }

    }

    public void exitScreen()
    {
        screen.SetActive(false);
        lookButton.SetActive(true);
        a = false;
    }
}
