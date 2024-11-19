using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hand : MonoBehaviour
{
    private static Hand _instance;
    [SerializeField]Camera _camera;
    [SerializeField]GameObject jatuh;
    public static Hand Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    private void OnDestroy()
    {
        _instance = null;
    }
    [SerializeField]Item hand;
    [SerializeField]Transform OnHand;
    Sprite spriteImage;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] bool full;
    public void OnHandChange(Item item) 
    {
        hand = item;
        spriteImage = hand.sprite;
        spriteRenderer.sprite = spriteImage;
        spriteRenderer.color = Color.white;
        //spriteRenderer.color=Color.clear;
    }
    private void FixedUpdate()
    {
       
        var mouseWorldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;    
        OnHand.position =mouseWorldPos;

    }
    private void Update() 
    {
        HandleChange();    
    }
    void HandleChange() 
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            RaycastHit2D hit = Physics2D.Raycast(_camera.transform.position,OnHand.position);
            if (hit) 
            {
                if (hit.collider.TryGetComponent<Tray>(out Tray T)) 
                {
                    T.Change();
                    full = true;
                }
            }
        }
        if (Input.GetButtonUp("Fire1")) 
        {
            if (full) 
            {
            full = false;
            jatuh.SetActive(true);
            }


        }
    }
}
