using UnityEngine;

public class SoundEvent : MonoBehaviour
{
    public void CallSound(string soundName)
    {
        AudioManager.PlaySound(soundName);
    }
}
