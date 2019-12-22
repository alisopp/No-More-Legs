using System;
using UnityEngine;

namespace NoMoreLegs
{
    public class SpawnPoint : MonoBehaviour
    {
        #region EDITOR_VARIABLES

        [SerializeField]
        private bool _visited;
        #endregion

        #region PRIVATE_VARIABLES

        
        #endregion

        #region UNITY_LIFECYCLE
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_visited && other.tag.Equals("Player"))
            {
                _visited = true;
                GameManager.GetInstance().SetSpawnPoint(this);
            }
        }


        #endregion

        #region METHODS

        public Vector3 GetSpawnPosition()
        {
            return transform.position;
        }

        #endregion
    }

}