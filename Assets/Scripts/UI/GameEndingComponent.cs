using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class GameEndingComponent : MonoBehaviour
    {
        public GameEngine Engine;

        [SerializeField] private GameObject _winPanel, _losePanel;
        [SerializeField] private TextMeshProUGUI _resultText;

        public void DrawWinScreen()
        {
            var time = Engine.ResultTime;
            var convertedTime = TimeHelper.TicksToSeconds(time);
            var minutes = (int)(convertedTime / 60);
            var seconds = (int)(convertedTime % 60);
            var totalCoins = PlayerPrefs.GetInt(Constants.PrefsKey_CurrencyAmount);
            _resultText.text = $"Time: {minutes:D2}:{seconds:D2}. Earned 5$! (Total: {totalCoins})$";

            ShowWinScreen();
        }

        public void ShowLoseScreen()
        {
            _losePanel.SetActive(true);
        }

        private void ShowWinScreen()
        {
            _winPanel.SetActive(true);
        }

        public void HideAll()
        {
            _winPanel.SetActive(false);
            _losePanel.SetActive(false);
        }
    }
}