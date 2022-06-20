using System;

public class BlockBackPackEventArgs : EventArgs
{
    public float CurrentBlockCount { get; }
    public float MaxBlockCount { get; }

    public BlockBackPackEventArgs(float currentBlockCount, float maxBlockCount)
    {
        CurrentBlockCount = currentBlockCount;
        MaxBlockCount = maxBlockCount;
    }
}