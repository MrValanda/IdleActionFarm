using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    public UnityEvent CoinsAdd;
    public UnityEvent<float,PlayerWalletEventArgs> CoinsChanged;
    public UnityEvent CoinsRemove;
    
    private float _currentCountCoins;

    public void AddCoins(float coins)
    {
        _currentCountCoins+=coins;
        CoinsAdd?.Invoke();
        CoinsChanged?.Invoke(coins,new PlayerWalletEventArgs( _currentCountCoins));
    }

    public void RemoveCoins(float coins)
    {
        _currentCountCoins-=coins;
        CoinsRemove?.Invoke();
        CoinsChanged?.Invoke(-coins,new PlayerWalletEventArgs( _currentCountCoins));
    }
}