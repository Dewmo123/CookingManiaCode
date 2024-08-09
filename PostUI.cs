using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostUI : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }
    public void Exit()
    {
        if(DetectUI.instance != null)
            DetectUI.instance._UIFlag = false;
        gameObject.SetActive(false);
    }
}
