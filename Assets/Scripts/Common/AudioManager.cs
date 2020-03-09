using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioSource _audio;
        private static Dictionary<string, AudioClip> _sounds;

        private void Awake()
        {
            _sounds = new Dictionary<string, AudioClip>();

            _audio = GetComponent<AudioSource>();
            AudioClip[] soundsList = Resources.LoadAll<AudioClip>("Sounds");
            foreach(AudioClip sound in soundsList)
            {
                _sounds.Add(sound.name, sound);
            }
        }

        public static void PlaySound(string name)
        {
            _audio.PlayOneShot(_sounds[name]);
        }
    }
}
