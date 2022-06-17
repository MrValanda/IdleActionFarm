using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Crop : MonoBehaviour,ISliceable
{
   [SerializeField] private Material _materialAfterSlice;
   [SerializeField] private Block _dropBlockTemplate;
   [SerializeField] private float _rotateAngleY;
   [SerializeField] private float _animationScaleTime=1f;
   [SerializeField] private float _animationRotateTime=1f;
   
   public UnityEvent<Crop> CropWasSliced;

   private Vector3 _startScale;
   private Collider _collider;

   private void Start()
   {
      _collider = GetComponent<Collider>();
      _startScale = transform.localScale;
      _collider.enabled = false;
      PlaySpawnAnimate();
   }

   public Material GetMaterialAfterSlice()
   {
      return _materialAfterSlice;
   }

   public void Slice()
   {
      Instantiate(_dropBlockTemplate, transform.position, Quaternion.identity);
      CropWasSliced?.Invoke(this);
   }

   private void PlaySpawnAnimate()
   {
      transform.localScale=Vector3.zero;
      
      transform.DOScale(_startScale, _animationScaleTime).SetRelative().OnComplete(()=>_collider.enabled=true);
      transform.DOBlendableRotateBy(Vector3.up*_rotateAngleY, _animationRotateTime);
   }
}
