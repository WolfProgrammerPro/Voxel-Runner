using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private AmbientSoundPlayer ambientSoundPlayer;
    [SerializeField] private CutscenePlayer cutscenePlayer;

    [SerializeField] private GameObject basicCamera;


    private void Start()
    {
        if (cutscenePlayer  != null && spawner != null && ambientSoundPlayer != null)
        {
            float cutsceneVideoLenght = cutscenePlayer.PlayCutscene();
            StartCoroutine(SpawnCooldown(cutsceneVideoLenght));
        }
    }

    public void StartGameplay()
    {
        if (spawner != null && ambientSoundPlayer != null && basicCamera != null)
        {
            spawner.Spawn();
            Destroy(basicCamera);
            ambientSoundPlayer.StartPlay();
            Destroy(gameObject);
        }
    }

    IEnumerator SpawnCooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartGameplay();
    }
}
