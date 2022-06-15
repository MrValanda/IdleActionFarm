using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class CropDetector : MonoBehaviour
{
    [SerializeField,Range(0,100f)] private float _detectionRadius;

    public UnityEvent<Crop> DetectCrop;
    public bool CropNearby { get; private set; }

    private void Start()
    {
        var sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = _detectionRadius;
        sphereCollider.isTrigger = true;
    }

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
