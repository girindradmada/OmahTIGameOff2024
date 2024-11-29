using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]Transform pla;
    bool isunder;
    float SUS=3;
    public void ToUnder()
    {
        if (isunder)
        {
            pla.position += Vector3.up * 10.8f;
            Gamemanager.Instance.isunder = false;
            isunder = false;
        }

        else 
        {
        pla.position += Vector3.down * 10.8f;
            Gamemanager.Instance.isunder = true;
            isunder = true;
        } 
        SUS = 3;
    }
    private void FixedUpdate()
    {
        if (isunder) 
        {
        SUS-=Time.deltaTime;
            if (SUS <= 0) 
            {
                UIManager.Instance.susUpdate(1);
                SUS = 3;
            }        
        }

    }
}
