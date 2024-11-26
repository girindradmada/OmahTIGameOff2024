using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitem : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] NBoxIn NBoxIn;
    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite=item.sprite;
        
    }
    public int id() 
    {
    return item.ItemInt;
    }
    public void activate() 
    {
        if (NBoxIn == null) NBoxIn = gameObject.GetComponentInParent<NBoxIn>(); ;
        if (NBoxIn.Nitems[item.ItemInt] >0)
            gameObject.SetActive(true);
    }
    public void deactivate()
    {
            gameObject.SetActive(false);
    }
    public void GotClick()
    {
        if (Gamemanager.Instance.Nbox.iteminq < 3)
        {
            Gamemanager.Instance.Nbox.NitemList.Enqueue(item);
            NBoxIn.Nitems[item.ItemInt]--;
            Gamemanager.Instance.Nbox.iteminq++;
            NBoxIn.close_time = 3;
            if (NBoxIn.Nitems[item.ItemInt] <= 0)
            {
                gameObject.SetActive(false);
            }
        }
        else
        Debug.Log("Your Hand Is Full");//call ui
    }
}