namespace NoMoreLegs.GameState
{
    [System.Serializable]
    public class TransitionGotLegs : Transition
    {
        public override bool RunTransition()
        {
            return false;
        }
    }
}