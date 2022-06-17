using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]

public class BlockDetector : MonoBehaviour
{
    [SerializeField,Range(0,100f)] private float _detectionRadius;

    public UnityEvent<Block> DetectBlock;
    
    private void Start()
    {
        var sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = _detectionRadius;
        sphereCollider.isTrigger = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block))
        {
            DetectBlock?.Invoke(block);
        }
    }
}
