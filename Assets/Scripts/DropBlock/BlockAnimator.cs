using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class BlockAnimator : MonoBehaviour
{
    [SerializeField] private float _spawnAnimateDuration=1;
    public Vector3 EndScale { get; private set; }
    public UnityEvent<BlockAnimator> PositionReached;
    
    private bool _needAnimate;
    private Collider _collider;
    private Tweener _doMove;
    
    private Transform _target;
    private float _moveAnimationTime;
    private Camera _camera;
    private bool _isUIAnimation;
    

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _camera=Camera.main;
        PlaySpawnAnimate();
    }

    public void InitMove(Transform target,float moveAnimationDuration=1f,Ease easeType=Ease.Unset,float _delay=0f,bool isUIAnimation=false)
    {
        _isUIAnimation = isUIAnimation;
        _doMove?.Kill();
        _moveAnimationTime = moveAnimationDuration;
        _target = target;
        _collider.enabled = false;
        _doMove = transform.DOLocalMove(GetTargetPoint(), moveAnimationDuration).SetAutoKill(false);
        _doMove.OnComplete(() => PositionReached?.Invoke(this));
        _doMove.SetEase(easeType);
        _doMove.SetDelay(_delay);
    }

    private void Update()
    {
        if (_needAnimate==false ) return;
        _moveAnimationTime -= Time.deltaTime;
        _doMove.ChangeValues(transform.position, GetTargetPoint(), _moveAnimationTime);
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

    private Vector3 GetTargetPoint()
    {
        return _isUIAnimation?_camera.ScreenToWorldPoint(new Vector3(_target.position.x, _target.position.y, _camera.transform.position.z *-1)) : _target.position ;
    }

    private void PlaySpawnAnimate()
    {
        EndScale = transform.localScale;
        _collider.enabled = false;
        transform.localScale = Vector3.zero;
        transform.DOScale(EndScale, _spawnAnimateDuration).OnComplete(() => _collider.enabled = true);
    }
}
