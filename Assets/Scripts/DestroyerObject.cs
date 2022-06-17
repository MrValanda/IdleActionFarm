using System;
using DG.Tweening;
using UnityEngine;

public class DestroyerObject : MonoBehaviour
{
    private int _delayToDestroy;

    private float _timer;

    private void Start()
    {
        transform.DOScale(Vector3.zero, _delayToDestroy);
    }

    public void InitDelayToDestroy(int delayToDestroy)
    {
        if (delayToDestroy < 0) delayToDestroy = 0;
        _delayToDestroy = delayToDestroy;
    }
    
    private void Update()
    {
        if (_timer > _delayToDestroy)
        {
            Destroy(gameObject);
        }

        _timer += Time.deltaTime;
    }
}
