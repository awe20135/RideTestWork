namespace Assets.Scripts.Systems.Control.StateMachine
{
    public class StateMachine
    {
        public State CurrentState { get; private set; }

        public void Initialize(State startSlotState)
        {
            CurrentState = startSlotState;
            CurrentState.Enter();
        }

        public void ChangeState(State newSlotState)
        {
            if (newSlotState == CurrentState)
                return;

            CurrentState.Exit();
            CurrentState = newSlotState;
            CurrentState.Enter();
        }
    }
}
