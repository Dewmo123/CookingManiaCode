using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _itemPrice;
    [SerializeField] private Image _itemImage;
    [SerializeField] private Item _item;
    private void Awake()
    {
        _itemPrice.text = _item.ItemName + "  :  " + _item.PurchasePrice.ToString()+"$";
        _itemImage.sprite = _item.ItemImage;
    }
}
