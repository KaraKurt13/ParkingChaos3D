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
            _remainingCars = _engine.CarsCount;
            _playerHealth = 3;
            foreach (var car in _engine.LevelGenerator.Cars)
            {
                car.OnHit += OnCarHit;
                car.OnLeavingArea += OnCarLeavingArea;
            }
            _engine.OnLevelStart();
        }

        public void Exit()
        {
            _gameTicks = 0;
            foreach (var car in _engine.LevelGenerator.Cars)
            {
                car.OnHit -= OnCarHit;
                car.OnLeavingArea -= OnCarLeavingArea;
            }
        }

        private int _gameTicks = 0, _playerHealth, _remainingCars;

        private void OnCarLeavingArea()
        {
            _remainingCars--;
            Debug.Log($"Car left! Remaining cars: {_remainingCars}");
            if (_remainingCars == 0)
                _engine.OnLevelWin(_gameTicks);
        }

        private bool _receivedDamaged = false;

        private void OnCarHit()
        {
            if (_receivedDamaged) return;

            _playerHealth--;
            _receivedDamaged = true;
            Debug.Log($"Car hit! Remaining health: {_playerHealth}");
            if (_playerHealth <= 0)
                _engine.OnLevelLose();
        }

        public void PhysicsUpdate()
        {
            if (_engine.IsGameActive())
            {
                _receivedDamaged = false;
                _gameTicks++;
            }
        }

        private Car _selectedCar;

        public void Update()
        {
            if (!_engine.IsGameActive())
                return;

            _gameInterfaceComponent.UpdateStatistics(_gameTicks, _playerHealth, _remainingCars);

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
                            _selectedCar = null;
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