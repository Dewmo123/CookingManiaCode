using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _manual;
    [SerializeField] private GameObject _config;
    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Config()
    {
        _config.SetActive(true);
    }
    public void Manual()
    {
        _manual.SetActive(true);
    }
}
