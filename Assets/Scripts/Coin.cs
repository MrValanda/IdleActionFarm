using UnityEngine;

[RequireComponent(typeof(BlockAnimator))]
public class Coin : MonoBehaviour
{
   [field: SerializeField] public float Cost { get; private set; }
   public BlockAnimator BlockAnimator { get; private set; }

   private void Awake()
   {
      BlockAnimator = GetComponent<BlockAnimator>();
   }
}
