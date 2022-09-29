using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sound;

    private void Awake()
    {
        foreach(Sound s in sound)
        {
            s.audioSource =gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.loop = s.loop;
        }
    }
    public void PlaySound(string name)
    {
        Sound s=Array.Find(sound, sound => sound.name == name);
        s.audioSource.Play();
    }public void StopSound(string name)
    {
        Sound s=Array.Find(sound, sound => sound.name == name);
        s.audioSource.Stop();
    }
}
