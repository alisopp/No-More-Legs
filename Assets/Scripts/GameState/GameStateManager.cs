using UnityEngine;

namespace NoMoreLegs.GameState
{
    public class GameStateManager : MonoBehaviour
    {
        #region EDITOR_VARIABLES

        [SerializeField] private GameState[] _gameStates;

        #endregion

        #region PRIVATE_VARIABLES

        private static GameStateManager _instance;

        #endregion

        #region UNITY_LIFECYCLE

        private void Awake()
        {
            _instance = this;
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