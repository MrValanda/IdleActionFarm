using TMPro;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    [SerializeField] private BlockBackPack _blockBackPack;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _blockBackPack.BlocksChanged.AddListener(OnBlocksChanged);
    }
    private void OnDisable()
    {
        _blockBackPack.BlocksChanged.RemoveListener(OnBlocksChanged);
    }
    private void OnBlocksChanged(int changedValue, BlockBackPackEventArgs arg)
    {
        _text.text = $"{arg.CurrentBlockCount}/{arg.MaxBlockCount}";
    }
    
}
