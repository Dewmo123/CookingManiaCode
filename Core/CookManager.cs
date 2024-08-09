using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookManager : MonoBehaviour
{
    public static CookManager instance;
    [SerializeField] private int _startMoney = 30;
    [SerializeField] private GameObject[] _hideCustomer;

    [SerializeField] private TextMeshProUGUI _moneyTxt;
    [SerializeField] private TextMeshProUGUI _comboTxt;
    [SerializeField] private TextMeshProUGUI _breakTxt;
    [SerializeField] private TextMeshProUGUI _stageTxt;

    [SerializeField] private GameObject _stopUI;
    public GameObject _gameOverUI;
    public GameObject _gameClearUI;

    public List<Item> items;

    private int _stopCnt = 0;
    private bool _stopFlag = false;
    private float _orderMultiplyRate = 1.01f;
    private int _hideCustomerCnt = 0;

    public float _orderMultiply = 1.5f;
    public float _defaultMultiply = 1.5f;
    public float _orderDelay = 10;
    public GameObject _player;

    public NotifyValue<int> _money = new NotifyValue<int>();
    public NotifyValue<int> _combo = new NotifyValue<int>();

    public int _stageCnt = 1;
    public int _orderCnt = 0;

    private Sequence sequence;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
        SetUp();
    }
    private void Start()
    {
        _stageTxt.text = $"Stage {_stageCnt}";
        sequence = DOTween.Sequence()
        .SetAutoKill(false) // DoTween Sequence는 기본적으로 일회용임. 재사용하려면 써주자.
                .OnRewind(() => // 실행 전. OnStart는 unity Start 함수가 불릴 때 호출됨. 낚이지 말자.
                {
                    _stageTxt.gameObject.SetActive(true);
                })
        .Append(_stageTxt.DOFade(1.0f, 2)) // 어두워짐. 알파 값 조정.
        .Append(_stageTxt.DOFade(0.0f, 2)) // 밝아짐. 알파 값 조정.
                .OnComplete(() => // 실행 후.
                 {
                     _stageTxt.gameObject.SetActive(false);
                 });

    }
    private void Update()
    {
        Escape();
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeStage();
        }
#endif
    }
    private void Escape()
    {
        _stopCnt += Input.GetKeyDown(KeyCode.Escape) && !DetectUI.instance._UIFlag ? 1 : 0;
        if (_stopCnt == 1 && !_stopFlag)
        {
            Time.timeScale = 0;
            _stopFlag = true;
            _stopUI.gameObject.SetActive(true);
        }
        if (_stopCnt == 2)
        {
            Time.timeScale = 1;
            _stopUI.gameObject.SetActive(false);
            _stopFlag = false;
            _stopCnt = 0;
        }
    }

    private void SetUp()
    {
        _combo.Value = 0;
        _combo.OnvalueChanged += ChangeComboTxt;
        _money.OnvalueChanged += ChangeMoneyTxt;
        _money.Value = _startMoney;
        Time.timeScale = 1;
        foreach (Item item in items)
        {
            item.ItemCnt = item.defaultCnt;
            item.CookTime = item.defaultCookTime;
        }
    }
    private void ChangeMoneyTxt(int prev, int next)
    {
        _moneyTxt.text = next.ToString() + "$";
    }

    public void ChangeStage()
    {
        if(_stageCnt == 5)
        {
            _gameClearUI.SetActive(true);
            Time.timeScale = 0;
            return;
        }
        if (_stageCnt == 2 || _stageCnt == 4)
        {
            _hideCustomer[_hideCustomerCnt++].SetActive(true);
        }
        DebtManager.instance.SetStage(_stageCnt);
        _orderMultiply += 0.1f;
        _defaultMultiply = _orderMultiply;
        _stageCnt++;
        _stageTxt.text = $"Stage {_stageCnt}";
        _orderDelay *= 0.95f;
        sequence.Restart();
    }
    private void ChangeComboTxt(int prev, int next)
    {
        _comboTxt.text = "Combo : " + next.ToString();
        _orderCnt++;
        if (next == 0)
        {
            _orderCnt--;
            _orderMultiply = _defaultMultiply;
        }
        else
        {
            _orderMultiply *= _orderMultiplyRate;
        }
    }
}
