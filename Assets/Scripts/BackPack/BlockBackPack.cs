using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class BlockBackPack : MonoBehaviour
{
    [SerializeField] private int _backPackSize;
    [SerializeField] private List<BlockTower> _blockTowers;
    [SerializeField] private BlockDetector _blockDetector;
    [SerializeField] private ReceptionPointDetector _receptionPointDetector;
    [SerializeField] private PlayerWallet _playerWallet;

    public UnityEvent<int,BlockBackPackEventArgs> BlocksChanged;
    
    private Stack<Block> _blocks;
    
    private void Start()
    {
        _blocks = new Stack<Block>();
        BlocksChanged?.Invoke(0, new BlockBackPackEventArgs(_blocks.Count,_backPackSize));

    }

    private void OnEnable()
    {
        _blockDetector.DetectBlock.AddListener(OnBlockDetected);
        _receptionPointDetector.DetectReceptionPoint.AddListener(OnDetectReceptionPoint);
    }

    private void OnDisable()
    {
        _blockDetector.DetectBlock.RemoveListener(OnBlockDetected);
        _receptionPointDetector.DetectReceptionPoint.RemoveListener(OnDetectReceptionPoint);

    }
    
    private void OnBlockDetected(Block block)
    {
        if (_blocks.Count >= _backPackSize) return;
        const int BLOCK_CHANGED = 1;
        block.Init(_playerWallet);
        
        _blockTowers[_blocks.Count % _blockTowers.Count].AddNewBlock(block);
        _blocks.Push(block);
        
        BlocksChanged?.Invoke(BLOCK_CHANGED, new BlockBackPackEventArgs(_blocks.Count,_backPackSize));
    }

    private void OnDetectReceptionPoint(ReceptionPoint receptionPoint)
    {
        var block = _blocks.Count > 0 ? _blocks.Pop() : null;
        if(block==null) return;
        
        const int BLOCK_CHANGED = -1;
        
        var blockTower = _blockTowers[_blocks.Count % _blockTowers.Count];
        blockTower.ReduceBlocks(Mathf.Abs(BLOCK_CHANGED));
        
        BlocksChanged?.Invoke(BLOCK_CHANGED,new BlockBackPackEventArgs(_blocks.Count,_backPackSize));
        
        receptionPoint.InitBlockMove(block.BlockAnimator);
    }
}
