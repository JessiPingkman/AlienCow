using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _score;
    [SerializeField]
    private Text _petAmount;
    [SerializeField]
    private Text _waveEnemyCount;

    [SerializeField]
    private Text _currentWave;

    [SerializeField]
    private GameObject _wavePanel;

    [SerializeField]
    private GameObject _gameoverPanel;

    [SerializeField]
    private Text _amountKillEnemy;

    public static UIManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScoreLabel(float value)
    {
        Instance._score.text = value.ToString();
    }
    public void UpdatePetAmountLabel(float value)
    {
        Instance._petAmount.text = value.ToString();
    }

    public void UpdateWaveLabel(string count = "0", int countKillEnemy = 0, int currentWave = 0)
    {
       Instance._waveEnemyCount.text = count;
       Instance._amountKillEnemy.text = "/" + countKillEnemy.ToString();
       Instance._currentWave.text = currentWave.ToString();
    }

    public void ShowWaveLabel()
    {
        Instance._wavePanel.SetActive(true);
    }

    public void HideWavelabel()
    {
        Instance._wavePanel.SetActive(false);
    }

    public void ShowGameoverLabel()
    {
        Instance._gameoverPanel.SetActive(true);
    }
    public void HideGameoverLabel()
    {
        Instance._gameoverPanel.SetActive(false);
    }
}
