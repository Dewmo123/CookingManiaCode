using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageUI : MonoBehaviour
{
    public static StorageUI instance=null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }
    public void Exit()
    {
        DetectUI.instance._UIFlag = false;
        gameObject.SetActive(false);
    }
}
