using UnityEngine;

public class TransitionWhenDetectCrop : Transition
{
    [SerializeField] private CropDetector _cropDetector;
    protected override void Enable()
    {
        _cropDetector.DetectedCrop.AddListener(OnDetectCrop);
    }

    protected override void Disable()
    {
        _cropDetector.DetectedCrop.RemoveListener(OnDetectCrop);
    }

    private void OnDetectCrop(Crop _)
    {
        NeedTransit = true;
    }
}
