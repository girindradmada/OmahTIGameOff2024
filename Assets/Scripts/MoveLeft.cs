using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.ChangeBGM(0);
    }

    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
      
    }
}
