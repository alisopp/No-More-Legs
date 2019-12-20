using System;
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
        }

        public void EndGame()
        {
            
        }

        public void PauseGame()
        {
            
        }

        #endregion
    }

}