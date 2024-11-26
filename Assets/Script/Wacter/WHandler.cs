using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WHandler : MonoBehaviour
{
    public int total_employee=0;//how many emplooyes
    public int SuperviserSusLevel=0;//how often SP came
    public int total_cctv = 0;//How many cctv Exicts
    GameObject CCTV;
    GameObject Employee;
    GameObject Superviser;
    public void Set(int EM,int CC,int SP) 
    {
        SuperviserSusLevel = SP;
        total_employee = EM;
        total_cctv=CC;
        SetCCTV();
        SetSuperviser();
        SetCCTV();
    }

    void SetCCTV() 
    {
        for (int i = 0; i < total_cctv; i++) 
        {
        Instantiate(CCTV);
        }
    }
    void SetSuperviser() { }
    void SetEmployees() 
    {
        for (int i = 0; i < total_employee; i++)
        {
        GameObject E=Instantiate(Employee);
        Employee s = E.GetComponent<Employee>();
        s.Number = i;
        }
    }
}
