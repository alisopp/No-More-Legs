using UnityEngine;

namespace NoMoreLegs
{
    public class SceneManagerConnector : MonoBehaviour
    {
        #region EDITOR_VARIABLES

        #endregion

        #region PRIVATE_VARIABLES

        #endregion

        #region UNITY_LIFECYCLE

        #endregion

        #region METHODS

        public void StartGame(int sceneIndex)
        {
            SceneGameManager.Instance.loadLevel(sceneIndex);
        }

        #endregion
    }

}