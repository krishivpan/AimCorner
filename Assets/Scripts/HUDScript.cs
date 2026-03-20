using System.Threading;
using TMPro;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject timeText;
    [SerializeField] float timeLeft = 30f;
    public bool timerRunning = false;

    public int score = 0;



    void Start()
    {

        Cursor.visible = true;
    }

    void Update()
    {

        if (timerRunning)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                score = 0;
                timeLeft = 0;
                timerRunning = false;
                Debug.Log("Game Over");
            }
        }

        timeText.GetComponent<TMPro.TMP_Text>().text = "Time Remaining: " + Mathf.Ceil(timeLeft);
        scoreText.GetComponent<TMPro.TMP_Text>().text = "Score: " + score;
    }

    public void StartGame()
    {
        timerRunning = true;
        timeLeft = 30f;
    }

    public void AddScore()
    {
        if (timerRunning)
        {
            score++;
        }
    }


}