using System;
using UnityEngine;

namespace NoMoreLegs
{
    public class GameManager : MonoBehaviour
    {
        #region EDITOR_VARIABLES

        #endregion

        #region PRIVATE_VARIABLES

        private static GameManager _instance;

        #endregion

        #region UNITY_LIFECYCLE

        private void Awake()
        {
            _instance = this;
        }

        #endregion

        #region METHODS

        #endregion
    }

}