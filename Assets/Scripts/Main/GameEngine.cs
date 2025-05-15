using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class GameEngine : MonoBehaviour
    {
        public GameInterfaceComponent GameInterfaceComponent;

        public bool IsGameActive = false;

        public void PauseGame()
        {
            IsGameActive = false;
            GameInterfaceComponent.ShowPauseMenuPanel();
        }

        private void Start()
        {
            
        }

        private void InitializeGame()
        {
            // Initialize gamestatemaching
            // Generate level
            // Enter 
        }
    }
}