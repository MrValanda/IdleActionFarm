using System;

public class PlayerWalletEventArgs : EventArgs
{
    public float CurrentCoins { get; }

    public PlayerWalletEventArgs(float currentCoins)
    {
        CurrentCoins = currentCoins;
    }
}
