using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class LevelGenerator : MonoBehaviour
    {
        public GameEngine Engine;

        [SerializeField] private GameObject _carPrefab;
        [SerializeField] private Transform _spawnCenter;

        private List<Car> _cars = new();

        public void ResetLevel()
        {
            foreach (var car in _cars)
                car.ResetCar();
        }

        private int _gridSizeX = 12, _gridSizeY = 7;
        private float _spacing = 4.5f;
        private bool[,] _gridOccupied;

        public void GenerateLevel(int carsCount)
        {
            _gridOccupied = new bool[_gridSizeX, _gridSizeY];
            var halfX = _gridSizeX / 2;
            var halfY = _gridSizeY / 2;
            var gridPositions = new List<Vector3>();
            carsCount = Mathf.Clamp(carsCount, 5, halfX * halfY);

            for (int x = -halfX; x <= halfX; x++)
            {
                for (int y = -halfY; y <= halfY; y++)
                {
                    gridPositions.Add(new Vector3(x * _spacing, 1, y * _spacing));
                }
            }

            Vector3[] directions = {
                Vector3.forward,
                Vector3.back,
                Vector3.left,
                Vector3.right
                };
            var rotationOffset = Quaternion.Euler(0f, -90f, 0f);
            _cars = new();

            for (int i = 0; i < carsCount; i++)
            {
                var randomNum = Random.Range(0, gridPositions.Count);
                var pos = gridPositions[randomNum];
                var dir = directions[Random.Range(0, directions.Length)];
                var rotation = Quaternion.LookRotation(dir, Vector3.up) * rotationOffset;

                var car = Instantiate(_carPrefab, pos, rotation).GetComponent<Car>();
                car.Initialize(pos, dir);
                car.Engine = Engine;
                _cars.Add(car);
                gridPositions.Remove(pos);
            }
        }
    }
}