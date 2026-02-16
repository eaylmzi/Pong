using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; 
    public static AudioManager instance;

    void Awake()
    {

        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }

        foreach (Sound s in sounds)
        {         
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.playOnAwake = false;
        }
    }

    public void Play(string name, bool randomPitch = false)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;


        if (randomPitch)
        {
            s.source.pitch = s.pitch * UnityEngine.Random.Range(0.9f, 1.1f);
        }
        else
        {
            s.source.pitch = s.pitch; 
        }

        s.source.Play();
    }
    public void PlayLoop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Music is not found " + name);
            return;
        }

        s.source.loop = true; 
        if (!s.source.isPlaying) 
        {
            s.source.Play();
        }
    }
}