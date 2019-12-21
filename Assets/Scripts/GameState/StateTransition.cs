namespace NoMoreLegs.GameState
{
    [System.Serializable]
    public struct StateTransition
    {
        public Transition Transition;
        public int FollowingGameStateIndex;
    }
}