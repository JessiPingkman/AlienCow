using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _score;

    [SerializeField]
    private Text _petAmount;

    [SerializeField]
    private Text _waveText;

    [SerializeField]
    private GameObject _gameOverText;

    [SerializeField]
    private Text _killCounter;

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

    public void UpdateScoreText(float value)
    {
        _score.text = "Scores: "+value.ToString();
    }

    public void UpdateWaveText(string value)
    {
        _waveText.text = "Wave "+value;
    }

    public void UpdatePetAmountText(float value)
    {
        _petAmount.text = "Pets: "+value.ToString();
    }

    public void UpdateKillCounterText(int maxEnemyCount = 0, int killCount = 0)
    {
       _killCounter.text = "Enemies: "+ killCount+" / "+maxEnemyCount;
    }

    public void ShowWaveText(bool visible)
    {
        _waveText.gameObject.SetActive(visible);
    }

    public void ShowGameOverText()
    {
        _score.gameObject.SetActive(false);
        _waveText.gameObject.SetActive(false);
        _petAmount.gameObject.SetActive(false);
        _killCounter.gameObject.SetActive(false);
        _gameOverText.gameObject.SetActive(true);
    }
}
