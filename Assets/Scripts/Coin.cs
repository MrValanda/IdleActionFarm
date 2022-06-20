using UnityEngine;

[RequireComponent(typeof(BlockAnimator))]
public class Coin : MonoBehaviour
{
   public BlockAnimator BlockAnimator { get; private set; }
   
   private PlayerWallet _playerWallet;

   public float Cost { get; private set; }
   private void Awake()
   {
      BlockAnimator = GetComponent<BlockAnimator>();
   }

   public void Init(PlayerWallet playerWallet, float cost)
   {
      _playerWallet = playerWallet;
      Cost = cost;
   }

   private void OnDestroy()
   {
      _playerWallet.AddCoins(Cost);
   }
}
