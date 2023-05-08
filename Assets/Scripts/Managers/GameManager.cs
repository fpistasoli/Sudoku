using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sudoku.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance => _instance;
        public enum Level { Easy, Hard };
        
        private static GameManager _instance;
        private static int _mistakes;
        private Level _currentLevel;


        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
                Mistakes = 0;
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

        public int Mistakes
        {
            get { return _mistakes; }
            set { _mistakes = value; }
        }





    }

}




