using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        
        private AudioSource _audio;
        private Dictionary<string, AudioClip> _sounds;
        private Dictionary<AudioTag, string[]> _soundsByTag;

        private void Awake()
        {
            InitializeInstance();
            
            _sounds = new Dictionary<string, AudioClip>();

            _audio = GetComponent<AudioSource>();
            AudioClip[] soundsList = Resources.LoadAll<AudioClip>("Sounds");

            foreach(AudioClip sound in soundsList)
            {
                _sounds.Add(sound.name, sound);
            }
        }

        private void InitializeInstance()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else if(Instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void Filter(AudioClip[] soundsList)
        {
            var result = soundsList.Where()
        }

        public void PlaySound(string name)
        {
            _audio.PlayOneShot(_sounds[name]);
        }

        public void PlayRandomSoundByTag(string tag)
        {
        }
    }

    public enum AudioTag
    {
        Rick,
        Morty,
        Other
    }
}
