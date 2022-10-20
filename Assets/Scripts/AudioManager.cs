using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup backgroundMixerGroup;
    public AudioMixerGroup soundEffectMixerGroup;

    public Sound[] sound;

    private void Awake()
    {
        foreach(Sound s in sound)
        {
            s.audioSource =gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.loop = s.loop;


            // decide audio type for the sound
            switch (s.audioType)
            {
                case Sound.AudioType.Background:
                    s.audioSource.outputAudioMixerGroup = backgroundMixerGroup;
                    // get volume value from the last time change
                    s.audioSource.volume = PlayerPrefs.GetFloat("BackgroundVolume");
                    break;
                case Sound.AudioType.SoundEffect:
                    s.audioSource.outputAudioMixerGroup = soundEffectMixerGroup;
                    s.audioSource.volume = PlayerPrefs.GetFloat("SoundEffectVolume");
                    break;
            }
        }
    }
    public void PlaySound(string name)
    {
        Sound s=Array.Find(sound, sound => sound.name == name);
        s.audioSource.Play();
        //if(s.audioSource.outputAudioMixerGroup == backgroundMixerGroup)
        //    s.audioSource.volume = PlayerPrefs.GetFloat("BackgroundVolume");
        
        //else
        //    s.audioSource.volume = PlayerPrefs.GetFloat("SoundEffectVolume");
        //Debug.Log(s.audioSource.volume);
    }
    public void StopSound(string name)
    {
        Sound s=Array.Find(sound, sound => sound.name == name);
        s.audioSource.Stop();
    }
    public void UpdateAudioMixerVolume()
    {
        float a = Mathf.Log10(AudioOptionManager.BackgroundVolume) * 20;
        backgroundMixerGroup.audioMixer.SetFloat("Background volume", a);
        Debug.Log(a);

        soundEffectMixerGroup.audioMixer.SetFloat("Sound effect volume", Mathf.Log10(AudioOptionManager.SoundEffectVolume) * 20);
    }
}
