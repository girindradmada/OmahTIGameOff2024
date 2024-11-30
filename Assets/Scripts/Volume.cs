using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Volume : MonoBehaviour
{
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Slider BGMSlider;

    public void SetGameVolume()
    {
    State.Instance.SFXv = SFXSlider.value;
    State.Instance.BGMv = BGMSlider.value;
    SoundManager.Instance.ChangeVolume();
    }

}

