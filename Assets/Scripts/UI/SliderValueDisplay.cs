using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderValueDisplay : MonoBehaviour {

    [SerializeField]private bool _isMusicSlider;
    [SerializeField]private bool _isSFXSlider;

    private Slider _slider;
	// Use this for initialization
	void Start () {
        _slider = GetComponent<Slider>();
        if (_isMusicSlider)
        {
            ShowMusicVolumeValue();
        }
        if (_isSFXSlider)
        {
            ShowSFXVolumeValue();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ShowMusicVolumeValue()
    {
        _slider.value = AudioData.MusicVolume;
    }

    void ShowSFXVolumeValue()
    {
        _slider.value = AudioData.SFXVolume;
    }
}
