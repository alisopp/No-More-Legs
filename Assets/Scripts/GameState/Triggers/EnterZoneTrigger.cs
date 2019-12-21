using System;
using System.Collections.Generic;
using UnityEngine;

namespace NoMoreLegs.GameState.Triggers
{
    public class EnterZoneTrigger : MonoBehaviour
    {
        #region EDITOR_VARIABLES

        #endregion

        #region PRIVATE_VARIABLES

        private List<ITriggerListener> _triggerListeners;

        #endregion

        #region UNITY_LIFECYCLE

        private void Awake()
        {
            _triggerListeners = new List<ITriggerListener>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            for (int i = 0; i < _triggerListeners.Count; i++)
            {
                _triggerListeners[i].OnTriggerEnter();
            }
        }

        #endregion

        #region METHODS

        public void AddTriggerListener(ITriggerListener triggerListener)
        {
            _triggerListeners.Add(triggerListener);
        }

        #endregion
    }

}