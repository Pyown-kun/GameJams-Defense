using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseUI;
    public bool IsPause;

    private PlayerInputControls gameInputManager;

    private void Awake()
    {
        gameInputManager = new PlayerInputControls();
    }

    private void Start()
    {
        gameInputManager.UI.Pause.started += _ => Pause();
    }

    private void OnEnable()
    {
        gameInputManager.Enable();
    }

    private void Pause()
    {
        AudioManager.Instance.PressButton.Play();

        if (!IsPause)
        {
            Time.timeScale = 0;
            PauseUI.SetActive(true);
            IsPause = true;
        }
        else
        {
            Resume();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseUI.SetActive(false);
        IsPause = false;
    }
}
