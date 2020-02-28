using UnityEngine;
public class WaveManager : MonoBehaviour
{
    [SerializeField]
    private Spawner _spawner;

    [SerializeField]
    private int _maxCount;

    [SerializeField]
    private int _waveInterval;

    [SerializeField]
    private float _spawnInterval;

    [SerializeField]
    private bool _waveIsComplete;

    private Timer textTimer;
    private Timer waveTimer;
    private Timer spawnTimer;
    private float _maxSpawnInterval;
    private int currentWaveNumber;
    private int spawnedObjectsCount;


    private void Awake() 
    {
        currentWaveNumber = 1;
        textTimer = new Timer();
        waveTimer = new Timer();
        spawnTimer = new Timer();
        _maxSpawnInterval = _spawnInterval;
    }

    private void Start() 
    {
        UIManager.Instance.UpdateWaveText(currentWaveNumber.ToString());
        UIManager.Instance.ShowWaveText(true);
    }

    private void Update() 
    {
        if(textTimer.CountTo(4))
        {
            UIManager.Instance.ShowWaveText(false);
            textTimer.Restart();
        }

        if(spawnedObjectsCount < _maxCount && !_waveIsComplete)
        {
            if(spawnTimer.CountTo(Random.Range(_maxSpawnInterval, _spawnInterval)) == false)
            {
                return;
            }
            SpawnEnemies();
            spawnTimer.Restart();
        }
        else
        {
            if(!_waveIsComplete)
            {
                if(CountManager.Instance.GetCounter(CounterTags.kills) < _maxCount)
                {
                    return;
                }
                
                CompleteTheWave();
                UIManager.Instance.ShowWaveText(true);
            }

            if(waveTimer.CountTo(_waveInterval) == false)
            {
                return;
            }

            PrepareNextWave();
            UIManager.Instance.UpdateWaveText(currentWaveNumber.ToString());
            UIManager.Instance.ShowWaveText(true);
            StartNewWave();

            waveTimer.Restart();
            spawnTimer.Restart();
        }
    }

    private void SpawnEnemies()
    {
        for(int i = 0; i<_spawner.spawnCount; i++)
        {
            _spawner.Spawn(new Vector3(_spawner.spawnPosition.position.x, Random.Range(-5.5f, -3f), _spawner.spawnPosition.position.z));
            spawnedObjectsCount++;
        }
    }

    private void CompleteTheWave()
    {
        _waveIsComplete = true;
        spawnedObjectsCount = 0;
        UIManager.Instance.UpdateWaveText("completed");
        UIManager.Instance.ShowWaveText(true);
    }

    private void PrepareNextWave()
    {
        var kills = CountManager.Instance.GetCounter(CounterTags.kills);
        CountManager.Instance.Decrement(CounterTags.kills, kills);
        _maxCount += currentWaveNumber*3;
        _spawnInterval -= 0.05f;
        currentWaveNumber++;
    }

     private void StartNewWave()
    {
        _waveIsComplete = false;
    }
}