using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Harvesting : MonoBehaviour
{
    [SerializeField] private CropDetector _cropDetector;
    [SerializeField] private Slicer _slicer;
    
    private Animator _animator;
    private static readonly int HarvestingTriggerId = Animator.StringToHash("NeedHarvesting");

    private void Start()
    {
        _animator = GetComponent<Animator>();
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
