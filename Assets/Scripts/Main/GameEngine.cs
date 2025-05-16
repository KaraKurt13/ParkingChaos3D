using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class GameEngine : MonoBehaviour
    {
        public GameInterfaceComponent GameInterfaceComponent;

        public LevelGenerator LevelGenerator;

        public bool IsGamePaused = false, IsGameStarted = false;

        private void Start()
        {
            InitializeGame();
        }

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

        public void OnGameCompletition()
        {

        }

        public void InializeNextLevel()
        {
            LevelGenerator.ResetLevel();
            var carsCount = PlayerPrefs.GetInt(Constants.PrefsKey_LevelCount) + 6;
            LevelGenerator.GenerateLevel(carsCount);
        }

        private void InitializeGame()
        {
            Debug.Log(PlayerPrefs.GetInt(Constants.PrefsKey_LevelCount));
            var carsCount = PlayerPrefs.GetInt(Constants.PrefsKey_LevelCount) + 6;
            LevelGenerator.GenerateLevel(carsCount);
            // Initialize gamestatemaching
            // Generate level
            // Enter 
        }
    }
}