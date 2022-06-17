using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Block : MonoBehaviour
{
    [SerializeField] private Ease _easeType;
    [SerializeField] private float _spawnAnimateDuration=1;
    [SerializeField] private float _moveAnimateDuration=0.1f;
    public Vector3 EndScale { get; private set; }
    public UnityEvent<Block> PositionReached;
    
    private bool _needAnimate;
    private Collider _collider;
    private Tweener _doMove;
    
    private Transform _target;
    private float _moveAnimationTime;
    
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        PlaySpawnAnimate();
    }

    public void InitMove(Transform target)
    {
        _doMove?.Kill();
        _moveAnimationTime = _moveAnimateDuration;
        _target = target;
        _collider.enabled = false;
        _doMove = transform.DOLocalMove(_target.position, _moveAnimateDuration).SetAutoKill(false);
        _doMove.OnComplete(() => PositionReached?.Invoke(this));
        _doMove.SetEase(_easeType);
    }

    private void Update()
    {
        if (_needAnimate==false ) return;
        _moveAnimationTime -= Time.deltaTime;
        _doMove.ChangeValues(transform.position, _target.position, _moveAnimationTime);
    }
    
    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
        PlaySpawnAnimate();
        _doMove?.Kill();

    }

    public void StartAnimate()
    {
        _needAnimate = true;
    }

    public void StopAnimate()
    {
        _needAnimate = false;
    }

    private void PlaySpawnAnimate()
    {
        EndScale = transform.localScale;
        _collider.enabled = false;
        transform.localScale = Vector3.zero;
        transform.DOScale(EndScale, _spawnAnimateDuration).OnComplete(() => _collider.enabled = true);
    }
}
