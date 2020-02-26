using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioSource Audio;
    private static Dictionary<string, AudioClip> Sounds = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
        var soundsList = Resources.LoadAll<AudioClip>("Sounds");
        foreach(var sound in soundsList)
        {
            Sounds.Add(sound.name, sound);
        }
    }

    public static void PlaySound(string name)
    {
        Audio.PlayOneShot(Sounds[name]);
    }
}
