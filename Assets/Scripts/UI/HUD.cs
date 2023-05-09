using Sudoku.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Sudoku.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private Text levelValue;
        [SerializeField] private Text mistakesValue;

        private void OnEnable()
        {
            GameManager.mistakesUpdate += OnMistakesUpdateUI;
        }

        void Start()
        {
            levelValue.text = GameManager.Instance.CurrentLevel.ToString();
        }

        private void OnDisable()
        {
            GameManager.mistakesUpdate -= OnMistakesUpdateUI;
        }

        private void OnMistakesUpdateUI()
        {
            mistakesValue.text = GameManager.Instance.Mistakes.ToString();
        }
    }
}