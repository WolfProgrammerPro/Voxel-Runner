using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Video;


public class CutscenePlayer : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;

    [SerializeField, Range(0f, 1f)] private float volume;
    [SerializeField] private VideoClip clip;

    private void Awake()
    {
        Initialize();
    }

    public float PlayCutscene()
    {
        if (videoPlayer != null && videoPlayer.clip != null && GameManager.Instance != null)
        {
            for (ushort i = 0; i < videoPlayer.audioTrackCount; i++)
            {
                videoPlayer.SetDirectAudioVolume(i, volume * GameManager.Instance.SoundsVolume);
            }
            StartCoroutine(HideCutsceneUIElements());
            StartCoroutine(PlayVideo());
            return (float)videoPlayer.length;
        }
        StopPlayCutscene();
        return 0;
    }

    IEnumerator PlayVideo()
    {
        yield return null;
        videoPlayer.Play();
    }


    IEnumerator HideCutsceneUIElements()
    {
        yield return new WaitForSeconds((float)videoPlayer.length);
        StopPlayCutscene();
    }

    private void Initialize()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }
        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer component not found!");
            return;
        }
        videoPlayer.clip = clip;
        videoPlayer.playOnAwake = false;
        videoPlayer.isLooping = false;
        videoPlayer.skipOnDrop = true;
        videoPlayer.waitForFirstFrame = true;

        videoPlayer.audioOutputMode = VideoAudioOutputMode.Direct;
        videoPlayer.controlledAudioTrackCount = 1;
        videoPlayer.EnableAudioTrack(0, true);

    }

    public void StopPlayCutscene()
    {
        videoPlayer.Stop();
        gameObject.SetActive(false);
    }
}
