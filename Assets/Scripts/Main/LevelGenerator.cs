using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class LevelGenerator : MonoBehaviour
    {
        public GameEngine Engine;

        public List<Car> Cars = new();

        [SerializeField] private GameObject _carPrefab;
        [SerializeField] private Transform _spawnCenter;

        public void ResetLevel()
        {
            foreach (var car in Cars)
                car.ResetCar();
        }

        public void ClearLevel()
        {
            foreach (var car in Cars.ToList())
                Destroy(car.gameObject);

            Cars.Clear();
        }

        private int _gridSizeX = 12, _gridSizeY = 7;
        private float _spacing = 4.5f;

        public void GenerateLevel()
        {
            var halfX = _gridSizeX / 2;
            var halfY = _gridSizeY / 2;
            var gridPositions = new List<Vector3>();
            var carsCount = Mathf.Clamp(Engine.CarsCount, 5, halfX * halfY);

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
            Cars = new();

            for (int i = 0; i < carsCount; i++)
            {
                var randomNum = Random.Range(0, gridPositions.Count);
                var pos = gridPositions[randomNum];
                var dir = directions[Random.Range(0, directions.Length)];
                var rotation = Quaternion.LookRotation(dir, Vector3.up) * rotationOffset;

                var car = Instantiate(_carPrefab, pos, rotation).GetComponent<Car>();
                car.Initialize(pos, dir);
                car.Engine = Engine;
                Cars.Add(car);
                gridPositions.Remove(pos);
            }
        }
    }
}