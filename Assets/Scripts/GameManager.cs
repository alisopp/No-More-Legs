using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Cinemachine;

namespace NoMoreLegs
{
    public class GameManager : MonoBehaviour
    {
        #region EDITOR_VARIABLES

        [SerializeField] private PlayerController _playerPrefab;
        [SerializeField] private Transform _startPosition;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        #endregion

        #region PRIVATE_VARIABLES

        private static GameManager _instance;


        private PlayerController _currentPlayer;
        private bool _isPaused;
        private bool _isStarted;
        private List<IGameWinListener> _gameWinListeners;
        private List<IGameLoseListener> _gameLoseListeners;

        public PlayerController CurrentPlayer => _currentPlayer;

        #endregion

        #region UNITY_LIFECYCLE

        public static GameManager GetInstance()
        {
            return _instance;
        }

        private void Awake()
        {
            _gameWinListeners  = new List<IGameWinListener>();
            _gameLoseListeners = new List<IGameLoseListener>();
            _instance = this;
            _isStarted = false;
        }

        private void Start()
        {
            PauseGame();
        }

        #endregion

        #region METHODS

        

        public void StartGame()
        {
            if (!_isStarted)
            {
                _currentPlayer = Instantiate(_playerPrefab.gameObject).GetComponent<PlayerController>();
                _currentPlayer.transform.position = _startPosition.position;
                _isStarted = true;
                var vcam = _virtualCamera; //cinemachine reference
                vcam.LookAt = _currentPlayer.transform;
                vcam.Follow = _currentPlayer.transform;
                ResumeGame();
            }

        }

        public void EndGame(bool wonGame)
        {
            if (wonGame)
            {
                for (int i = 0; i < _gameWinListeners.Count; i++)
                {
                    _gameWinListeners[i].OnGameWin();
                }
            }
            else
            {
                for (int i = 0; i < _gameLoseListeners.Count; i++)
                {
                    _gameLoseListeners[i].OnGameLose();
                }
            }
        }

        public void OnDamageCollision(GameObject gameObject)
        {
            if (gameObject == _currentPlayer.gameObject)
            {
                EndGame(false);
                //TODO change to use an animation instead
                Destroy(_currentPlayer.gameObject);
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

        public void AddGameWinListener(IGameWinListener listener)
        {
            _gameWinListeners.Add(listener);
        }

        public void AddGameLoseListener(IGameLoseListener listener)
        {
            _gameLoseListeners.Add(listener);
        }

        #endregion
    }

}