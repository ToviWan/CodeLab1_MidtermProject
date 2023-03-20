using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayTime : MonoBehaviour
{
    public float countDownTime;
    public TextMeshProUGUI timetxt;

    private float t;

    private float seconds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        float minutes = Mathf.FloorToInt(t / 60);
        seconds = countDownTime - Mathf.FloorToInt(t % 60);
        timetxt.text = seconds.ToString();
        //DataHolder.timeTxt = timetxt.text;// get the time text from this scene and store it into DataHolder
        if (seconds <= 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    private void OnDestroy()
    {
        GameManager.usedTime += (countDownTime - seconds);
    }
}
