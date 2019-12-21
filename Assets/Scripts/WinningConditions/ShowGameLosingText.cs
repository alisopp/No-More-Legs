using System;
using Interfaces;
using TMPro;
using UnityEngine;

namespace NoMoreLegs.Winning
{
    public class ShowGameLosingText : MonoBehaviour, IGameLoseListener
    {
        #region EDITOR_VARIABLES

        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private string _losingText;

        #endregion

        #region PRIVATE_VARIABLES

        #endregion

        #region UNITY_LIFECYCLE
        
        
        private void Start()
        {
            GameManager.GetInstance().AddGameLoseListener(this);
            _text.gameObject.SetActive(false);
        }

        #endregion

        #region METHODS

        public void OnGameLose()
        {
            _text.text = _losingText;
            _text.gameObject.SetActive(true);
        }

        #endregion
    }
}