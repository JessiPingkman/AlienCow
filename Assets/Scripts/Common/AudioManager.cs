using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioSource _audio;
    private static Dictionary<string, AudioClip> _sounds = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        var soundsList = Resources.LoadAll<AudioClip>("Sounds");
        
        foreach(var sound in soundsList)
        {
            _sounds.Add(sound.name, sound);
        }
    }

    public static void PlaySound(string name)
    {
        _audio.PlayOneShot(_sounds[name]);
    }
}
