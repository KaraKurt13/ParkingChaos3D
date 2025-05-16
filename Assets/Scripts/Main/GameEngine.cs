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

        public GameResultEnum GameResultEnum;
        public int ResultTime;

        private GameStateMachine _gameStateMachine;

        private int _basicCarsCount = 6;

        public int CarsCount;

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

        public void RestartLevel()
        {
            OnLevelEnd();
            GameInterfaceComponent.ResetInterface();
            LevelGenerator.ResetLevel();
            _gameStateMachine.Enter<GamePreparingState>();
        }

        public void PauseGame()
        {
            IsGamePaused = true;
        }

        public void ResumeGame()
        {
            IsGamePaused = false;
        }

        public void OnLevelLose()
        {
            OnLevelEnd();
            GameResultEnum = GameResultEnum.Lose;
            _gameStateMachine.Enter<GameEndingState>();
        }

        public void OnLevelWin(int ticksCount)
        {
            OnLevelEnd();
            GameResultEnum = GameResultEnum.Win;
            ResultTime = ticksCount;
            _gameStateMachine.Enter<GameEndingState>();
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
            GameInterfaceComponent.ResetInterface();
            LevelGenerator.ClearLevel();
            CarsCount = PlayerPrefs.GetInt(Constants.PrefsKey_LevelCount) + _basicCarsCount;
            _gameStateMachine.Enter<GameInitializationState>();
        }

        private void InitializeGame()
        {
            ResetAll();
            CarsCount = PlayerPrefs.GetInt(Constants.PrefsKey_LevelCount) + _basicCarsCount;
            _gameStateMachine = new GameStateMachine(this);
            _gameStateMachine.Enter<GameInitializationState>();
        }

        private void ResetAll()
        {
            GameInterfaceComponent.ResetInterface();
            LevelGenerator.ResetLevel();
        }
    }
}