using UnityEngine;

namespace NoMoreLegs
{
    public class GameManagerConnector : MonoBehaviour
    {
        #region EDITOR_VARIABLES

        #endregion

        #region PRIVATE_VARIABLES

        #endregion

        #region UNITY_LIFECYCLE
        

        #endregion

        #region METHODS

        public void Respawn()
        {
            GameManager.GetInstance().ResetGame();
        }

        #endregion
    }

}