using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] Sprite open;
    [SerializeField] Sprite close;
    [SerializeField] SpriteRenderer R;
    [SerializeField] GameObject Opening;
    [SerializeField] float next=0.5f;
    [SerializeField] float speed;
    public bool loading;
    bool up;
    bool down;
    void Start() 
    {
        R = GetComponent<SpriteRenderer>();
    }

    public void Close ()
    {
        loading = true;
    R.sprite = close;
    up = true;
    Opening.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (up) { 
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (transform.position.y > 7)
            {
                up = false;
                if (!Hand.Instance.done) StartCoroutine(Wait(next));
            }
        }
        if (down) 
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            if (transform.position.y < -2.5)
            {
                down = false;
                Opening.SetActive(true);
                R.sprite = open;
                loading=false;
            }
        }
    }
    IEnumerator Wait(float waitTime)
    {
            yield return new WaitForSeconds(waitTime);
            down = true;
            
    }
}
