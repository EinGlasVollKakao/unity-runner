using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private PlayerMovement playerMovement;
    
    private void OnCollisionEnter(Collision collision)
    {
        // check if colliding object is not in an obstacle layer
        if (((1<<collision.gameObject.layer) & obstacleLayer) == 0)
        {
            return;
        }

        
        Debug.Log("RIP");
        
        playerMovement.ResetPlayer();
    }
}