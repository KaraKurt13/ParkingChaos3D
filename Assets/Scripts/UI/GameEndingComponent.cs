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
            // draw
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