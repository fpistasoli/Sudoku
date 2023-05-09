using Sudoku.Managers;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Sudoku.UI
{
    public class GameWin : MonoBehaviour
    {
        [SerializeField] private GameObject mistakesCount;
        [SerializeField] private Button backToMenuButton;
        [SerializeField] private GameObject winCharacterUnitPrefab;
        [SerializeField] private float cooldownTimerBackToMenuButton;

        void Start()
        {
            mistakesCount.GetComponent<Text>().text = GameManager.Instance.Mistakes.ToString();
            backToMenuButton.gameObject.SetActive(false);

            var winCharacterUnitGO = Instantiate(winCharacterUnitPrefab);
            
            StartCoroutine(ShowBackToMenuButton());
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene(0);
            GameManager.Instance.Mistakes = 0;
        }

        private IEnumerator ShowBackToMenuButton()
        {
            yield return new WaitForSeconds(cooldownTimerBackToMenuButton);

            backToMenuButton.gameObject.SetActive(true);
        }
    }
}


