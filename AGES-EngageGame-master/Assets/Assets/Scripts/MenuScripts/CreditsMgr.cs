using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMgr : MonoBehaviour 
{
    public string PressBack;

    public void BackButtonClick()
    {
        SceneManager.LoadScene(PressBack);
    }
}
