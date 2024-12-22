using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Sprite[] SpriteMute; // 1 = on  0 = off
    public Button ButtonMute;

    private void Awake()
    {
        CheckImage();
    }

    public void BackToMainMenu()
    {
        AudioManager.Instance.PressButton.Play();

        SceneManager.LoadScene(0);

        AudioManager.Instance.GamePlayBGM.Stop();
        AudioManager.Instance.MainMenuBGM.Play();
    }
    
    public void Restart()
    {
        AudioManager.Instance.PressButton.Play();
        AudioManager.Instance.GamePlayBGM.Play();
        SceneManager.LoadScene(1);
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
