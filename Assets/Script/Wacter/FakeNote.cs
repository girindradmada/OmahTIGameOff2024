using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class FakeNote : MonoBehaviour,IQueue
{
    [SerializeField]Item item;
    public void GotClick()
    {
        if (Gamemanager.Instance.Nbox.iteminq < 3)
        {
            Gamemanager.Instance.Nbox.NitemList.Enqueue(item);
            Gamemanager.Instance.Nbox.iteminq++;
        }
        else
            UIManager.Instance.showMessage("Your Hand Is Full");//call ui
    }
}
