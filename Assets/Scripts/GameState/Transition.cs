using UnityEngine;

namespace NoMoreLegs.GameState
{
    [System.Serializable]
    public class Transition : MonoBehaviour
    {
        public virtual void Init()
        {
            
        }

        /// <summary>
        /// Checks if this transition is fulfilled
        /// </summary>
        /// <returns></returns>
        public virtual bool RunTransition()
        {
            return false;
        }
    }
}