using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class InputController : MonoBehaviour
    {
        private Camera _mainCamera;

        void Awake()
        {
            if (_mainCamera == null)
                _mainCamera = Camera.main;
        }

        public bool IsMouseClicked()
        {
            return Input.GetMouseButtonDown(0);
        }

        public bool TryGetClickedCar(out Car car, float maxDistance = 100f)
        {
            car = null;

            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance))
            {
                car = hitInfo.collider.GetComponent<Car>();
                return car != null;
            }

            return false;
        }
    }
}