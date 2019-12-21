using Interfaces;
using TMPro;
using UnityEngine;

namespace NoMoreLegs.Winning
{
    public class ShowGameWinningText : MonoBehaviour, IGameWinListener
    {
        #region EDITOR_VARIABLES

        [SerializeField] private TextMeshProUGUI _winningText;
        [SerializeField] private string _textToShow;

        #endregion

        #region PRIVATE_VARIABLES

        #endregion

        #region UNITY_LIFECYCLE

        private void Start()
        {
            _winningText.gameObject.SetActive(false);
            GameManager.GetInstance().AddGameWinListener(this);
        }

        #endregion

        #region METHODS

        public void OnGameWin()
        {
            _winningText.text = _textToShow;
            _winningText.gameObject.SetActive(true);
        }
        
        #endregion


    }

}