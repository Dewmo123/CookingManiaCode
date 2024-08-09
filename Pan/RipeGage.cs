using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipeGage : MonoBehaviour
{
    [SerializeField] PanUI _pan1;
    private void Update()
    {
        if (_pan1._timerFlag)
        {
            StartRipeTimer();
        }
    }
    public void StartRipeTimer()
    {
        gameObject.transform.localScale += new Vector3(Time.deltaTime / _pan1._chosenItemCompo._chosenItem.CookTime, 0,0);
        _pan1._gage.fillAmount = gameObject.transform.localScale.x;
        if (gameObject.transform.localScale.x>=1)
        {
            _pan1._timerFlag = false;
            _pan1.CompleteCook();
        }
    }
}
