using System.Threading;
using TMPro;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject timeText;
    [SerializeField] float timeLeft = 30f;
    public bool timerRunning = false;


    void Start()
    {
        
        Cursor.visible = true;

        int score = 0;

        scoreText.GetComponent<TMPro.TMP_Text>().text = "Score: " + score;
    }

    void Update()
    {

        if (timerRunning)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                timeLeft = 0;
                timerRunning = false;
                Debug.Log("Game Over");
            }
        }

        timeText.GetComponent<TMPro.TMP_Text>().text = "Time Remaining: " + Mathf.Ceil(timeLeft);
    }

    public void StartGame()
    {
        timerRunning = true;
        timeLeft = 30f;
    }


}