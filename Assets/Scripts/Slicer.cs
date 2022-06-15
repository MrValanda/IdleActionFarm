using EzySlice;
using UnityEngine;

public class Slicer : MonoBehaviour
{
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
            SlicedHull slicedObject = SliceObject(other.gameObject, objectForSlice.GetMaterialAfterSlice());
            if (slicedObject == null)
                return;

            GameObject upperHull = slicedObject.CreateUpperHull(other.gameObject,objectForSlice.GetMaterialAfterSlice());
            GameObject lowerHull =
                slicedObject.CreateLowerHull(other.gameObject, objectForSlice.GetMaterialAfterSlice());

            MakeItPhysical(upperHull);
            MakeItPhysical(lowerHull);
            Vector3 position = other.transform.position;
            upperHull.transform.position =position;
            lowerHull.transform.position = position;

            objectForSlice.Slice();
            Destroy(other.gameObject);
        }
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