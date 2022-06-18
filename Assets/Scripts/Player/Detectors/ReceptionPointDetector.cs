using UnityEngine;
using UnityEngine.Events;

public class ReceptionPointDetector : Detector
{
    public UnityEvent<ReceptionPoint> DetectReceptionPoint;

    private void OnTriggerEnter(Collider other)
    {
        EvaluateCollision(other);
    }

    private void OnTriggerStay(Collider other)
    {
        EvaluateCollision(other);
    }

    private void EvaluateCollision(Collider other)
    {
        if (other.TryGetComponent(out ReceptionPoint receptionPoint))
        {
            DetectReceptionPoint?.Invoke(receptionPoint);
        }
    }
}
