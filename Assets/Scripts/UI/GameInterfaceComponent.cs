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

        public void ResetInterface()
        {
            var levelNum = PlayerPrefs.GetInt(Constants.PrefsKey_LevelCount);
            _levelNumberText.text = $"Level {levelNum}";
            _timerText.text = "0:00";
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

        public void ShowTopPanel()
        {
            _topPanel.SetActive(true);
        }

        public void HideTopPanel()
        {
            _topPanel.SetActive(false);
        }

        public void UpdateTimer(int gameTicks)
        {

        }
    }
}