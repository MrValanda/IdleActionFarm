using UnityEngine;
using UnityEngine.Events;

public class HarvestingState : MoveState
{
    [SerializeField] private int _harvestSpeed;
    [SerializeField] private Slicer _slicer;
    [SerializeField] private HarvestingAnimationController _harvestingAnimationController;

    public UnityEvent StartHarvest;
    public UnityEvent StopHarvest;
    
     protected override void Start()
    {
        base.Start();
        _harvestingAnimationController.SetHarvestingSpeed(_harvestSpeed);
    }
    
    public void StartSlice()
    {
        _slicer.StartSlice();
    }

    public void StopSlice()
    {
        _slicer.StopSlice();
    }
    
    public void StartHarvesting()
    {
        _slicer.gameObject.SetActive(true);
        StartHarvest?.Invoke();
    }
    public void StopHarvesting()
    {
        _slicer.gameObject.SetActive(false);
        _harvestingAnimationController.SetHarvestingTrigger(false);
        StopHarvest?.Invoke();
    }

    protected override void OnEnter()
    {
        _harvestingAnimationController.SetHarvestingTrigger(true);
    }

    protected override void OnExit()
    {
        
    }
}
