using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    [SerializeField] Item Item;
    public void Change()
    {

        Hand.Instance.OnHandChange(Item);
        Debug.Log("sa");
    }
    
}
