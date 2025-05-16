using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main.Infrastructure
{
    public class GamePreparingState : IGameState
    {
        private GameInterfaceComponent _gameInterfaceComponent;

        private GameStateMachine _gameStateMachine;

        private InputController _inputController;

        public GamePreparingState(GameStateMachine gameStateMachine, GameEngine engine)
        {
            _gameStateMachine = gameStateMachine;
            _gameInterfaceComponent = engine.GameInterfaceComponent;
            _inputController = engine.InputController;
        }

        public void Enter()
        {
            _gameInterfaceComponent.ShowClickWaitingPanel();
        }

        public void Exit()
        {
            _gameInterfaceComponent.HideClickWaitingPanel();
        }

        public void PhysicsUpdate()
        {
        }

        public void Update()
        {
            if (_inputController.IsMouseClicked())
            {
                _gameStateMachine.Enter<GameLoopState>();
            }
        }
    }
}