using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sudoku.Managers
{
    public class GameManager : MonoBehaviour
    {
        public enum Level { Easy, Hard };
        public static int _mistakes;
        public static GameManager Instance => _instance;

        private static GameManager _instance;
        private Level _currentLevel;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
                _mistakes = 0;
            }
            else
            {
                Destroy(gameObject);
            }

        }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public Level CurrentLevel
        {
            get { return _currentLevel; }
            set { _currentLevel = value; }
        }



    }

}




