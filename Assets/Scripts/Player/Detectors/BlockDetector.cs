using UnityEngine;
using UnityEngine.Events;

public class BlockDetector : Detector
{
    public UnityEvent<Block> DetectBlock;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block))
        {
            DetectBlock?.Invoke(block);
        }
    }
}
