using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScripts : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private float timer;

    public Slider TimeProgress;

    private void Start()
    {
        timer = maxTime;
    }

    private void Update()
    {
        TimeProgress.value = timer / maxTime;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

}
