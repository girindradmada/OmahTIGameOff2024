using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.XR;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }
    [SerializeField] AudioSource BGM;
    [SerializeField] AudioSource SFX;
    [SerializeField]AudioClip[] BGMS;
    [SerializeField]AudioClip[] SFXs;
    [SerializeField] float pitch;
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
    public void ChangeVolume()
    {
        BGM.volume = State.Instance.BGMv;
        SFX.volume = State.Instance.SFXv;
    }
    public void ChangeBGM(int a)
    {

    BGM.clip = BGMS[a];
    BGM.Play();
    }
    public void PlaySFX(int a) 
    {
    SFX.pitch = 0.9f + (float)Gamemanager.Instance.rand.Next(20) / 100;
    SFX.clip = SFXs[a];
    SFX.PlayOneShot(SFXs[a]);
    }
}
