using System.Collections.Generic;
using UnityEngine;

public class BlockBackPack : MonoBehaviour
{
    [SerializeField] private int _backPackSize;
    [SerializeField] private List<BlockTower> _blockTowers;
    [SerializeField] private BlockDetector _blockDetector;
    [SerializeField] private ReceptionPointDetector _receptionPointDetector;
    [SerializeField] private PlayerWallet _playerWallet;

    
    private Stack<Block> _blocks;
    
    private void Start()
    {
        _blocks = new Stack<Block>();
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
        _blockTowers[_blocks.Count % _blockTowers.Count].AddNewBlock(block);
        _blocks.Push(block);
    }

    private void OnDetectReceptionPoint(ReceptionPoint receptionPoint)
    {
        var block = _blocks.Count > 0 ? _blocks.Pop() : null;
        if(block==null) return;
        var blockTower = _blockTowers[_blocks.Count % _blockTowers.Count];
        blockTower.RemoveLastBlock();
        receptionPoint.InitBlockMove(block.BlockAnimator);
    }
    
}
