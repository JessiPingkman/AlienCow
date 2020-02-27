using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public List<TextCounter> counterTexts;

    [SerializeField]
    private Text _waveText;

    [SerializeField]
    private GameObject _gameOverText;

    private Dictionary<CounterTags, TextCounter> counterTextsDictionary;

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

        counterTextsDictionary = new Dictionary<CounterTags, TextCounter>();

        foreach(TextCounter counterText in counterTexts)
        {   
            counterTextsDictionary.Add(counterText.counterTag, counterText);
        }
    }

    public void UpdateCounterText(CounterTags tag, int count)
    {
        if(counterTextsDictionary.ContainsKey(tag) == false)
        {
            return;
        }

        counterTextsDictionary[tag].counter.text = tag.ToString()+": "+count;
    }

    public void UpdateWaveText(string value)
    {
        _waveText.text = "Wave "+value;
    }

    public void ShowWaveText(bool visible)
    {
        _waveText.gameObject.SetActive(visible);
    }

    public void ShowGameOverText()
    {
        foreach(TextCounter counterText in counterTexts)
        {
            counterText.counter.gameObject.SetActive(false);
        }
        _waveText.gameObject.SetActive(false);
        _gameOverText.gameObject.SetActive(true);
    }
}
