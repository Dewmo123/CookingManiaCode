using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StopUI : MonoBehaviour
{
    [SerializeField]private Slider _volumeSlider;
    [SerializeField]private Slider _musicSlider;
    [SerializeField] private Sprite _muteIcon;
    [SerializeField] private Sprite _normalIcon;
    [SerializeField] private Sprite _normalMusicIcon;
    [SerializeField] private Sprite _muteMusicIcon;
    [SerializeField] private Image _volumeIcon;
    [SerializeField] private Image _musicIcon;
    [SerializeField] private Sound _sound;
    private void Awake()
    {
        _musicSlider.value = _sound._musicVolume;
        _volumeSlider.value = _sound._volume;
        ChangeVolume();
        ChangeMusic();
        gameObject.SetActive(false);
    }
    private void Update()
    {
        ChangeVolume();
        ChangeMusic();
    }

    private void ChangeMusic()
    {
        AudioSource music = Camera.main.GetComponent<AudioSource>();
        _sound._musicVolume = music.volume;
        music.volume = _musicSlider.value;
        if(_musicSlider.value == 0)
        {
            _musicIcon.sprite =_muteMusicIcon;
        }
        else
        {
            _musicIcon.sprite = _normalMusicIcon;
        }
    }

    private void ChangeVolume()
    {
        AudioListener.volume = _volumeSlider.value;
        _sound._volume = AudioListener.volume;
        if (_volumeSlider.value == 0)
        {
            _volumeIcon.sprite = _muteIcon;
        }
        else
        {
            _volumeIcon.sprite = _normalIcon;
        }
    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
