using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class WaveSpawner : MonoBehaviour, ISerializationCallbackReceiver
{
    [SerializeField] List<Wave> waves = new List<Wave>();
    [SerializeField] List<float> delays = new List<float>();
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();


    private int waveIndex = 0;
    private Coroutine waveLoop;
    void Start()
    {
        if (spawnPoints.Count == 0)
        {
            Debug.LogError("No spawn point was set!");
        }

        waveLoop = StartCoroutine(SpawnNextWaveAfterDelay());
    }

    public void StopWaveLoop()
    {
        StopCoroutine(waveLoop);
    }

    private IEnumerator SpawnNextWaveAfterDelay()
    {
        yield return new WaitForSeconds(delays[waveIndex]);
        Spawn(waves[waveIndex]);

        waveIndex++;
        if (waveIndex < waves.Count)
        {
            waveLoop = StartCoroutine(SpawnNextWaveAfterDelay());
        }
        else
        {
            StopCoroutine(waveLoop);
            Debug.Log("Spawned all waves!");
        }
    }

    private void Spawn(Wave wave)
    {
        foreach (GameObject item in wave.enemies)
        {
            Transform spawnPoint = GetRandomSpawnPoint();
            Instantiate(item, spawnPoint.position, spawnPoint.rotation);
        }
    }
    private Transform GetRandomSpawnPoint()
    {
        int count = spawnPoints.Count;
        int index = Random.Range(0, count - 1);
        return spawnPoints[index];
    }

    public void OnAfterDeserialize()
    {

    }
    public void OnBeforeSerialize()
    {
        if (waves.Count < delays.Count)
        {
            delays.Remove(0);
        }
        if (waves.Count > delays.Count)
        {
            delays.Add(0);
        }
    }
}
