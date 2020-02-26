using UnityEngine;

public class WaveSpawner : Spawner
{
    public bool waveIsComplete;
    public int maxCount;
    public float spawnInterval;
    public int waveInterval;

    private float spawnTimer = 0;
    private float waveTimer = 0;
    private int currentWaveNumber = 1;
    private int spawnedObjectsCount;

    private void Update() 
    {
        if(spawnedObjectsCount < maxCount && !waveIsComplete)
        {
            if(spawnTimer < spawnInterval)
            {
                spawnTimer += Time.deltaTime;
                return;
            }

            spawnTimer = 0;

            for(int i = 0; i<spawnCount; i++)
            {
                Spawn(spawnCount, new Vector3(spawnPosition.position.x, Random.Range(-5.5f, -3f), spawnPosition.position.z));
            }

            spawnedObjectsCount += spawnCount;
            return;
        }


        CompleteTheWave();

        if(waveTimer > waveInterval)
        {
            PrepareNextWave();
            waveTimer = 0;
        }
        else
        {
            waveTimer += Time.deltaTime;
        }
    }

    private void CompleteTheWave()
    {
        //Тут должен вызываться UiManager, у которого должно забираться количество убитых врагов, и сравнивать их с maxCount, 
        //и также, в случае совпадения выводить на экран надпись Wave Complete
        waveIsComplete = true;
        spawnedObjectsCount = 0;
    }

    private void PrepareNextWave()
    {
        maxCount = currentWaveNumber*2;
        spawnCount++;
        currentWaveNumber++;
        waveIsComplete = false;
    }
}
