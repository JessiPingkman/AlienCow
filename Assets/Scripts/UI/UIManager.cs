using System.Collections.Generic;
using System.Linq;
using Common;
using Enums;
using UnityEngine;
using UnityEngine.UI;

namespace UI
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
            IEnumerable<TextCounter> counterTexts = CounterTexts.Where(counterText => counterText.Tag == counterTag);
            foreach (var counterText in counterTexts)
            {
                counterText.Text.text = tag + ": " + count;
            }
        }

        public void UpdateWaveText(string value)
        {
            _waveText.text = "Wave " + value;
        }

        public void ShowWaveText()
        {
            _waveText.gameObject.SetActive(true);
        }

        public void HideWaveText()
        {
            _waveText.gameObject.SetActive(false);
        }

        public void ShowGameOverPanel()
        {
            HideAllCounterText();
            HideWaveText();
            _gameOverPanel.SetActive(true);
        }

        private void HideAllCounterText()
        {
            foreach (TextCounter counterText in CounterTexts)
            {
                counterText.Text.gameObject.SetActive(false);
            }
        }
    }
}
