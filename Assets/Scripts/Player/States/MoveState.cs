using UnityEngine;

public abstract class MoveState : State
{
    [SerializeField] private MoveAnimationController _moveAnimationController;
    [SerializeField] private Joystick _joystick;
    [SerializeField, Range(0, 100f)] private float _speed;

    protected Rigidbody _body;
    
    protected virtual void Start()
    {
        _body = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 moveDirection = GetMoveDirection();
        
        _moveAnimationController.SetCurrentSpeed(_joystick.Direction.magnitude);
      
        if (moveDirection.sqrMagnitude >Mathf.Epsilon)
            transform.rotation = Quaternion.LookRotation(moveDirection);
        
        Move(GetDesiredVelocity());
    }

    protected virtual Vector3 GetMoveDirection()
    {
        Vector3 moveDirection = Vector3.forward * _joystick.Direction.y +
                                 Vector3.right * _joystick.Direction.x;
        return moveDirection;
    }

    protected virtual Vector3 GetDesiredVelocity()
    {
        Vector3 desiredVelocity = GetMoveDirection() * _speed;
        return desiredVelocity;
    }

    protected virtual void Move(Vector3 desiredVelocity)
    {
        desiredVelocity.y = _body.velocity.y;
        _body.velocity = desiredVelocity;
    }
}
