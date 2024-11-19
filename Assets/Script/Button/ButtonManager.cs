using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]Transform pla;
    bool isunder;
    public void ToUnder()
    {
        if (isunder)pla.position +=Vector3.up*10;
        else pla.position += Vector3.down * 10;
        isunder = !isunder;
       
    }
}
