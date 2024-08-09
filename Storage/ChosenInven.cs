using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChosenInven : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private GameObject _storageUI;
    public Item _chosenItem;
    public int _chosenCnt = 0;
    private void Awake()
    {
        SetActiveUI(false);
    }
    public void ItemChoose(Item chosenItem)
    {
        if (chosenItem.ItemCnt > 0)
        {
            _chosenItem = chosenItem;
            _chosenItem.ItemCnt--;
            SetActiveUI(true);
            ChangeUI();
        }
    }
    public void ChooseResult(Item resultItem)
    {
        _chosenItem = resultItem;
        SetActiveUI(true);
        ChangeUI();

    }

    public void ChangeUI()
    {
        _image.sprite = _chosenItem.ItemImage;
        _itemName.text = _chosenItem.ItemName;
    }
    public void SetActiveUI(bool tf)
    {
        _image.gameObject.SetActive(tf);
        _itemName.gameObject.SetActive(tf);
    }
    public void RemoveItem()
    {
        if (_storageUI.activeSelf)
        {
            _chosenItem.ItemCnt++;
            _chosenItem = null;
            SetActiveUI(false);
        }
    }
}
