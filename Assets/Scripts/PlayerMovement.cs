using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum Path // Enum-obj for all possible paths
    {
        Left,
        Mid,
        Right
    }
    private Path currentPath = Path.Mid; // current path of player
    private Path pathToBeOn = Path.Mid; // path that player should be on

    private Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.interpolation = RigidbodyInterpolation.Interpolate;

        //rb.AddForce(new Vector3(0, 0, 1), ForceMode.Acceleration);
    }
    
    // Update is called once per frame
    void Update()
    {
        // **********Movement********** //
        // Jump when touching ground (collision check with empty object below player)
        if (Input.GetKeyDown(KeyCode.Space) && Math.Abs(rb.velocity.y) < 0.1)
        {
            rb.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
        }

        // right
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangePathToBeOn(Direction.Right);
        }

        // left
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangePathToBeOn(Direction.Left);
        }
        
        
        // Debug log
        Debug.Log(currentPath + "-->" +  pathToBeOn);
    }

    private void FixedUpdate()
    {
        MoveToNewPath();
    }

    
    
    
    private float GetPathX(Path path)
    {
        switch (path)
        {
            case Path.Left:
                return -4.7f;
            case Path.Mid:
                return 0;
            case Path.Right:
                return 4.7f;
            default:
                return 0;
        }
    }

    private enum Direction
    {
        Right,
        Left
    }
    private void ChangePathToBeOn(Direction direction)
    {
        switch (direction)
        {
            case Direction.Right:
                if (pathToBeOn != Path.Right)
                {
                    pathToBeOn++;
                }
                break;
            case Direction.Left:
                if (pathToBeOn != Path.Left)
                {
                    pathToBeOn--;
                }
                break;
        }
    }

    private void MoveToNewPath()
    {
        Vector3 pos = rb.position;
        
        if (pathToBeOn == currentPath)
        {
            return;
        }
        Vector3 pathPos = new Vector3(GetPathX(pathToBeOn), pos.y, pos.z);
        Vector3 newPos = Vector3.MoveTowards(pos, pathPos, 1);

        rb.MovePosition(newPos);

        // when player is already on pathToBeOn, update current path
        if (pathPos == newPos)
        {
            currentPath = pathToBeOn;
        }
    }
}
