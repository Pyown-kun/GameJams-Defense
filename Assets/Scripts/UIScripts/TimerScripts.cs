using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScripts : MonoBehaviour
{
    [SerializeField] private float goTime;
    [SerializeField] private float backTime;
    [SerializeField] private float timer;
    [SerializeField] private float secondTimer;

    public Slider TimeProgress;
    public Slider SecondTimeProgress;
    
    public GameObject ObjectProgress;
    public GameObject SecondObjectProgress;

    private void Start()
    {
        timer = goTime;
        secondTimer = backTime;
    }

    private void Update()
    {
        GoTime();
    }

    private void GoTime()
    {
        TimeProgress.value = timer / goTime;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            TimeBack();
        }
    }

    private void TimeBack()
    {
        ObjectProgress.SetActive(false);
        SecondObjectProgress.SetActive(true);

        SecondTimeProgress.value = secondTimer / backTime;

        secondTimer -= Time.deltaTime;

        if (secondTimer <= 0)
        {
            AudioManager.Instance.GamePlayBGM.Stop();
            SceneManager.LoadScene(3);
        }
    }

}
