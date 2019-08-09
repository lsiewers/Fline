using UnityEngine;

[System.Serializable]
public class Audio
{
    // following the Brackeys tutorial: Introduction to AUDIO
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    public bool loop;

    [HideInInspector] public AudioSource source;

    public Audio(string name, AudioClip clip, float volume, bool loop)
    {
        this.name = name;
        this.clip = clip;
        this.volume = volume;
        this.loop = loop;
    }
}
