using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanUI : MonoBehaviour
{
    [SerializeField] private GameObject _smoke;
    [SerializeField]private AudioSource _cooking;
    public GameObject _inventory1;
    public GameObject _inventory2;
    [SerializeField] private GameObject _gagePivot;
    [SerializeField] private GameObject _cookManager;
    public Image _gage;
    public ChosenItem _chosenItemCompo;
    private ResultItem _resultItemCompo;
    public GameObject _resultImage;
    public bool _resultFlag = false;
    public bool _timerFlag = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }
    private void Awake()
    {
        _chosenItemCompo = GetComponentInChildren<ChosenItem>();
        _resultItemCompo = GetComponentInChildren<ResultItem>();
        gameObject.SetActive(false);
    }
    public void Exit()
    {
        DetectUI.instance._UIFlag = false;
        gameObject.SetActive(false);
    }
    public void Cook()
    {
        if (!_resultFlag && _chosenItemCompo._chosenItem != null&&!_timerFlag&& _chosenItemCompo._chosenItem.ItemCnt > 0)
        {
            _resultImage.GetComponent<SpriteRenderer>().sprite = _chosenItemCompo._chosenItem.ItemImage;
            _chosenItemCompo._chosenItem.ItemCnt--;
            _smoke.gameObject.SetActive(true);
            _cooking.Play();
            _timerFlag = true;
        }
    }

    public void CompleteCook()
    {
        if (_resultItemCompo._resultItem == null)
        {
            _smoke.gameObject.SetActive(false);
            _resultFlag = true;
            _resultItemCompo._resultItem = _chosenItemCompo._chosenItem.Ripe;
            _cooking.Stop();
            _resultImage.GetComponent<SpriteRenderer>().sprite = _chosenItemCompo._chosenItem.Ripe.ItemImage;
            _chosenItemCompo.ChangeUI();
            _resultItemCompo.ResultEnable();
        }
    }

    public void GetResultItem()
    {
        ChosenInven inven1 = _inventory1.GetComponent<ChosenInven>();
        ChosenInven inven2 = _inventory2.GetComponent<ChosenInven>();
        if (_resultItemCompo._resultItem != null && (inven1._chosenItem == null || inven2._chosenItem == null))
        {
            _gage.fillAmount = 0;
            _gagePivot.transform.localScale = new Vector3(0, 1, 1);
            if (inven1._chosenItem == null)
            {
                inven1.ChooseResult(_resultItemCompo._resultItem);
            }
            else if (inven2._chosenItem == null)
            {
                inven2.ChooseResult(_resultItemCompo._resultItem);
            }
            _resultImage.GetComponent<SpriteRenderer>().sprite = null;
            _resultFlag = false;
            _resultItemCompo.SetActiveUI(false);
            _resultItemCompo._resultItem = null;
        }

    }
}