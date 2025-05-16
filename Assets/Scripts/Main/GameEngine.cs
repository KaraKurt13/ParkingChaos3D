using Assets.Scripts.Main.Infrastructure;
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

        public InputController InputController;

        public bool IsGamePaused = false, IsGameStarted = false;

        private GameStateMachine _gameStateMachine;

        private void Start()
        {
            InitializeGame();
        }

        private void Update()
        {
            _gameStateMachine.UpdateState();
        }

        private void FixedUpdate()
        {
            _gameStateMachine.UpdateStatePhysics();
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

        public void OnLevelStart()
        {
            IsGameStarted = true;
        }

        public void OnLevelEnd()
        {
            ResumeGame();
            IsGameStarted = false;
        }

        public void InializeNextLevel()
        {
            LevelGenerator.ResetLevel();
            var carsCount = PlayerPrefs.GetInt(Constants.PrefsKey_LevelCount) + 6;
            LevelGenerator.GenerateLevel(carsCount);
        }

        private void InitializeGame()
        {
            ResetAll();
            _gameStateMachine = new GameStateMachine(this);
            _gameStateMachine.Enter<GameInitializationState>();
            // Initialize gamestatemaching
            // Enter 
        }

        private void ResetAll()
        {
            GameInterfaceComponent.ResetInterface();
            LevelGenerator.ResetLevel();
        }
    }
}