using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleLayer;
    
    private void OnCollisionEnter(Collision collision)
    {
        // check if colliding object is not in an obstacle layer
        if (((1<<collision.gameObject.layer) & obstacleLayer) == 0)
        {
            return;
        }

        Time.timeScale = 0;
        Debug.Log("RIP");
    }
}
