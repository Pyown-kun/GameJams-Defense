using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScripts : MonoBehaviour
{
    public Sprite[] SpriteMute; // 1 = on  0 = off
    public Button ButtonMute;

    private void Awake()
    {
        CheckImage();
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);

        AudioManager.Instance.PressButton.Play();

        AudioManager.Instance.MainMenuBGM.Stop();
        AudioManager.Instance.GamePlayBGM.Play();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Mute()
    {    
        AudioManager.Instance.SoundMute();

        CheckImage();
    }

    private void CheckImage()
    {
        if (AudioManager.Instance.MainMenuBGM.mute == false)
        {

            ButtonMute.image.sprite = SpriteMute[0];
        }
        else
        {
            ButtonMute.image.sprite = SpriteMute[1];
        }
    }
}
