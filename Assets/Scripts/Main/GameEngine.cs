using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class GameEngine : MonoBehaviour
    {
        public GameInterfaceComponent GameInterfaceComponent;

        public bool IsGamePaused = false, IsGameStarted = false;

        public bool IsGameActive()
        {
            return !IsGamePaused && IsGameStarted;
        }

        public void PauseGame()
        {
            IsGamePaused = true;
        }

        public void ResumeGame()
        {
            IsGamePaused = false;
        }

        private void Start()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Initialize gamestatemaching
            // Generate level
            // Enter 
        }
    }
}