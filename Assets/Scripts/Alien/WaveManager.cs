using Enums;
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

    private Timer _textTimer;
    private Timer _waveTimer;
    private Timer _spawnTimer;
    private float _maxSpawnInterval;
    private int _currentWaveNumber;
    private int _spawnedObjectsCount;


    private void Awake() 
    {
        _currentWaveNumber = 1;
        _textTimer = new Timer();
        _waveTimer = new Timer();
        _spawnTimer = new Timer();
        _maxSpawnInterval = _spawnInterval;
    }

    private void Start() 
    {
        UIManager.Instance.UpdateWaveText(_currentWaveNumber.ToString());
        UIManager.Instance.ShowWaveText(true);
    }

    private void Update() 
    {
        if(_textTimer.CountTo(4))
        {
            UIManager.Instance.ShowWaveText(false);
            _textTimer.Restart();
        }

        if(_spawnedObjectsCount < _maxCount && !_waveIsComplete)
        {
            if(_spawnTimer.CountTo(Random.Range(_spawnInterval, _maxSpawnInterval)) == false)
            {
                return;
            }
            SpawnEnemies();
            _spawnTimer.Restart();
        }
        else
        {
            if(!_waveIsComplete)
            {
                if(CountManager.Instance.GetCounter(CounterTag.Kills) < _maxCount)
                {
                    return;
                }
                
                CompleteCurrentWave();
                UIManager.Instance.ShowWaveText(true);
            }

            if(_waveTimer.CountTo(_waveInterval) == false)
            {
                return;
            }

            PrepareNextWave();
            UIManager.Instance.UpdateWaveText(_currentWaveNumber.ToString());
            UIManager.Instance.ShowWaveText(true);
            StartNewWave();

            _waveTimer.Restart();
            _spawnTimer.Restart();
        }
    }

    private void SpawnEnemies()
    {
        for(int i = 0; i<_spawner.SpawnCount; i++)
        {
            _spawner.Spawn(new Vector3(_spawner.SpawnPosition.position.x, Random.Range(-5.5f, -3f), _spawner.SpawnPosition.position.z));
            _spawnedObjectsCount++;
        }
    }

    private void CompleteCurrentWave()
    {
        _waveIsComplete = true;
        _spawnedObjectsCount = 0;
        UIManager.Instance.UpdateWaveText("completed");
        UIManager.Instance.ShowWaveText(true);
    }

    private void PrepareNextWave()
    {
        var kills = CountManager.Instance.GetCounter(CounterTag.Kills);
        CountManager.Instance.Decrement(CounterTag.Kills, kills);
        _maxCount += _currentWaveNumber*3;
        _spawnInterval -= 0.05f;
        _currentWaveNumber++;
    }

     private void StartNewWave()
    {
        _waveIsComplete = false;
    }
}