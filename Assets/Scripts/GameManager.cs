using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text winText;
    public TMP_Text loseText;
    public GameObject player;
    public GameObject enemy;
    public int countdownTime = 5;

    private bool gameStarted = false;
    private float currentTime;

    void Start()
    {
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
        currentTime = countdownTime;
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (currentTime > 0)
        {
            timerText.text = currentTime.ToString("0");
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        timerText.text = "DRAW!";
        gameStarted = true;
        player.GetComponent<PlayerController>().EnableControls();
        enemy.GetComponent<EnemyController>().EnableControls();
    }

    public void PlayerLost()
    {
        loseText.gameObject.SetActive(true);
        EndGame();
    }

    public void EnemyLost()
    {
        winText.gameObject.SetActive(true);
        EndGame();
    }

    void EndGame()
    {
        gameStarted = false;
        player.GetComponent<PlayerController>().DisableControls();
        enemy.GetComponent<EnemyController>().DisableControls();
    }
}
