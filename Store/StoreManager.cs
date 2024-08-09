using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _sumPriceUI;
    [SerializeField] private List<GameObject> items;
    [SerializeField] private GameObject _foodUI;
    [SerializeField] private GameObject _skillUI;
    public static StoreManager instance = null;
    public NotifyValue<int> _sumPrice;
    public AudioSource _success;
    public AudioSource _fail;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }
    private void Awake()
    {
        _sumPrice = new NotifyValue<int>();
        gameObject.SetActive(false);
        if (instance == null) instance = this;
        _sumPrice.OnvalueChanged += ChangeText;
    }
    public void OpenFood()
    {
        _foodUI.SetActive(true);
        _skillUI.SetActive(false);
    }
    public void OpenSkill()
    {
        _foodUI.SetActive(false);
        _skillUI.SetActive(true);
    }
    private void ChangeText(int next,int prev)
    {
        _sumPriceUI.text = $"{_sumPrice.Value}$";
    }
    public void Exit()
    {
        DetectUI.instance._UIFlag = false;
        gameObject.SetActive(false);
    }
    public void Purchase()
    {
        if (_sumPrice.Value <= CookManager.instance._money.Value&&_sumPrice.Value!=0)
        {
            foreach (var item in items)
            {
                ChosenStore itemCompo = item.GetComponent<ChosenStore>();
                itemCompo._chosenItem.ItemCnt += itemCompo._chosenCnt;
                itemCompo._chosenCnt = 0;
                itemCompo.ChangeTxt();
            }
            _success.Play();
            CookManager.instance._money.Value -= _sumPrice.Value;
            _sumPrice.Value = 0;
        }
        else
        {
            _fail.Play();
        }
    }
}
