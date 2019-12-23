using Interfaces;
using UnityEngine;

namespace NoMoreLegs.Winning
{
    public class ShowGameWinningPanel : MonoBehaviour, IGameWinListener
    {
        #region EDITOR_VARIABLES

        [SerializeField] private GameObject _winGamePanel;

        #endregion

        #region PRIVATE_VARIABLES

        #endregion

        #region UNITY_LIFECYCLE

        private void Awake()
        {
            _winGamePanel.SetActive(false);
        }

        private void Start()
        {
            GameManager.GetInstance().AddGameWinListener(this);
        }

        #endregion

        #region METHODS

        #endregion

        public void OnGameWin()
        {
            _winGamePanel.SetActive(true);
        }
    }

}