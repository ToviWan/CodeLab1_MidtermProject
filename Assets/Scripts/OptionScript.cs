using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionScript : MonoBehaviour
{
    public bool isTrueAnswer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTrueAnswer)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);//go to the next scene if you click on the right option
            }
            else
            {
                SceneManager.LoadScene("EndScene");//gameover, go to the EndScene
            }
        }
        
        
    }
}
