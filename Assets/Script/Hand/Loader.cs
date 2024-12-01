using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class Loader : MonoBehaviour
{
    System.Random rand = new System.Random();
    [SerializeField] int Ntype = 5;
    [SerializeField] int itype = 8;
    [SerializeField] string[] strings = new string[10];
    public Customer[] All;
    public Customer[] Nark;
    public void Change(int A, int N, int mina,int maxa,int minn,int maxn) 
    {
        All = new Customer[A];
        Nark = new Customer[N];
        NarkRandomizer(minn, maxn);
        Randomize(mina, maxa);
        Hand.Instance.Ncustomers = Nark;
        Hand.Instance.customers = All;
    }
    private void Awake()
    {
        strings=new string[]{"Steve","Mut","Dain","Rome","Zak","Jong","Ren","Huncho","Beta","Uno","Chelsea","Monk","Mirvan","Fian","Garya","Jamal","Bean","Thugger","Sasha","Michael","Schmeeve","Schmunk","Schmouber","Schmaster","Gonk","Bronk","Brunkketunk","Brooke","Gabriel","Bim","Darryl","Drijzy","Aaron","Hector","Loseph","Ken"};
    }
    public void Randomize( int mina, int maxa)
    {
        
        NarkPosition();
        AllRandomizer(mina, maxa);
    }
    public void NarkRandomizer( int min, int max)
    {
        int amount;
        int a;
        for (int i = 0; i < Nark.Length; i++)
        {
            a = 1 + rand.Next(strings.Length);
            if (a == strings.Length) a--;
            Nark[i].name = strings[a];
            
            Nark[i].items = new int[itype];
            Nark[i].Nitems = new int[Ntype];
            amount =min + rand.Next(max);
            for (int j = 0; j < amount; j++)
            {
                a = 1 + rand.Next(itype);
                if (a == itype) a--;
                Nark[i].items[a]++;
            }
            amount = min + rand.Next(max);

            for (int j = 0; j < amount; j++)
            {
                a = 1 + rand.Next(Ntype);
                if (a == Ntype) a--;
                Nark[i].Nitems[a]++;
            }
        }
    }
    void NarkPosition()
    {
        
        int[] ints = new int[Nark.Length];
        for (int i = 0; i < Nark.Length; i++)
        {
            ints[i] = randomn(ints, i, All.Length);
        }
        System.Array.Sort(ints); 
        for (int i = 0; i < Nark.Length; i++)
        {
            All[ints[i]] = Nark[i];
        }
    }
    int randomn(int[] ints, int n, int all)
    {
        
        int a = rand.Next(all);
        for (int i = 0; i < n-1; i++)
        {
            if (a == ints[i]) 
            {
                a = rand.Next(all);
            }
        }
        
        return a;
    }
    void AllRandomizer(int mina,int maxa) 
    {
        int next=0;
        int amount;
        int a;
        
        for (int i = 0; i < All.Length; i++)
        {

            if (All[i].items == null)
            {
                All[i].items = new int[itype];
                All[i].Nitems = new int[Ntype];
                amount = mina + rand.Next(maxa);
                for (int j = 0; j < amount; j++)
                {
                    a = 1 + rand.Next(itype);
                    if (a == itype) a--;
                    All[i].items[a]++;
                }
                All[i].name = NewName(next);
            }
            else{ next++; }
            
        }
    }
    string NewName(int next) 
    {
        int a;
        a = 1 + rand.Next(strings.Length);
        if (a == strings.Length) a--;
        
        while (a==next) 
        {
            a=rand.Next(strings.Length);
        }
        return strings[a];
    }
}
