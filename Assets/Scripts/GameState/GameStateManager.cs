using System;
using UnityEngine;

namespace NoMoreLegs.GameState
{
    public class GameStateManager : MonoBehaviour
    {
        #region EDITOR_VARIABLES

        [SerializeField] private GameState[] _gameStates;
        [SerializeField] private int _currentIndex = 0;
        #endregion

        #region PRIVATE_VARIABLES

        private static GameStateManager _instance;

        #endregion

        #region UNITY_LIFECYCLE

        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            for (int i = 0; i < _gameStates.Length; i++)
            {
                _gameStates[i].Init();
            }
            _gameStates[_currentIndex].OnStateEnter();
        }

        private void Update()
        {
            int activatedStateIndex = _gameStates[_currentIndex].RunTransitions();
            if (activatedStateIndex > -1)
            {
                SwitchState(activatedStateIndex);
            }
        }

        private void SwitchState(int newStateIndex)
        {
            _gameStates[_currentIndex].OnStateExit();
            _currentIndex = newStateIndex;
            _gameStates[_currentIndex].OnStateEnter();
        }

        #endregion

        #region METHODS

        public static GameStateManager GetInstance()
        {
            return _instance;
        }
        
        #endregion
    }

}