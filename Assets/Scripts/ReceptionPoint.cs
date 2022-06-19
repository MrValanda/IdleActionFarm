using DG.Tweening;
using UnityEngine;

public class ReceptionPoint : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private ReceptionPoint _nextReceptionPoint;
    
    [SerializeField] private float _delayTakeNextBlock;
    [SerializeField] private float _moveAnimationDuration;
    
    [SerializeField] private Ease _easeType; 
    [SerializeField] private bool _isUIAnimation; 
    
    public void InitBlockMove(BlockAnimator blockAnimator)
    {
        blockAnimator.InitMove(_target, _moveAnimationDuration, _easeType, _delayTakeNextBlock, _isUIAnimation);
        blockAnimator.transform.parent = null;
        blockAnimator.PositionReached.AddListener(OnPositionReached);
    }
    private void OnPositionReached(BlockAnimator blockAnimator)
    {
        blockAnimator.StopAnimate();
        if (_nextReceptionPoint == null)
            Destroy(blockAnimator.gameObject);
        else
            _nextReceptionPoint.InitBlockMove(blockAnimator);
        blockAnimator.PositionReached.RemoveListener(OnPositionReached);
    }
}