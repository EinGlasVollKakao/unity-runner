using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleLayer;
    
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private UiController uiController;
    [SerializeField] private PlayerScoreCount scoreCount;

    private void OnCollisionEnter(Collision collision)
    {
        // check if colliding object is not in an obstacle layer
        if (((1<<collision.gameObject.layer) & obstacleLayer) == 0) 
            return;
        

        scoreCount.TriggerSettingHighscore();
        
        Debug.Log("RIP");
        
        // pause game & reset player
        playerMovement.GamePaused = true;
        playerMovement.PlayerDead = true;
        
        // show hint
        uiController.ShowRestartHint();

    }
}