using System;
using UnityEngine;
using TMPro;

public class UiController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text startHint;
    [SerializeField] private TMP_Text restartHint;


    private void Start()
    {
        highScoreText.enabled = false;
    }


    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetHighScore(int highScore)
    {
        highScoreText.text = highScore.ToString();
        highScoreText.enabled = true;
    }

    public void HideHints()
    {
        startHint.enabled = false;
        restartHint.enabled = false;
    }
    
    public void ShowStartHint()
    {
        HideHints();
        startHint.enabled = true;
    }
    
    public void ShowRestartHint()
    {
        HideHints();
        restartHint.enabled = true;
    }
    
}