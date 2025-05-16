using Assets.Scripts.Objects;
using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main.Infrastructure
{
    public class GameLoopState : IGameState
    {
        private GameEngine _engine;

        private GameStateMachine _gameStateMachine;

        private GameInterfaceComponent _gameInterfaceComponent;

        private InputController _inputController;

        public GameLoopState(GameStateMachine gameStateMachine, GameEngine engine)
        {
            _gameStateMachine = gameStateMachine;
            _engine = engine;
            _gameInterfaceComponent = engine.GameInterfaceComponent;
            _inputController = engine.InputController;
        }

        public void Enter()
        {
            _gameInterfaceComponent.ShowTopPanel();
            _gameTicks = 0;
            _engine.OnLevelStart();
        }

        public void Exit()
        {
        }

        private int _gameTicks = 0;

        public void PhysicsUpdate()
        {
            if (_engine.IsGameActive())
            {
                _gameTicks++;
                _gameInterfaceComponent.UpdateTimer(_gameTicks);
            }
        }

        private Car _selectedCar;

        public void Update()
        {
            if (_inputController.IsMouseClicked())
            {
                if (_inputController.TryGetClickedCar(out var car))
                {
                    if (_selectedCar != null)
                    {
                        if (_selectedCar == car)
                        {
                            car.ActivateMovement();
                            _selectedCar.ClearSelection();
                        }
                        else
                        {
                            _selectedCar.ClearSelection();
                            _selectedCar = car;
                            _selectedCar.Select();
                        }
                    }
                    else
                    {
                        _selectedCar = car;
                        _selectedCar.Select();
                    }
                }
                else
                {
                    _selectedCar?.ClearSelection();
                    _selectedCar = null;
                }
            }
        }
    }
}