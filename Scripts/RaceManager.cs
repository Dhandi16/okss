using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceManager : MonoBehaviour
{
    public TMP_Text countdownText;
    public TMP_Text resultText;

    public bool raceStarted = false;
    public bool raceOver = false;

    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        countdownText.text = "3";
        yield return new WaitForSeconds(1);

        countdownText.text = "2";
        yield return new WaitForSeconds(1);

        countdownText.text = "1";
        yield return new WaitForSeconds(1);

        countdownText.text = "GO!";
        raceStarted = true;

        yield return new WaitForSeconds(1);
        countdownText.gameObject.SetActive(false);
    }

    public void PlayerWin()
    {
        if (raceOver) return;
        raceOver = true;

        resultText.text = "YOU WIN!";
        resultText.gameObject.SetActive(true);
        raceStarted = false;
    }

    public void PlayerLose()
    {
        if (raceOver) return;
        raceOver = true;

        resultText.text = "YOU LOSE!";
        resultText.gameObject.SetActive(true);
        raceStarted = false;
    }
}