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
            if(_raccoonController != null)
            {
                GameManager.GetInstance().CurrentPlayer.StopController();
                _raccoonController.StartStealing();
            }
            else
            {
                GameManager.GetInstance().CurrentPlayer.StopController();
                GameManager.GetInstance().CurrentPlayer.LoseLegs();
                GameManager.GetInstance().CurrentPlayer.GotHook();
            }

            
        }
    }
}