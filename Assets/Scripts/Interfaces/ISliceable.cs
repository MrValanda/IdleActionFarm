using UnityEngine;

internal interface ISliceable
{
    Material GetMaterialAfterSlice();
    void Slice();
}