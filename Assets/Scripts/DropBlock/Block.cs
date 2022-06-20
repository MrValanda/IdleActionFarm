using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(BlockAnimator))]
public class Block : MonoBehaviour
{
    [SerializeField] private float _countCoins;
    [SerializeField] private float _cost;
    [SerializeField] private Coin _coinTemplate;

    private PlayerWallet _playerWallet;
    public BlockAnimator BlockAnimator { get; private set; }

    private void Start()
    {
        BlockAnimator = GetComponent<BlockAnimator>();
    }

    public void Init(PlayerWallet playerWallet)
    {
        _playerWallet = playerWallet;
    }

    public List<Coin> SpawnCoins()
    {
        List<Coin> coins=new List<Coin>();
        for (int i = 0; i < _countCoins; i++)
        {
            var coin = Instantiate(_coinTemplate, transform.position, _coinTemplate.transform.rotation);
            coin.Init(_playerWallet, _cost/_countCoins);
            coins.Add(coin);
        }

        return coins;
    }
  
}
