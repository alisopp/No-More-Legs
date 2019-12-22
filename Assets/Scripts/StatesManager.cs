using System;
using TMPro;
using UnityEngine;

namespace NoMoreLegs
{
    public class StatesManager : MonoBehaviour
    {
        #region EDITOR_VARIABLES

        [SerializeField] private TextMeshProUGUI _triesLabel;
        [SerializeField] private TextMeshProUGUI _timeLabel;

        #endregion

        #region PRIVATE_VARIABLES

        public static StatesManager Instance;

        private int _currentTries;
        private float _currentTime;
        
        #endregion

        #region UNITY_LIFECYCLE

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            
        }

        #endregion

        #region METHODS

        public void IncreaseTries()
        {
            _currentTries++;
            _triesLabel.text = "Tries: " + _currentTries;
        }

        #endregion
    }

}