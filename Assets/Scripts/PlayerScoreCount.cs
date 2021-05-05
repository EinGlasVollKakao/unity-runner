using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreCount : MonoBehaviour
{
    private Vector3 startPos;
    private int score;
    
    void Start()
    {
        startPos = transform.position; //set Start pos to pos where player is at beginning
    }
    
    void Update()
    {
        score = (int) Vector3.Distance(startPos, transform.position);
        Debug.Log(score);
    }
}
