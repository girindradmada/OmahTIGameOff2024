using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        //repeatWidth = GetComponent<BoxCollider>().size.x/2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( transform.position.x < -2.38){
            transform.position = new Vector3(18,transform.position.y,transform.position.z);
        }
    }
}
