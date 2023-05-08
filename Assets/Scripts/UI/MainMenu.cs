using Sudoku.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Sudoku.Managers.GameManager;

namespace Sudoku.UI
{

    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button newGameButton;
        [SerializeField] private GameObject levelPanel;
        [SerializeField] private Button easyLevelButton;
        [SerializeField] private Button hardLevelButton;

        private void Awake()
        {
            levelPanel.SetActive(false);  
        }
        
        public void NewGame()
        {
            levelPanel.SetActive(true);
        }

        public void StartGame(int level)
        {
            GameManager.Instance.CurrentLevel = level == 0 ? Level.Easy : Level.Hard;
            SceneManager.LoadScene(1);
        }

    }

}
