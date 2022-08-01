using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [field: SerializeField] public State NextState { get; private set; }

    public bool NeedTransit { get; protected set; }

    private void OnEnable()
    {
        NeedTransit = false;
        Enable();
    }
    private void OnDisable()
    {
        Disable();
    }

    protected abstract void Enable();
    protected abstract void Disable();
}
