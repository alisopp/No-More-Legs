using UnityEngine;

namespace NoMoreLegs.GameState
{
    [System.Serializable]
    public class GameState : MonoBehaviour
    {
        [SerializeField] protected StateTransition[] _transitions;


        public virtual void OnStateEnter()
        {
        }

        public virtual void OnStateExit()
        {
        }

        /// <summary>
        /// Checks transitions and returns the index of the following state of the first fulfilled transition
        /// </summary>
        /// <returns>-1 if no transition is fulfilled or the index of the first state which transition is fulfilled</returns>
        public int RunTransitions()
        {
            for (int i = 0; i < _transitions.Length; i++)
            {
                if (_transitions[i].Transition.RunTransition())
                {
                    return _transitions[i].FollowingGameStateIndex;
                }
            }

            return -1;
        }
    }
}