using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public enum AudioType { Background, SoundEffect}
    public AudioType audioType;

    public string name;
    public AudioClip audioClip;

    [Range(0f,1f)]
    public float volume;

    [HideInInspector]
    public AudioSource audioSource;

    public bool loop;
}
