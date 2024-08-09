using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MakeHamburger : MonoBehaviour
{
    [SerializeField] private List<Image> _hamburger;
    [SerializeField] private List<Item> _complete;
    [SerializeField] private Item hamburger;
    [SerializeField] private GameObject _inventory1;
    [SerializeField] private GameObject _inventory2;
    [SerializeField] private Sprite _tomato;
    private int cnt = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void Exit()
    {
        gameObject.SetActive(false);
        DetectUI.instance._UIFlag = false;
    }
    public void Plus(Item item)
    {
        if (item.ItemCnt != 0)
        {
            for (int i = 0; i < _hamburger.Count; i++)
            {
                if (_hamburger[i].sprite == null)
                {
                    cnt = i; break;
                }
            }
            if (cnt != _hamburger.Count)
            {
                if (item.name != "Tomato")
                    _hamburger[cnt].sprite = item.ItemImage;
                else
                    _hamburger[cnt].sprite = _tomato;
                if (!_hamburger[cnt].gameObject.activeSelf) _hamburger[cnt].gameObject.SetActive(true);
                cnt++;
            }
        }
    }
    public void Minus(int index)
    {
        _hamburger[index].sprite = null;
        _hamburger[index].gameObject.SetActive(false);
    }

    public void Complete()
    {
        bool flag = true;
        for (int i = 0; i < _complete.Count; i++)
        {
            if (_hamburger[i].sprite != _complete[i].ItemImage&&i!=3)
            {
                flag = false;
            }
            if (i == 3 && _hamburger[i].sprite != _tomato)
            {
                flag = false;
            } 
            if (_complete[i].ItemCnt == 0)
            {
                flag = false;
            }
        }
        if (flag)
        {
            ChosenInven inven1 = _inventory1.GetComponent<ChosenInven>();
            ChosenInven inven2 = _inventory2.GetComponent<ChosenInven>();
            if ((inven1._chosenItem == null || inven2._chosenItem == null))
            {
                if (inven1._chosenItem == null)
                {
                    inven1.ChooseResult(hamburger);
                }
                else if (inven2._chosenItem == null)
                {
                    inven2.ChooseResult(hamburger);
                }
                for (int i = 0; i < _hamburger.Count; i++)
                {
                    _complete[i].ItemCnt--;
                    _hamburger[i].sprite = null;
                    _hamburger[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
