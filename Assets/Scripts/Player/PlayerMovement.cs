using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private Joystick _joystick;
   [SerializeField, Range(0, 100f)] private float _speed;

   private Rigidbody _body;
   private Animator _animator;
   private static readonly int Speed = Animator.StringToHash("Speed");
  

   private void Start()
   {
      _animator = GetComponent<Animator>();
      _body = GetComponent<Rigidbody>();
   }
   
   private void FixedUpdate()
   {
      Vector3 desiredVelocity =
         (Vector3.forward * _joystick.Direction.y +
          Vector3.right * _joystick.Direction.x) * _speed;
      
      _animator.SetFloat(Speed, _joystick.Direction.magnitude);
      
      if (desiredVelocity.magnitude > 0)
         transform.rotation = Quaternion.LookRotation(desiredVelocity);
      
      
      desiredVelocity.y = _body.velocity.y;
      _body.velocity = desiredVelocity;

   }
 
}
