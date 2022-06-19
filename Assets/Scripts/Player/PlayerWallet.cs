using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    public UnityEvent CoinAdd;
    public UnityEvent<float> CoinsChanged;
    public UnityEvent CoinRemove;
    
    private float _currentCountCoins;

    public void AddCoin()
    {
        _currentCountCoins++;
        CoinAdd?.Invoke();
        CoinsChanged?.Invoke(_currentCountCoins);
    }

    public void RemoveCoin()
    {
        _currentCountCoins--;
        CoinRemove?.Invoke();
        CoinsChanged?.Invoke(_currentCountCoins);
    }
}