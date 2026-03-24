using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public interface ISoundsVolumeManager
{
    void SetSoundsVolume(float volume);
    void SetMusicVolume(float volume);
    float SoundsVolume { get; }
    float MusicVolume { get; }
}

public class SoundsVolumeManager : MonoBehaviour, ISoundsVolumeManager
{
    [SerializeField, Range(0, 1)] private float soundsVolume;
    [SerializeField, Range(0, 1)] private float musicVolume;
    public void SetSoundsVolume(float volume)
    {
        volume = Math.Clamp(volume, 0f, 1f);
        soundsVolume = volume;
    }

    public void SetMusicVolume(float volume)
    {
        volume = Math.Clamp(volume, 0f, 1f);
        musicVolume= volume;
    }
    public float SoundsVolume => soundsVolume;
    public float MusicVolume => musicVolume;
}
