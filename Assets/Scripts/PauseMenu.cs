using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public SceneFader Fader;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Toggle();

        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if(ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Fader.FadeTo("MainMenu");
        //SceneManager.LoadScene("MainMenu");
        Debug.Log("Go to menu");
    }
}
