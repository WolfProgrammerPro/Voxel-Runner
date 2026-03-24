using System.Collections;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class InteractableObject : MonoBehaviour
{
    [SerializeField] private string objectName;
    [SerializeField] private string interactionText;
    [SerializeField] private Sprite sprite;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] protected LevelData levelData;
    [SerializeField] protected InterfaceManager interfaceManager;
    [SerializeField, Range(0,1)] private float soundVolume;
    [SerializeField] private float soundPlayingTime;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource> ();
    }

    public string ObjectName => objectName;
    public string InteractionText => interactionText;
    public Sprite ObjectSprite => sprite;

    public void Interact()
    {
        if (GameManager.Instance != null)
        {
            if (audioSource != null && audioClip != null)
            {
                audioSource.PlayOneShot(audioClip, soundVolume * GameManager.Instance.SoundsVolume);
                StartCoroutine(Cooldown());
            }
            else
            {
                AfterSoundPlayed();
            }
        }
        
        
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(soundPlayingTime);
        AfterSoundPlayed();
    }
    

    protected virtual void AfterSoundPlayed()
    {
        if (interfaceManager != null)
        {
            interfaceManager.HideInteractableObjectText();
        }
        else
        {
            Debug.Log("No InterfaceManager choosed");
        }
    }

}
