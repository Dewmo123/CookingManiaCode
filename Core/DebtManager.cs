using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebtManager : MonoBehaviour
{
    public static DebtManager instance;
    [SerializeField]private int[] _debt;
    [SerializeField]private int[] _debtTimer;
    public TextMeshProUGUI _debtTxt;
    [SerializeField] private TextMeshProUGUI _timerTxt;
    private NotifyValue<string> _timerText;
    public int _currentDebt { get; private set; }
    private float _min, _sec;
    private void Awake()
    {
        _timerText = new NotifyValue<string>();
        if (instance == null) instance = this;
        _timerText.OnvalueChanged += TimerValueHandler;
        SetStage(0);
    }

    private void TimerValueHandler(string prev, string next)
    {
        if (next == "00:00")
        {
            Time.timeScale = 0;
            CookManager.instance._gameOverUI.SetActive(true);
        }
    }

    public void SetStage(int stageNum)
    {
        _min = _debtTimer[stageNum] / 60;
        _sec = _debtTimer[stageNum] % 60;
        _currentDebt = _debt[stageNum];        
        _debtTxt.text = "Debt : " + _currentDebt;
    }
    private void Update()
    {
        _sec -= Time.deltaTime;
        if (_sec <= 0)
        {
            _sec += 60;
            _min--;
        }
        string sec = _sec / 10 <= 1 ? "0"+ ((int)_sec).ToString() : ((int)_sec).ToString();
        _timerTxt.text = $"0{_min}:{sec}";
        _timerText.Value = _timerTxt.text;
    }
}
