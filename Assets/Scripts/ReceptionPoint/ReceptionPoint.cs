using DG.Tweening;
using UnityEngine;

public class ReceptionPoint : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] protected ReceptionPoint _nextReceptionPoint;
    
    [SerializeField] private float _delayMoveAnimation;
    [SerializeField] private float _moveAnimationDuration;
    
    [SerializeField] private Ease _easeType; 
    [SerializeField] private bool _isUIAnimation; 
    
    public void InitBlockMove(BlockAnimator blockAnimator)
    {
        blockAnimator.InitMove(_target, _moveAnimationDuration, _easeType, _delayMoveAnimation, _isUIAnimation);
        blockAnimator.StartAnimate();
        blockAnimator.transform.parent = null;
        blockAnimator.PositionReached.AddListener(OnPositionReached);
    }
    private void OnPositionReached(BlockAnimator blockAnimator)
    {
        blockAnimator.StopAnimate();
        if (_nextReceptionPoint == null)
            PositionReachedAndNoReceptionPoint(blockAnimator);
        else
            PositionReachedAndHasReceptionPoint(blockAnimator);
        blockAnimator.PositionReached.RemoveListener(OnPositionReached);
    }

    protected virtual void PositionReachedAndNoReceptionPoint(BlockAnimator blockAnimator)
    {
       Destroy(blockAnimator.gameObject);
    }
    protected virtual void PositionReachedAndHasReceptionPoint(BlockAnimator blockAnimator)
    {
        _nextReceptionPoint.InitBlockMove(blockAnimator);

    }
}