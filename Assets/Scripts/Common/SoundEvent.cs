using UnityEngine;

namespace Common
{
    public class SoundEvent : MonoBehaviour
    {
        public void PlaySoundByName(string soundName)
        {
            AudioManager.Instance.PlaySound(soundName);
        }
    }
}
