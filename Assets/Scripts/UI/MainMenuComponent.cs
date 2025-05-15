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

        }

        private void UpdateCurrency()
        {
            
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