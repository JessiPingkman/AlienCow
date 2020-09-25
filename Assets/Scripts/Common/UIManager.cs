using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Enums;

public class UIManager : MonoBehaviour
{
    public List<TextCounter> CounterTexts;

    [SerializeField]
    private Text _waveText;

    [SerializeField]
    private GameObject _gameOverPanel;

    private Dictionary<CounterTag, TextCounter> _counterTextsDictionary;

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

        _counterTextsDictionary = new Dictionary<CounterTag, TextCounter>();

        foreach(TextCounter counterText in CounterTexts)
        {   
            _counterTextsDictionary.Add(counterText.CounterTag, counterText);
        }
    }

    public void UpdateCounterText(CounterTag tag, int count)
    {
        if(_counterTextsDictionary.ContainsKey(tag) == false)
        {
            return;
        }

        _counterTextsDictionary[tag].Counter.text = tag.ToString()+": "+count;
    }

    public void UpdateWaveText(string value)
    {
        _waveText.text = "Wave "+value;
    }

    public void ShowWaveText(bool visible)
    {
        _waveText.gameObject.SetActive(visible);
    }

    public void ShowGameOverPanel()
    {
        foreach(TextCounter counterText in CounterTexts)
        {
            counterText.Counter.gameObject.SetActive(false);
        }
        _waveText.gameObject.SetActive(false);
        _gameOverPanel.SetActive(true);
    }
}
