using UnityEngine;

public class Crop : MonoBehaviour,ISliceable
{
   [SerializeField] private Material _materialAfterSlice;
   [SerializeField] private Block _dropBlockTemplate;
   public Material GetMaterialAfterSlice()
   {
      return _materialAfterSlice;
   }

   public void Slice()
   {
      Instantiate(_dropBlockTemplate, transform.position, Quaternion.identity);
   }
}
