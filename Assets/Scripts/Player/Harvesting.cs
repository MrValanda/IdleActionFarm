using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Harvesting : MonoBehaviour
{
    [SerializeField] private CropDetector _cropDetector;
    [SerializeField] private int _harvestSpeed;
    [SerializeField] private Slicer _slicer;
    
    private Animator _animator;
    private static readonly int HarvestingTriggerId = Animator.StringToHash("NeedHarvesting");
    private static readonly int HarvestingSpeed = Animator.StringToHash("HarvestingSpeed");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat(HarvestingSpeed,_harvestSpeed);
    }

    private void Update()
    {
        _animator.SetBool(HarvestingTriggerId, _cropDetector.CropNearby);
    }
    
    public void StartHarvesting()
    {
        _slicer.StartSlice();
    }
    public void StopHarvesting()
    {
        _slicer.StopSlice();

    }

   
}
