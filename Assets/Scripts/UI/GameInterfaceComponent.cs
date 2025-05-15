using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class GameInterfaceComponent : MonoBehaviour
    {
        public GameEngine GameEngine;

        public GameEndingComponent GameEndingComponent;

        [SerializeField] private GameObject _clickWaitingPanel, _pauseMenuPanel;

        private void Update()
        {
            if (GameEngine.IsGameActive)
                UpdateTimer();
        }

        public void ShowPauseMenuPanel()
        {
            _pauseMenuPanel.SetActive(true);
        }

        public void HidePauseMenuPanel()
        {
            _pauseMenuPanel.SetActive(false);
        }

        public void ShowClickWaitingPanel()
        {
            _clickWaitingPanel.SetActive(true);
        }

        public void HideClickWaitingPanel()
        {
            _clickWaitingPanel.SetActive(false);
        }

        public void ShowEndingScreen()
        {
            GameEndingComponent.DrawEndingResults();
            HideTopPanel();
        }

        [SerializeField] private GameObject _topPanel;
        [SerializeField] private TextMeshProUGUI _timerText, _levelNumberText;

        private void ShowTopPanel()
        {
            _topPanel.SetActive(true);
        }

        private void HideTopPanel()
        {
            _topPanel.SetActive(false);
        }

        private void UpdateTimer()
        {

        }
    }
}