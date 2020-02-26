using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _score;
    [SerializeField]
    private Text _petAmount;

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
        _score.text = value.ToString();
    }
    public void UpdatePetAmountLabel(float value)
    {
        _petAmount.text = value.ToString();
    }

    public void UpdateWaveLabel(int numberOfEnemyWave = 0, int killCounter = 0, int currentWave = 0)
    {
       _amountKillEnemy.text = numberOfEnemyWave.ToString() + "/" + killCounter.ToString();
       _currentWave.text = currentWave.ToString();
    }

    public void ShowWaveLabel(int currentWave)
    {
        _wavePanel.SetActive(true);
        _currentWave.text = currentWave.ToString();
    }

    public void HideWavelabel()
    {
        _wavePanel.SetActive(false);
    }

    public void ShowGameoverLabel()
    {
        _gameoverPanel.SetActive(true);
    }
    public void HideGameoverLabel()
    {
        _gameoverPanel.SetActive(false);
    }
}
