using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    [SerializeField] Item Item;
    public void Change()
    {//this is chaos
        if(Item.ItemInt==1) SoundManager.Instance.PlaySFX(12);
        else 
        if(Item.ItemInt==6) SoundManager.Instance.PlaySFX(11);
        Hand.Instance.OnHandChange(Item);
    }
    
}
