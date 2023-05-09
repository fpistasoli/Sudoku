using Sudoku.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Sudoku.Managers.GameManager;

namespace Sudoku.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject levelPanel;

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