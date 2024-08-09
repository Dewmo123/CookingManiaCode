using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DecCookTime : MonoBehaviour
{
    private int _cnt;
    [SerializeField] private TextMeshProUGUI _btnTxt;
    [SerializeField] private TextMeshProUGUI _priceTxt;
    [SerializeField] private TextMeshProUGUI _lvTxt;
    private int _price = 80;
    public void Purchase()
    {
        if (CookManager.instance._money.Value >= _price && _cnt < 3)
        {
            foreach (Item item in CookManager.instance.items)
            {
                if (item.CookTime != 0)
                {
                    item.CookTime *= 0.93f;
                }
            }
            CookManager.instance._money.Value -= _price;
            _price = (int)(_price * 1.2f);
            _priceTxt.text = _price + "$";
            GetComponentInParent<StoreManager>()._success.Play();
            _cnt++;
            _lvTxt.text = _cnt + "Lv";
            if (_cnt == 3)
            {
                _btnTxt.text = "최고 레벨";
            }
        }
        else
        {

            GetComponentInParent<StoreManager>()._fail.Play();
        }
    }
}
