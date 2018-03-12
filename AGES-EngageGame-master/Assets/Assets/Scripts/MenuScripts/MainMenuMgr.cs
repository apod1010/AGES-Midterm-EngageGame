using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMgr : MonoBehaviour 
{
    public string PressStart;
    public string PressCredits;

    public void StartButtonClick()
    {
        SceneManager.LoadScene(PressStart);
    }

    public void CreditsButtonClick()
    {
        SceneManager.LoadScene(PressCredits);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
