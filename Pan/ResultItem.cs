using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultItem : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _itemName;
    public Item _resultItem;
    private void Awake()
    {
        SetActiveUI(false);
    }


    public void ResultEnable()
    {
        SetActiveUI(true);
        _image.sprite = _resultItem.ItemImage;
        _itemName.text = _resultItem.ItemName;
    }
    public void SetActiveUI(bool tf)
    {
        _image.gameObject.SetActive(tf);
        _itemName.gameObject.SetActive(tf);
    }
}
