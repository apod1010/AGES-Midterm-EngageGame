using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float timeLeft = 60.0f;
    float roundEnd = 5.0f;

    public Text timerText;

    public Text victoryText;

    public Text advanceText;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = "" + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            timerText.text = "0";
            victoryText.text = "Winner!";

            roundEnd -= Time.deltaTime;
            advanceText.text = "" + Mathf.Round(roundEnd);
            if(roundEnd < 0)
            {
                SceneManager.LoadScene("end");
            }
        }


    }


}