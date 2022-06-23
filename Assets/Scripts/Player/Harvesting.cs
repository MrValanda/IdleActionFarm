using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Harvesting : MonoBehaviour
{
    
    [SerializeField] private CropDetector _cropDetector;
    [SerializeField] private int _harvestSpeed;
    [SerializeField] private Slicer _slicer;

    public UnityEvent StartHarvest;
    public UnityEvent StopHarvest;
    
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

    public void StartSlice()
    {
        _slicer.StartSlice();
    }

    public void StopSlice()
    {
        _slicer.StopSlice();

    }
    
    public void StartHarvesting()
    {
        _slicer.gameObject.SetActive(true);
        StartHarvest?.Invoke();
    }
    public void StopHarvesting()
    {
        _slicer.gameObject.SetActive(false);
        StopHarvest?.Invoke();

    }

   
}
