using UnityEngine;

public class MoveAnimationController : AnimationController
{
    private static readonly int Speed = Animator.StringToHash("Speed");

    public void SetCurrentSpeed(float speed)
    {
        _animator.SetFloat(Speed, speed);
    }
}
