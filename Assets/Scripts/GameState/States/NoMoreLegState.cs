using NoMoreLegs.Raccoon;
using UnityEngine;

namespace NoMoreLegs.GameState
{
    [System.Serializable]
    public class NoMoreLegState : GameState
    {
        [SerializeField] private RaccoonController _raccoonController;
        public override void OnStateEnter()
        {
            GameManager.GetInstance().CurrentPlayer.StopController();
            _raccoonController.StartStealing();
            
        }
    }
}