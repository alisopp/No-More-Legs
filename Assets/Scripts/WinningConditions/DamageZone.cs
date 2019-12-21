using UnityEngine;

namespace NoMoreLegs.Winning
{
    public class DamageZone : MonoBehaviour
    {
        #region EDITOR_VARIABLES

        #endregion

        #region PRIVATE_VARIABLES

        #endregion

        #region UNITY_LIFECYCLE

        #endregion

        #region METHODS

        private void OnTriggerEnter2D(Collider2D other)
        {
            GameManager.GetInstance().OnDamageCollision(other.gameObject);
        }

        #endregion
    }

}