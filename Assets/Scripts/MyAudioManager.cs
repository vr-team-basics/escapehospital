using UnityEngine.Audio;
using System;
using UnityEngine;

public class MyAudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public int randSound;

    AudioSource thisAudio;

    void Awake()
    {
        foreach( Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void HitRandom()
    {
        randSound = UnityEngine.Random.Range(0, sounds.Length);
        thisAudio = gameObject.GetComponent<AudioSource>();
        thisAudio.clip = sounds[randSound].clip;
        thisAudio.Play();
    }

    void Start()
    {
        //Play("Ambience");
    }

    public void Play( string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
