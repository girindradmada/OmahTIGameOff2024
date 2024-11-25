using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jatuh : MonoBehaviour
{
    public Item Item;
    private void OnEnable()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite=Item.sprite;
    }
    private void FixedUpdate()
    {
        if (gameObject.transform.position.y < -20) 
        {
        gameObject.SetActive(false);
        }
    }
    public void Enter()
    {
        Hand.Instance.ItemEnter(Item);
        gameObject.SetActive(false);
    }
}
