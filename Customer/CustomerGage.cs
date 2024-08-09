using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGage : MonoBehaviour
{
    public bool _gageFlag;
    private void Update()
    {
        if (_gageFlag)
        {
            StartGage();
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
    }

    private void StartGage()
    {
        gameObject.transform.localScale -= new Vector3(Time.deltaTime / CookManager.instance._orderDelay,0,0);
    }
}
