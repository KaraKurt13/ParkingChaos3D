using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class Car : MonoBehaviour
    {
        public GameEngine Engine;

        public Transform Transform;

        public BoxCollider TriggerCollider;

        public bool IsSelected { get; private set; } = false;

        public LineRenderer Line;

        private bool _isMoving = false;

        private Vector3 _spawnPosition;

        private Vector3 _moveDirection;

        private void FixedUpdate()
        {
            if (_isMoving && Engine.IsGameActive())
                MoveTick();
        }

        public void Select()
        {
            IsSelected = true;
            Line.enabled = true;
        }

        public void ClearSelection()
        {
            IsSelected = false;
            Line.enabled = false;
        }

        public void Initialize(Vector3 position, Vector3 moveDirection)
        {
            _spawnPosition = position;
            _moveDirection = moveDirection;
        }

        public void ActivateMovement()
        {
            _isMoving = true;
        }

        public void DeactivateMovement()
        {
            _isMoving = false;
        }

        public void Deactivate()
        {
            _isMoving = false;
            gameObject.SetActive(false);
        }

        public void ResetCar()
        {
            Transform.position = _spawnPosition;
            DeactivateMovement();
            gameObject.SetActive(true);
        }

        private float _moveStep = 0.1f;

        private void MoveTick()
        {
            Transform.position += _moveDirection * _moveStep;
        }
    }
}