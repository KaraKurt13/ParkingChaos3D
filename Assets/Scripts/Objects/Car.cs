using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class Car : MonoBehaviour
    {
        public Transform Transform;

        public BoxCollider TriggerCollider;

        private bool _isMoving = false;

        private Vector3 _spawnPosition;

        private Vector3 _moveDirection;

        private void FixedUpdate()
        {
            if (_isMoving)
                MoveTick();
        }

        public void Initialize(Vector3 position)
        {
            _spawnPosition = position;
            _moveDirection = Vector3.forward;
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

        private void MoveTick()
        {

        }
    }
}