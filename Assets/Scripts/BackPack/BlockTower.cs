using UnityEngine;

public class BlockTower : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    private int _countBlocks=1;
    private float _scaleY;

    public void AddNewBlock(Block newBlock)
    {        
        _scaleY = newBlock.EndScale.y;
        newBlock.InitMove(_spawnPoint);
        newBlock.StartAnimate();
        newBlock.PositionReached.AddListener(OnPositionReached);
    }

    public void RemoveLastBlock()
    {
        _countBlocks = _countBlocks - 1 == 0 ? 1 : _countBlocks - 1;
        print(_countBlocks);
        _spawnPoint.position = GetPointBlockByCountBlocks(_countBlocks-1);

    }

    private void OnPositionReached(Block block)
    {
        block.SetPosition(_spawnPoint.position);
        _spawnPoint.position = GetPointBlockByCountBlocks(_countBlocks);
        _countBlocks++;
        block.transform.parent = transform;
        block.transform.localRotation = Quaternion.identity;
        block.StopAnimate();
        block.PositionReached.RemoveListener(OnPositionReached);
    }

    
    public Vector3 GetPointBlockByCountBlocks(int countBlocks)
    {
        return new Vector3(transform.position.x,
            transform.position.y+countBlocks * _scaleY,
            transform.position.z);
    }
    
}