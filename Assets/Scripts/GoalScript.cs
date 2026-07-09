using TMPro;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public TMP_Text scoreText;

    private int score = 0;

    private void Start()
    {
        scoreText.text = "Score: " + score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            score++;
            scoreText.text = "Score: " + score;
            Debug.Log("Score: " + score);
        }
    }
}
