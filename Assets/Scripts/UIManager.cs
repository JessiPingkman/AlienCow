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

    public static UIManager Self;

    private void Awake()
    {
        Self = this;
    }

    public static void UpdateScoreLabel(float value)
    {
        Self._score.text = value.ToString();
    }
    public static void UpdatePetAmountLabel(float value)
    {
        Self._petAmount.text = value.ToString();
    }

    public static void UpdateWaveLabel(string count = "0", int countKillEnemy = 0, int currentWave = 0)
    {
       Self._waveEnemyCount.text = count;
       Self._amountKillEnemy.text = "/" + countKillEnemy.ToString();
       Self._currentWave.text = currentWave.ToString();
    }

    public static void ShowWaveLabel()
    {
        Self._wavePanel.SetActive(true);
    }

    public static void HideWavelabel()
    {
        Self._wavePanel.SetActive(false);
    }

    public void ShowGameoverLabel()
    {
        Self._gameoverPanel.SetActive(true);
    }
    public void HideGameoverLabel()
    {
        Self._gameoverPanel.SetActive(false);
    }
}
