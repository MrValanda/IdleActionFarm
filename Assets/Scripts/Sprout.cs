using UnityEngine;
using UnityEngine.Events;

public class Sprout : MonoBehaviour
{
   [SerializeField] private float _growthTime;
   [SerializeField] private Crop _cropTemplate;
   
   public UnityEvent<Crop> SproutHasGrow;
   private float _currentGrowthTime;

   private bool _needGrow;
   private void Start()
   {
      _currentGrowthTime = 0;
      _needGrow = true;
   }
   private void Update()
   {
      if (_needGrow == false) return;
      
      if(_currentGrowthTime>_growthTime)
      {
         GrowCrop();
      }
      _currentGrowthTime += Time.deltaTime;
   }
   
   private void GrowCrop()
   {
      _needGrow = false;
      _currentGrowthTime = 0;
      var crop = Instantiate(_cropTemplate, transform.position, Quaternion.identity);
      crop.transform.localScale = _cropTemplate.transform.localScale;
      crop.transform.parent = transform;
      
      crop.CropWasSliced.AddListener(OnCropWasSliced);
      SproutHasGrow?.Invoke(crop);
   }

   private void OnCropWasSliced(Crop crop)
   {
      _needGrow = true;
      crop.CropWasSliced.RemoveListener(OnCropWasSliced);
   }
}
