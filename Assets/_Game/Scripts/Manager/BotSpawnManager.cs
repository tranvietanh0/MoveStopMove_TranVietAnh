using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawnManager : Singleton<BotSpawnManager>
{
    [SerializeField] private Bot botPrefab;
    [SerializeField] private List<Transform> spawnPositions = new List<Transform>();

    private void Start()
    {
        OnSpawnBot();
    }

    private void OnSpawnBot()
    {
        for (int indexPos = 0; indexPos < spawnPositions.Count; indexPos++)
        {
            Bot botPool = SimplePool.Spawn<Bot>(botPrefab, spawnPositions[indexPos].position, Quaternion.identity);
            Debug.Log(indexPos);
            Debug.Log("bot ne");
        }

        // botPool.OnInit();
    }
}
