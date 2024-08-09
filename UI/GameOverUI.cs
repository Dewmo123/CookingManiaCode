using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _entireOrder;
    [SerializeField] private TextMeshProUGUI _stageCnt;
    [SerializeField] private AudioSource[] _cooking;
    private void OnEnable()
    {
        _cooking[0].Stop();
        _cooking[1].Stop();
        _entireOrder.text = "총 주문 : " + CookManager.instance._orderCnt;
        _stageCnt.text = "스테이지 : " + CookManager.instance._stageCnt;
          
    }
    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
