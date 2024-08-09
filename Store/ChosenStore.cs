using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChosenStore : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _sumPriceTxt;
    public Item _chosenItem;
    public int _chosenCnt = 0;
    private void Awake()
    {
        _image.sprite = _chosenItem.ItemImage;
        _itemName.text = _chosenItem.ItemName;
    }
    public void ItemChoose()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _chosenCnt+=9;
            StoreManager.instance._sumPrice.Value += _chosenItem.PurchasePrice*3;
            ChangeTxt();
        }
        else
        {
            _chosenCnt+=3;
            StoreManager.instance._sumPrice.Value += _chosenItem.PurchasePrice;
            ChangeTxt();
        }
    }
    public void ItemCancel()
    {
        if (Input.GetKey(KeyCode.LeftShift)&& _chosenCnt >= 10)
        {
            _chosenCnt -= 9;
            StoreManager.instance._sumPrice.Value -= _chosenItem.PurchasePrice * 3;
            ChangeTxt();
        }
        else if (_chosenCnt > 0)
        {
            _chosenCnt-=3;
            StoreManager.instance._sumPrice.Value -= _chosenItem.PurchasePrice;
            ChangeTxt();
        }
    }
    public void ChangeTxt()
    {
        _sumPriceTxt.text = _chosenCnt.ToString();
    }

}
