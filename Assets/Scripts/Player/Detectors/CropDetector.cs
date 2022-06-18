using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class CropDetector : Detector
{
    public UnityEvent<Crop> DetectCrop;
    public bool CropNearby { get; private set; }

    private void FixedUpdate()
    {
        CropNearby = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Crop crop))
        {
            DetectCrop?.Invoke(crop);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Crop _))
        {
            CropNearby = true;
        }
    }
    
}
