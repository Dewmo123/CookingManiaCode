using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenPan2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _btnText;
    [SerializeField] private GameObject _pan2;
    private bool flag = false;
    public void Purchase()
    {
        if (CookManager.instance._money.Value >= 200 && !flag)
        {
            GetComponentInParent<StoreManager>()._success.Play();
            CookManager.instance._money.Value -= 200;
            _btnText.text = "구매 완료";
            _pan2.gameObject.SetActive(true);
            flag = true;
        }
        else
        {
            GetComponentInParent<StoreManager>()._fail.Play();
        }
    }
}
