using UnityEngine;

public sealed class StateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    public State CurrentState { get; private set; }

    private void Start()
    {
        ResetState(_startState);
    }

    private void ResetState(State newState)
    {
        CurrentState = newState;

        if (CurrentState != null)
        {
            CurrentState.Enter();
        }
    }

    private void Update()
    {
        if(CurrentState==null) return;

        State nextState = CurrentState.GetNextState();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Transit(State nextState)
    {
        if (CurrentState != null)
            CurrentState.Exit();
        
        CurrentState = nextState;
        
        if (CurrentState != null)
            CurrentState.Enter();
    }
}
