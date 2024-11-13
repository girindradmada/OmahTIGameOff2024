using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]Transform Player;
    Collider2D Collider;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        Collider=GetComponent<Collider2D>();
    }
    void FixedUpdate()
    {
        if (Player.position.y < transform.position.y)
        {
            Collider.enabled = false;
        }
        else if (Player.position.y >= transform.position.y) 
        {
            Collider.enabled = true;
        }
    }
}
