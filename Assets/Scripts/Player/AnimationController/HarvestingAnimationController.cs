using UnityEngine;

public class HarvestingAnimationController : AnimationController
{
    private static readonly int HarvestingTriggerId = Animator.StringToHash("NeedHarvesting");
    private static readonly int HarvestingSpeed = Animator.StringToHash("HarvestingSpeed");
    
    public void SetHarvestingTrigger(bool trigger)
    {
        _animator.SetBool(HarvestingTriggerId, trigger);
    }

    public void SetHarvestingSpeed(float speed)
    {
        _animator.SetFloat(HarvestingSpeed, speed);
    }
}
