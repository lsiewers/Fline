using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // following the Brackeys tutorial: Introduction to AUDIO

    // singleton
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            AddSources();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Audio[] clips;

    private void Start()
    {
        Play("Theme");
    }

    private void AddSources()
    {
        foreach(Audio clip in clips)
        {
            clip.source = gameObject.AddComponent<AudioSource>();
            clip.source.clip = clip.clip;
            clip.source.volume = clip.volume;
            clip.source.loop = clip.loop;
        }
    }

    public void Play(string name)
    {
        Audio sound = Array.Find(clips, s => s.name == name);
        sound.source.Play();
    }

    public void Stop(string name)
    {
        Audio sound = Array.Find(clips, s => s.name == name);
        sound.source.Stop();
    }

    public bool IsPlaying(string name)
    {
        Audio sound = Array.Find(clips, s => s.name == name);
        return sound.source.isPlaying;
    }
}
