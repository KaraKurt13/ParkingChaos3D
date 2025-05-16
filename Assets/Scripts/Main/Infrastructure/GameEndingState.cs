using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main.Infrastructure
{
    public class GameEndingState : IGameState
    {
        private GameEngine _engine;

        private GameInterfaceComponent _gameInterfaceComponent;

        public GameEndingState(GameEngine engine)
        {
            _engine = engine;
            _gameInterfaceComponent = engine.GameInterfaceComponent;
        }

        public void Enter()
        {
            if (_engine.GameResultEnum == GameResultEnum.Win)
                OnWin();
            else
                OnLose();
        }

        public void Exit()
        {
        }

        public void PhysicsUpdate()
        {
        }

        public void Update()
        {
        }

        private void OnLose()
        {
            _gameInterfaceComponent.HideTopPanel();
            _gameInterfaceComponent.GameEndingComponent.ShowLoseScreen();
        }

        private void OnWin()
        {
            var currentLevel = PlayerPrefs.GetInt(Constants.PrefsKey_LevelCount);
            var currentCoins = PlayerPrefs.GetInt(Constants.PrefsKey_CurrencyAmount);
            var bestTime = PlayerPrefs.GetInt(Constants.PrefsKey_BestTime);
            var time = _engine.ResultTime;
            currentLevel++;
            currentCoins += 5;

            if (bestTime == 0 || bestTime > time)
                PlayerPrefs.SetInt(Constants.PrefsKey_BestTime, time);
            PlayerPrefs.SetInt(Constants.PrefsKey_CurrencyAmount, currentCoins);
            PlayerPrefs.SetInt(Constants.PrefsKey_LevelCount, currentLevel);

            _gameInterfaceComponent.HideTopPanel();
            _gameInterfaceComponent.GameEndingComponent.DrawWinScreen();

        }
    }
}