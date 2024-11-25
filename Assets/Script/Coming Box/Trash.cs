using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public NBoxIn N;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        N.gameObject.SetActive(false);
        gameObject.SetActive(false);
        Gamemanager.Instance.Nbox.botfull--;
    }
    private void FixedUpdate()
    {
        if (transform.position.y < -20) 
        {
            N.gameObject.SetActive(true);
            gameObject.SetActive(false);
            Debug.Log("Dont Throw Trash Randomly Not Gud");
        }
    }
}
