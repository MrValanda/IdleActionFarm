using TMPro;
using DG.Tweening;
using UnityEngine;
using System.Collections;
using System.Globalization;

public class CoinView : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private bool _needAnimate;
    [SerializeField] private float _shakeStrength;

    private float _changedValue;
    private float _coins;
    private float _currentCoins;
    
    private Coroutine _coinsAddAnimationCoroutine;
    private Tweener _snakeTweener;

    private const int DEFAULT_CHANGE_VALUE = 1;
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

    private void OnDestroy()
    {
        _snakeTweener?.Kill();
    }

    private void OnCoinsChanged(float changedValue, PlayerWalletEventArgs arg)
    {
        _currentCoins = arg.CurrentCoins;
        _changedValue = _needAnimate ? DEFAULT_CHANGE_VALUE : changedValue;
        if (_snakeTweener == null)
        {
            _snakeTweener = transform.DOShakePosition(1, _shakeStrength).SetAutoKill(false);
        }
        else
        {
            _snakeTweener.Restart();
        }
    }
    
    private IEnumerator CoinsAddAnimation()
    {
        while (true)
        {
            _text.text = _coins.ToString(CultureInfo.InvariantCulture);
          
            _coins = Mathf.MoveTowards(_coins, _currentCoins, _changedValue);
            yield return null;
        }
    }
}
