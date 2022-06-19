using UnityEngine;

[RequireComponent(typeof(BlockAnimator))]
public class Block : MonoBehaviour
{
    [SerializeField] private float _countCoins;
    [SerializeField] private Coin _coinTemplate;

    public BlockAnimator BlockAnimator { get; private set; }

    private void Start()
    {
        BlockAnimator = GetComponent<BlockAnimator>();
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _countCoins; i++)
        {
            var coin = Instantiate(_coinTemplate, transform.position, Quaternion.identity);
            
        }
    }
}
