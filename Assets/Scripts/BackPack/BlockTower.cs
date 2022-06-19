using UnityEngine;

public class BlockTower : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    private int _countBlocks=1;
    private float _scaleY;

    public void AddNewBlock(Block newBlock)
    {        
        _scaleY = newBlock.BlockAnimator.EndScale.y;
        newBlock.BlockAnimator.InitMove(_spawnPoint);
        newBlock.BlockAnimator.StartAnimate();
        newBlock.BlockAnimator.PositionReached.AddListener(OnPositionReached);
    }

    public void RemoveLastBlock()
    {
        _countBlocks = _countBlocks - 1 == 0 ? 1 : _countBlocks - 1;
        print(_countBlocks);
        _spawnPoint.position = GetPointBlockByCountBlocks(_countBlocks-1);

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
    }

    
    public Vector3 GetPointBlockByCountBlocks(int countBlocks)
    {
        return new Vector3(transform.position.x,
            transform.position.y+countBlocks * _scaleY,
            transform.position.z);
    }
    
}