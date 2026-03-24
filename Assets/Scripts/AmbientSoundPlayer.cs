using UnityEngine;

public class AmbientSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    [SerializeField, Range(0f, 1f)] private float volume;

    [SerializeField] AudioSource audioSource;

    public void StartPlay()
    {
        if (audioSource != null && GameManager.Instance != null && sound != null)
        {
            audioSource.clip = sound;
            audioSource.volume = volume * GameManager.Instance.MusicVolume * GameManager.Instance.SoundsVolume;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
