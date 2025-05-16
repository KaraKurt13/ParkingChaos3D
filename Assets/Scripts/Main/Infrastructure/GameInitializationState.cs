using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main.Infrastructure
{
    public class GameInitializationState : IGameState
    {
        private LevelGenerator _levelGenerator;

        private GameStateMachine _gameStateMachine;

        public GameInitializationState(GameStateMachine gameStateMachine, LevelGenerator levelGenerator)
        {
            _levelGenerator = levelGenerator;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _levelGenerator.GenerateLevel();
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