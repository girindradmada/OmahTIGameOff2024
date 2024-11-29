using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV : MonoBehaviour
{
    System.Random rand;
    [SerializeField] float StartSee;
    float SeeTime;
    bool SEE;
    [SerializeField] Sprite looking;
    [SerializeField] Sprite not_looking;
    [SerializeField] SpriteRenderer RD;
    bool call=false;
    // Start is called before the first frame update
    void Awake()
    {
        rand = Gamemanager.Instance.rand;
        Randomize();
    }

    void Randomize()
    {
        StartSee = rand.Next(10) + 1;
        SeeTime = rand.Next(6) / 3;
        SEE = false;
        call = false;
    }
    private void FixedUpdate()
    {
        StartSee -= Time.deltaTime;
        if (SEE)
        {
            SeeTime -= Time.deltaTime;
            if (SeeTime <= 0)
            {
                RD.sprite = not_looking;
                Randomize();
            }
        }
        else if (StartSee <= 0)
        {
            SEE = true;
            RD.sprite = looking;
            if (Gamemanager.Instance.seen_time < SeeTime)
            {
                Gamemanager.Instance.seen_time = SeeTime;
                Gamemanager.Instance.is_seen = true;
            }
        }
        else if (StartSee <= 1&&!call) 
        {
            call = true;
            UIManager.Instance.warningCoroutine(3, transform.position, 1);
        }
    }
}
