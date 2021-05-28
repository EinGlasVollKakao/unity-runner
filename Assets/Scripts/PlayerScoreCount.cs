using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreCount : MonoBehaviour
{
    private Vector3 startPos;
    private int score;

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private TMP_Text scoreText;
    
    void Start()
    {
        startPos = new Vector3(0, 0, transform.position.z); //set Start pos to pos where player is at beginning; only set z 
    }
    
    void Update()
    {
        Vector3 currentPos = new Vector3(0, 0, transform.position.z); // also only set z to measure only z distance
        
        score = (int) Vector3.Distance(startPos, currentPos);
        
        scoreText.text = score.ToString();
        
        
        
        // change speed multiplayer
        playerMovement.MovementSpeedMultiplier = 1 + score / 100f;
        Debug.Log(playerMovement.MovementSpeedMultiplier);

    }
}
