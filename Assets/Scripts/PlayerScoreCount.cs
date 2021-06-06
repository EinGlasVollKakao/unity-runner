using UnityEngine;

public class PlayerScoreCount : MonoBehaviour
{
    private Vector3 startPos;
    private int score;
    private int highScore = 0;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private UiController uiController;
    
    void Start()
    {
        startPos = new Vector3(0, 0, transform.position.z); //set Start pos to pos where player is at beginning; only set z 
    }
    
    void Update()
    {
        UpdateScore();

        // change speed multiplayer
        UpdateSpeedMultiplier();
    }

    private void UpdateScore()
    {
        Vector3 currentPos = new Vector3(0, 0, transform.position.z); // also only set z to measure only z distance
        score = (int) Vector3.Distance(startPos, currentPos);
        
        uiController.SetScore(score);
    }
    
    private void UpdateSpeedMultiplier()
    {
        playerMovement.MovementSpeedMultiplier = 1 + score / 500f;
        //Debug.Log(playerMovement.MovementSpeedMultiplier);
    }

    public void TriggerSettingHighscore()
    {
        if (score > highScore)
        {
            highScore = score;
            uiController.SetHighScore(highScore);
        }
    }
}
