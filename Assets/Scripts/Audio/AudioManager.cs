using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("BGM")]
    public AudioSource MainMenuBGM;
    public AudioSource GamePlayBGM;
    public AudioSource VictoryBGM;
    public AudioSource GameOverBGM;

    [Header("SFX")]
    public AudioSource SwordSlash;
    public AudioSource PlayerHit;
    public AudioSource EnemyHit;
    public AudioSource EnemyDie;
    public AudioSource PressButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SoundMute()
    {
    
        if (MainMenuBGM.mute == true)
        {
            MainMenuBGM.mute = false;
            GamePlayBGM.mute = false;
            SwordSlash.mute = false;
            PlayerHit.mute = false;
            EnemyHit.mute = false;
            EnemyDie.mute = false;
            PressButton.mute = false;
        }
        else
        {
            MainMenuBGM.mute = true;
            GamePlayBGM.mute = true;
            SwordSlash.mute = true;
            PlayerHit.mute = true;
            EnemyHit.mute = true;
            EnemyDie.mute = true;
            PressButton.mute = true;
        }
    }
}
