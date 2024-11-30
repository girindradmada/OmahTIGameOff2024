using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WHandler : MonoBehaviour
{
    [ContextMenu("Do Something")]
    private void Do()
    {
        Set(total_employee,total_cctv);
    }
    public int total_employee=0;//how many emplooyes
    public int total_cctv = 0;//How many cctv Exicts
    [SerializeField]GameObject CCTV;
    [SerializeField] GameObject Employee;
    [SerializeField] GameObject t;
    [SerializeField] GameObject Fill;
    GameObject temp;
    public void Set(int EM,int CC) 
    {
        Destroy(t);
        t= Instantiate(Fill);
        total_employee = EM;
        total_cctv=CC;
        SetCCTV();
        SetEmployees();
    }

    void SetCCTV() 
    {
        float a = 10f / (total_cctv + 1);
        for (int i = 0; i < total_cctv; i++) 
        {
        temp = Instantiate(CCTV,t.transform);
        temp.transform.position = new Vector3(-9+(i+1)*a,4,0);
        }
    }
    void SetEmployees() 
    {
        for (int i = 0; i < total_employee; i++)
        {
        GameObject E=Instantiate(Employee,t.transform);
        Employee s = E.GetComponent<Employee>();
        s.Number = i;
        }
    }
}
