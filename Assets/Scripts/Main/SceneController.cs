using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Main
{
    public class SceneController : MonoBehaviour
    {
        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene("Game");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}