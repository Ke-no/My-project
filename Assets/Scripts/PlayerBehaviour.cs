using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    Image coinTrackingIcon;

    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    Sprite[] coinTrackingSprites;

    int currentScore = 0;
    int currentCoinCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "SCORE: " + currentScore.ToString();

        if (coinTrackingSprites.Length > 0)
        {
        coinTrackingIcon.sprite = coinTrackingSprites[currentCoinCount];
        }
    }
    public void ModifyScore(int amt)
    {
        currentScore += amt;
        scoreText.text = "SCORE: " + currentScore.ToString();
        
    }

    public void CollectCoin()
    {
        currentCoinCount++;
        
        if(currentCoinCount >= coinTrackingSprites.Length)
        {
            currentCoinCount = coinTrackingSprites.Length - 1;
        }
        coinTrackingIcon.sprite = coinTrackingSprites[currentCoinCount];
    
    }
}

