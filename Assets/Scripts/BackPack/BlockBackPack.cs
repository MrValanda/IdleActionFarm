using System.Collections.Generic;
using UnityEngine;

public class BlockBackPack : MonoBehaviour
{
    [SerializeField] private int _backPackSize;
    [SerializeField] private List<BlockTower> _blockTowers;
    [SerializeField] private BlockDetector _blockDetector;
    
    private Stack<Block> _blocks;

    private void Start()
    {
        _blocks = new Stack<Block>();
    }

    private void OnEnable()
    {
        _blockDetector.DetectBlock.AddListener(OnBlockDetected);
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
}
