using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item")]

public class SOcustIn : ScriptableObject
{
    public string Custname;
    public int[] items=new int[1];
    public int[] Nitems = new int[1];
    public bool is_N;
}
