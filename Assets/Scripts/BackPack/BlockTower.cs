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

    private void OnPositionReached(Block block)
    {
        block.SetPosition(_spawnPoint.position);
        _spawnPoint.position = GetPointNextBlock();
        _countBlocks++;
        block.transform.parent = transform;
        block.transform.localRotation = Quaternion.identity;
        block.StopAnimate();
        block.PositionReached.RemoveListener(OnPositionReached);
    }

    
    public Vector3 GetPointNextBlock()
    {
        return new Vector3(transform.position.x,
            transform.position.y+_countBlocks * _scaleY,
            transform.position.z);
    }
    
}