namespace NoMoreLegs.GameState
{
    [System.Serializable]
    public class TransitionLoseLegs : Transition
    {
        public override bool RunTransition()
        {
            return false;
        }
    }
}