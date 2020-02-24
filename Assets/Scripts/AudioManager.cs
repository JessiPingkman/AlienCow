using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioSource audio;
    private static Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        audio.GetComponent<AudioSource>();
        var soundsList = Resources.LoadAll<AudioClip>("/Sounds/");
        foreach(var sound in soundsList)
        {
            sounds.Add(sound.name, sound);
        }
    }

    public static void PlaySound(string name)
    {
        audio.PlayOneShot(sounds[name]);
    }
}
