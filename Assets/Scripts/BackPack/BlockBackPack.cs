using System.Collections.Generic;
using UnityEngine;

public class BlockBackPack : MonoBehaviour
{
    [SerializeField] private int _backPackSize;
    [SerializeField] private List<BlockTower> _blockTowers;
    [SerializeField] private BlockDetector _blockDetector;
    [SerializeField] private ReceptionPointDetector _receptionPointDetector;
    
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
        block.InitMove(receptionPoint.Target);
        block.transform.parent = null;
        block.PositionReached.AddListener(OnPositionReached);
    }

    private void OnPositionReached(Block block)
    {
        block.StopAnimate();
        Destroy(block.gameObject);
        block.PositionReached.RemoveListener(OnPositionReached);
    }
}
