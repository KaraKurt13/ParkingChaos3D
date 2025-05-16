using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class MainMenuComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _mainPanel, _settingsPanel;
        [SerializeField] private TextMeshProUGUI _timeRecordText, _currencyText;

        private void Start()
        {
            UpdateTimeRecord();
            UpdateCurrency();
        }

        private void UpdateTimeRecord()
        {
            var time = PlayerPrefs.GetInt(Constants.PrefsKey_BestTime);
            if (time == 0)
            {
                _timeRecordText.text = $"No best time";
                return;
            }
            var convertedTime = TimeHelper.TicksToSeconds(time);
            var minutes = (int)(convertedTime / 60);
            var seconds = (int)(convertedTime % 60);
            _timeRecordText.text = $"Best time: {minutes:D2}:{seconds:D2}";
        }

        private void UpdateCurrency()
        {
            var currency = PlayerPrefs.GetInt(Constants.PrefsKey_CurrencyAmount);
            _currencyText.text = $"{currency}$";
        }

        public void ShowMainPanel()
        {
            _mainPanel.SetActive(true);
        }

        public void HideMainPanel() 
        {
            _mainPanel.SetActive(false);
        }

        public void ShowSettings()
        {
            _settingsPanel.SetActive(true);
        }

        public void HideSettings()
        {
            _settingsPanel.SetActive(false);
        }
    }
}