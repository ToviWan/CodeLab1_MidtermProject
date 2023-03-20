using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    TextMeshProUGUI scoretxt;

    private void Awake()
    {
        scoretxt = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    private void Start()
    {

        scoretxt.text = "You Spent " + GameManager.usedTime.ToString() + " Seconds"
            + "\n"+ "Be faster next time UwU";
    }
}
