using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item")]

public class SOCust : ScriptableObject
{
    [SerializeField] int N;
    public SOcustIn[] s;
    public Customer[] cust;
    public Customer[] Ncust;

    private void OnEnable()
    {
        int k = 0;
        cust=new Customer[s.Length];
        Ncust = new Customer[N];
        for (int i = 0; i < s.Length; i++) 
        {
            cust[i].name = s[i].Custname;   
            cust[i].items = s[i].items;
            cust[i].Nitems = s[i].Nitems;
            if (s[i].is_N) 
            {
                Ncust[k++] = cust[i];
            }
        }
    }
    public Customer[] GetCustomer(bool N) 
    {
        if (N) { return cust; }
        else return Ncust;
    }
}
