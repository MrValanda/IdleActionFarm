using DG.Tweening;
using UnityEngine;

public class BlockTower : MonoBehaviour
{
    [SerializeField] private ParticleSystem _blockPositionReached;
    [SerializeField] private Transform _spawnPoint;
    
    [SerializeField] private float _delayMoveAnimation;
    [SerializeField] private float _moveAnimationDuration;
    
    [SerializeField] private Ease _easeType; 
    [SerializeField] private bool _isUIAnimation;
    
    private int _countBlocks=1;
    private float _scaleY;

    public void AddNewBlock(Block newBlock)
    {        
        _scaleY = newBlock.BlockAnimator.EndScale.y;
        newBlock.BlockAnimator.InitMove(_spawnPoint, _moveAnimationDuration, _easeType, _delayMoveAnimation, _isUIAnimation);
        newBlock.BlockAnimator.StartAnimate();
        newBlock.BlockAnimator.PositionReached.AddListener(OnPositionReached);
    }

    public void ReduceBlocks(int count)
    {
        count = Mathf.Max(count, 0);
        _countBlocks -= count;
        AlignSpawnPointPosition();
    }
    public void AlignSpawnPointPosition()
    {
        _spawnPoint.position = GetPointBlockByCountBlocks(_countBlocks >0 ? _countBlocks-1 : _countBlocks);
    }

    private void OnPositionReached(BlockAnimator blockAnimator)
    {
        blockAnimator.SetPosition(_spawnPoint.position);
        _spawnPoint.position = GetPointBlockByCountBlocks(_countBlocks);
        _countBlocks++;
        blockAnimator.transform.parent = transform;
        blockAnimator.transform.localRotation = Quaternion.identity;
        blockAnimator.StopAnimate();
        blockAnimator.PositionReached.RemoveListener(OnPositionReached);
        Instantiate(_blockPositionReached, blockAnimator.transform.position, Quaternion.identity,
            blockAnimator.transform);
    }

    private Vector3 GetPointBlockByCountBlocks(int countBlocks)
    {
        return transform.position + transform.up.normalized *(countBlocks * _scaleY);
    }
}