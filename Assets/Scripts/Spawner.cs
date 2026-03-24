using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private Transform playerSpawn;
    [SerializeField] private Transform[] enemySpawns;

    [SerializeField] private InterfaceManager interfaceManager;
    [SerializeField] private TimeManager timeManager;

    public void Spawn()
    {
        if (playerSpawn != null && playerPrefab != null && interfaceManager != null && timeManager != null)
        {
            GameObject playerObject = Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation);
            PlayerInteracting interacting = playerObject.GetComponent<PlayerInteracting>();
            if (interacting != null )
            {
                interacting.SetInterfaceManager(interfaceManager);
            }
            Player player = playerObject.GetComponent<Player>();
            if (player != null)
            {
                player.SetInterfaceManager(interfaceManager);
                player.SetTimeManager(timeManager);
            }


            if (enemyPrefab)
            {
                foreach (Transform enemySpawn in enemySpawns)
                {
                    GameObject enemy = Instantiate(enemyPrefab, enemySpawn.position, enemySpawn.rotation);
                    EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
                    if (enemyMovement != null)
                    {
                        enemyMovement.SetTargetObject(playerObject.transform);
                    }
                }
            }
        }
    }
}
