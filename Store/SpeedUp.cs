using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private int _cnt = 0;
    private int _price = 50;
    [SerializeField] private TextMeshProUGUI _priceTxt;
    [SerializeField] private TextMeshProUGUI _lvTxt;
    [SerializeField] private TextMeshProUGUI _btnTxt;
    public void Purchase()
    {
        if (CookManager.instance._money.Value >= _price && _cnt < 5)
        {
            GetComponentInParent<StoreManager>()._success.Play();
            CookManager.instance._money.Value -= _price;
            CookManager.instance._player.GetComponent<PlayerMovement>()._speed *= 1.08f;
            _price = (int)(_price * 1.15f);
            _priceTxt.text = _price + "$";
            _cnt++;
            _lvTxt.text = _cnt + "Lv";
            if (_cnt == 5)
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
