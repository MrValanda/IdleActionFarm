using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class CropDetector : Detector
{
    public UnityEvent<Crop> DetectedCrop;
    
    private void OnTriggerEnter(Collider other)
    {
        EvaluateCollision(other);
    }

    private void OnTriggerStay(Collider other)
    {
        EvaluateCollision(other);
    }

    private void EvaluateCollision(Collider collision)
    {
        if (collision.TryGetComponent(out Crop crop))
        {
            DetectCrop(crop);
        }
    }

    private void DetectCrop(Crop crop)
    {
        DetectedCrop?.Invoke(crop);
    }
}
