namespace NoMoreLegs.GameState
{
    [System.Serializable]
    public class NoMoreLegState : GameState
    {
        public override void OnStateEnter()
        {
            GameManager.GetInstance().CurrentPlayer.LoseLegs();
        }
    }
}