using System;
using UnityEngine;

namespace NoMoreLegs.Winning
{
    public class WinningZone : MonoBehaviour
    {
        #region EDITOR_VARIABLES

        #endregion

        #region PRIVATE_VARIABLES
        
        

        #endregion

        #region UNITY_LIFECYCLE

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position, 2f);
        }

        #endregion

        #region METHODS

        private void OnTriggerEnter2D(Collider2D other)
        {
            GameManager.GetInstance().EndGame(true);
        }

        #endregion
    }

}