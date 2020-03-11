using System.Collections.Generic;
using System.Linq;
using Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class UiManager : MonoBehaviour
    {
        public static UiManager Instance;
    
        public List<TextCounter> CounterTexts;

        [SerializeField]
        private Text _waveText;
        [SerializeField]
        private GameObject _gameOverPanel;

        private void Awake()
        {
            InitializeInstance();
        }
    
        private void InitializeInstance()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void UpdateCounterText(CounterTag counterTag, int count)
        {
            IEnumerable<TextCounter> counterTexts = CounterTexts.Where(counterText => counterText.CounterTag == counterTag);
            foreach (var counterText in counterTexts)
            {
                counterText.Counter.text = tag + ": " + count;
            }
        }

        public void UpdateWaveText(string value)
        {
            _waveText.text = "Wave " + value;
        }

        public void ShowWaveText(bool isVisible)
        {
            _waveText.gameObject.SetActive(isVisible);
        }

        public void ShowGameOverPanel()
        {
            foreach (TextCounter counterText in CounterTexts)
            {
                counterText.Counter.gameObject.SetActive(false);
            }

            ShowWaveText(false);
            _gameOverPanel.SetActive(true);
        }
    }
}
