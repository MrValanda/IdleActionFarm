using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    protected Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
