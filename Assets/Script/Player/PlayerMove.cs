using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float verdeacc;
    [SerializeField] float vSpeedMax;
    [SerializeField] float vSpeed;
    [SerializeField] float hordeacc;
    [SerializeField] float horacc;
    [SerializeField] float maxSpeed;
    [SerializeField] float speed;
    [SerializeField] bool canjump=true;
    [SerializeField] bool onground=true;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        HandleJump();
        HandleDown();
        HandleMove();
    }
    void HandleJump() 
    { 
        if (Input.GetButtonDown("Jump")) 
        {
            if (onground) 
            {
                    vSpeed = vSpeedMax;
                onground = false;
            }else           
            if (canjump) 
            {
                vSpeed = vSpeedMax;
                canjump = false;
            }
        }
    }
    void HandleDown() 
    {
        if (!onground) 
        {
        vSpeed =Mathf.Clamp(vSpeed-verdeacc,-vSpeedMax,vSpeedMax);
        }
        
    }
    void HandleMove() 
    {
        speed = Mathf.Clamp(speed + Input.GetAxis("Horizontal")*horacc,-maxSpeed,maxSpeed);
        if (speed < 0)
        {
            speed = Mathf.Clamp(speed +hordeacc, -maxSpeed, 0);
        }
        else if (speed > 0) 
        {
            speed = Mathf.Clamp(speed - hordeacc, 0, maxSpeed);
        }
        transform.position+= Vector3.right*speed*Time.deltaTime+Vector3.up*vSpeed*Time.deltaTime;

    }
    public void OnGround() 
    {
        canjump = true;
        onground= true;
        vSpeed = 0;
    }
}
