using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChosenItem : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _itemName;
    private PanUI _panUI;
    public Item _chosenItem;
    private Item _beforeItem;
    public int _chosenCnt = 0;
    private void Awake()
    {
        _panUI = GetComponentInParent<PanUI>();
        SetActiveUI(false);
    }
    public void ItemChoose(Item chosenItem)
    {
        if (!_panUI._timerFlag)
        {
            _chosenItem = chosenItem;
            SetActiveUI(true);
            ChangeUI();
        }
    }
    public void ChangeUI()
    {
        _image.sprite = _chosenItem.ItemImage;
        _itemName.text = _chosenItem.ItemName;
        _beforeItem = _chosenItem;
    }
    public void SetActiveUI(bool tf)
    {
        _image.gameObject.SetActive(tf);
        _itemName.gameObject.SetActive(tf);
    }
}