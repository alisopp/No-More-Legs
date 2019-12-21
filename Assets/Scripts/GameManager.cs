using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace NoMoreLegs
{
    public class GameManager : MonoBehaviour
    {
        #region EDITOR_VARIABLES

        [SerializeField] private PlayerController _playerPrefab;
        [SerializeField] private Transform _startPosition;

        #endregion

        #region PRIVATE_VARIABLES

        private static GameManager _instance;


        private PlayerController _currentPlayer;
        private bool _isPaused;
        private List<IGameEndListener> _gameEndListeners = new List<IGameEndListener>();

        #endregion

        #region UNITY_LIFECYCLE

        public static GameManager GetInstance()
        {
            return _instance;
        }

        private void Awake()
        {
            _instance = this;
        }

        #endregion

        #region METHODS


        public void StartGame()
        {
            _currentPlayer = Instantiate(_playerPrefab.gameObject).GetComponent<PlayerController>();
            _currentPlayer.transform.position = _startPosition.position;
        }

        public void EndGame(bool wonGame)
        {
            if (wonGame)
            {
                for (int i = 0; i < _gameEndListeners.Count; i++)
                {
                    _gameEndListeners[i].OnGameEnd();
                }
            }
            else
            {
                
            }

        }

        public void ResumeGame()
        {
            Time.timeScale = 1f;
        }
        public void PauseGame()
        {
            Time.timeScale = 0f;
        }

        public void SwitchGameState()
        {
            if (_isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        #endregion
    }

}