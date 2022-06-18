using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Detector : MonoBehaviour
{
    [SerializeField,Range(0,100f)] private float _detectionRadius;

    private void Start()
    {
        var sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = _detectionRadius;
        sphereCollider.isTrigger = true;
    }
}
