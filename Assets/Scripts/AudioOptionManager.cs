using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AudioOptionManager : MonoBehaviour
{
    
    public static float BackgroundVolume { get; private set; }
    public static float SoundEffectVolume { get; private set; }

    public TextMeshProUGUI backgroundSliderText;
    public TextMeshProUGUI soundEffectSliderText;

    public Slider backgroundSlider;
    public Slider soundEffectSlider;

    private void Start()
    {
        BackgroundVolume = PlayerPrefs.GetFloat("BackgroundVolume");
        SoundEffectVolume = PlayerPrefs.GetFloat("SoundEffectVolume");

        SetSlider(BackgroundVolume, backgroundSlider, backgroundSliderText);
        SetSlider(SoundEffectVolume, soundEffectSlider, soundEffectSliderText);

    }

    public void SetSlider(float volumeType,Slider slider,TextMeshProUGUI sliderText)
    {
        sliderText.text = ((int)(volumeType * 100)).ToString();
        slider.maxValue = 1;
        slider.value = volumeType;

    }

    public void OnBackgroundSliderChangeValue(float value)
    {
        // saving volume value with key name BackgroundVolume
        PlayerPrefs.SetFloat("BackgroundVolume", value);

        // get volume value with key name BackgroundVolume
        BackgroundVolume = PlayerPrefs.GetFloat("BackgroundVolume");
        //BackgroundVolume = value;
        backgroundSliderText.text = ((int)(BackgroundVolume*100)).ToString();
        FindObjectOfType<AudioManager>().UpdateAudioMixerVolume();
    }
    public void OnSoundEffectSliderChangeValue(float value)
    {
        PlayerPrefs.SetFloat("SoundEffectVolume", value);

        SoundEffectVolume = PlayerPrefs.GetFloat("SoundEffectVolume");
        //SoundEffectVolume = value;
        soundEffectSliderText.text = ((int)(SoundEffectVolume * 100)).ToString();
        FindObjectOfType<AudioManager>().UpdateAudioMixerVolume();
    }

}
