using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionMgr : MonoBehaviour
{
    public string PressBack;
    public string PressPlayers;

    public void BackButtonClick()
    {
        SceneManager.LoadScene(PressBack);
    }

    public void PlayersButtonClick()
    {
        SceneManager.LoadScene(PressPlayers);
    }
}
