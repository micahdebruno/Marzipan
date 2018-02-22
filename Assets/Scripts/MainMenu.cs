using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 
    public Canvas MainCanvas;
    public Canvas Controls;
    public Canvas Credits;

    public void Start()
    {
        Controls.enabled = false;
        Credits.enabled = false;
        MainCanvas.enabled = true;
    }

    public void LoadOn()
    {
        SceneManager.LoadScene(1);       
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ControlsOn()
    {

        Controls.enabled = true;
        Credits.enabled = false;
        MainCanvas.enabled = false;
    }

    public void CreditsOn()
    {

        Controls.enabled = false;
        Credits.enabled = true;
        MainCanvas.enabled = false;
    }
    
    public void Back()
    {
        Controls.enabled = false;
        Credits.enabled = false;
        MainCanvas.enabled = true;
    }
}
