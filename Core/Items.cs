using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Items : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemCnt;
    [SerializeField] private Image _itemImage;
    [SerializeField] private Item _item;
    private void Awake()
    {
    }
    private void Update()
    {
        _itemName.text = _item.ItemName;
        if(_itemCnt!=null)
            _itemCnt.text = _item.ItemCnt.ToString();
        _itemImage.sprite = _item.ItemImage;
    }
}
