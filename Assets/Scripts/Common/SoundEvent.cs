using UnityEngine;

namespace Common
{
    public class SoundEvent : MonoBehaviour
    {
        public void PlaySoundByName(string soundName)
        {
            AudioManager.PlaySound(soundName);
        }
    }
}
