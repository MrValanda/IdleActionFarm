using EzySlice;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    [SerializeField] private int _delayToDestroyUpperHull=60;
    [SerializeField] private int _delayToDestroyLowerHull=60;
    private bool _needSlice;
    
    public void StartSlice()
    {
        _needSlice = true;
    }

    public void StopSlice()
    {
        _needSlice = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_needSlice && other.TryGetComponent(out ISliceable objectForSlice))
        {
            Slice(other,objectForSlice);
        }
    }

    private void Slice(Collider other,ISliceable objectForSlice)
    {
        SlicedHull slicedObject = SliceObject(other.gameObject, objectForSlice.GetMaterialAfterSlice());
        if (slicedObject == null)
            return;

        GameObject upperHull = slicedObject.CreateUpperHull(other.gameObject,objectForSlice.GetMaterialAfterSlice());
        GameObject lowerHull =
            slicedObject.CreateLowerHull(other.gameObject, objectForSlice.GetMaterialAfterSlice());

        MakeItPhysical(upperHull);
        MakeItPhysical(lowerHull);

        SetPositionAndScale(upperHull,other.transform);
        SetPositionAndScale(lowerHull,other.transform);
            
        upperHull.AddComponent<DestroyerObject>().InitDelayToDestroy(_delayToDestroyUpperHull);
        lowerHull.AddComponent<DestroyerObject>().InitDelayToDestroy(_delayToDestroyLowerHull);
            
        objectForSlice.Slice();
        Destroy(other.gameObject);
    }

    private void SetPositionAndScale(GameObject obj,Transform desiredTransform)
    {
        Vector3 position = desiredTransform.position;

        obj.transform.position = position;;
        
        obj.transform.localScale =desiredTransform.lossyScale;
    }
    private void MakeItPhysical(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
    }
    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.forward, crossSectionMaterial);
    }
   
}