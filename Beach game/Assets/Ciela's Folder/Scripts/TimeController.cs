using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
/*
 * Author: [Pieczynska, Daria & Parent, Ciela]
 * Last Updated: [12/072023]
 * [Timer]
 */
public class TimeController : MonoBehaviour
{
    public static TimeController instance;
    public TMP_Text timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    public float elapsedTime;

    private void Awake()
    {
        instance = this;
    }
    private void Start() 
    {
        timeCounter.text = "Time: 00:00:00";
        timerGoing = false;
        beginTimer();
    }

    public void beginTimer() 
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EndTimer() 
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer() 
    {
        while (timerGoing) 
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            if (elapsedTime >= 180.0f)
            {
                SceneManager.LoadScene(1);
            }

            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
