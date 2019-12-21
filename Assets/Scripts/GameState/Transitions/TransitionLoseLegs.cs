using NoMoreLegs.GameState.Triggers;
using UnityEngine;

namespace NoMoreLegs.GameState
{
    [System.Serializable]
    public class TransitionLoseLegs : Transition, ITriggerListener
    {
        [SerializeField] private EnterZoneTrigger _trigger;


        private bool _triggered;
        public override void Init()
        {
            _trigger.AddTriggerListener(this);
            _triggered = false;
        }

        public override bool RunTransition()
        {
            return _triggered;
        }

        public void OnTriggerEnter()
        {
            _triggered = true;
        }
    }
}