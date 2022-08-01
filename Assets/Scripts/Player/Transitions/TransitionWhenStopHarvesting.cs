using UnityEngine;

public class TransitionWhenStopHarvesting : Transition
{
    [SerializeField] private HarvestingState _harvestingState;
    protected override void Enable()
    {
        _harvestingState.StopHarvest.AddListener(OnStopHarvest);
    }

    protected override void Disable()
    {
        _harvestingState.StopHarvest.RemoveListener(OnStopHarvest);
    }

    private void OnStopHarvest()
    {
        NeedTransit = true;
    }
}
