using System.Collections;
using UnityEngine;
using TMPro;

public class CoinView : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private TMP_Text _text;

    private float _coins;
    private float _currentCoins;
    private Coroutine _coinsAddAnimationCoroutine;
    private void OnEnable()
    {
        _playerWallet.CoinsChanged.AddListener(OnCoinsChanged);
        _coinsAddAnimationCoroutine = StartCoroutine(CoinsAddAnimation());
    }
    private void OnDisable()
    {
        _playerWallet.CoinsChanged.RemoveListener(OnCoinsChanged);
        StopCoroutine(_coinsAddAnimationCoroutine);
    }
    private void OnCoinsChanged(float changedValue, PlayerWalletEventArgs arg)
    {
        _currentCoins = arg.CurrentCoins;
    }

    private IEnumerator CoinsAddAnimation()
    {
        while (true)
        {
            _text.text = _coins.ToString();
            _coins = Mathf.MoveTowards(_coins, _currentCoins, 1);
            yield return null;
        }
       
    }

}
