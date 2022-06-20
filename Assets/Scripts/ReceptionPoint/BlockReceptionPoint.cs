
public class BlockReceptionPoint : ReceptionPoint
{
    protected override void PositionReachedAndHasReceptionPoint(BlockAnimator blockAnimator)
    {
        if (blockAnimator.TryGetComponent(out Block block))
        {
            var coins = block.SpawnCoins();
            foreach (var coin in coins)
            {
                _nextReceptionPoint.InitBlockMove(coin.BlockAnimator);
            }
            
            Destroy(blockAnimator.gameObject);

        }
        else
        {
            _nextReceptionPoint.InitBlockMove(blockAnimator);
        }
    }
}
