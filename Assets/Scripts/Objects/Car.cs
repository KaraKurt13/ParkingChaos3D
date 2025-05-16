using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Objects
{
    public class Car : MonoBehaviour
    {
        public GameEngine Engine;

        public Transform Transform;

        public BoxCollider CarTrigger, HitTrigger;

        public bool IsSelected { get; private set; } = false;

        public LineRenderer Line;

        public UnityAction OnLeavingArea, OnHit;

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
            HitTrigger.enabled = true;
            _isMoving = true;
        }

        public void DeactivateMovement()
        {
            HitTrigger.enabled = false;
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
            ClearSelection();
            gameObject.SetActive(true);
        }

        private float _moveStep = 0.3f;

        private void MoveTick()
        {
            Transform.position += _moveDirection * _moveStep;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("GameArea"))
            {
                OnLeavingArea?.Invoke();
                Deactivate();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Car>(out var car))
            {
                OnHit?.Invoke();
                DeactivateMovement();
            }
        }
    }
}