using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Common
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        
        private AudioSource _audio;
        private Dictionary<string, AudioClip> _sounds;
        private Dictionary<AudioTag, IEnumerable<string>> _soundsNamesWithTag;

        private void Awake()
        {
            InitializeInstance();
            _audio = GetComponent<AudioSource>();
            AudioClip[] soundsList = Resources.LoadAll<AudioClip>("Sounds");
            FillSoundsDictionary(soundsList);
            FillSoundsNameDictionary(soundsList);
        }
        
        private void InitializeInstance()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void FillSoundsDictionary(AudioClip[] soundsList)
        {
            _sounds = new Dictionary<string, AudioClip>();
            foreach (AudioClip sound in soundsList)
            {
                _sounds.Add(sound.name, sound);
            }
        }

        private void FillSoundsNameDictionary(AudioClip[] soundsList)
        {
            _soundsNamesWithTag = new Dictionary<AudioTag, IEnumerable<string>>();
            IEnumerable<AudioTag> audioTags = Enum.GetValues(typeof(AudioTag)).Cast<AudioTag>();
            
            foreach (AudioTag audioTag in audioTags)
            {
                IEnumerable<string> result = soundsList
                    .Where(sound => sound.name.Contains("[" + audioTag + "]"))
                    .Select(x => x.name);
                _soundsNamesWithTag.Add(audioTag, result);
            }
        }

        public void PlaySound(string soundName)
        {
            _audio.PlayOneShot(_sounds[soundName]);
        }

        public void PlayRandomSoundByTag(AudioTag audioTag)
        {
            string[] soundNames = _soundsNamesWithTag[audioTag].ToArray();
            string randomName = soundNames[Random.Range(0, soundNames.Length)];
            PlaySound(randomName);
        }
    }
}
