using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main.Infrastructure
{
    public class GameInitializationState : IGameState
    {
        private LevelGenerator _levelGenerator;

        private GameStateMachine _gameStateMachine;

        private int _basicCarsCount = 6;

        public GameInitializationState(GameStateMachine gameStateMachine, LevelGenerator levelGenerator)
        {
            _levelGenerator = levelGenerator;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            var carsCount = PlayerPrefs.GetInt(Constants.PrefsKey_LevelCount) + _basicCarsCount;
            _levelGenerator.GenerateLevel(carsCount);
            _gameStateMachine.Enter<GamePreparingState>();
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
    }
}