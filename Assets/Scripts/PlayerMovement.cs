using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] UiController uiController;

    private Rigidbody rb;
    private Animator animator;

    private enum Path // Enum-obj for all possible paths
    {
        Left,
        Mid,
        Right
    }
    
    private Path pathToBeOn = Path.Mid; // path that player should be on

    private const float ForwardMovSpeed = 0.2f;
    private const float HorizontalMovSpeed = 1;

    private float movementSpeedMultiplier = 1;
    public float MovementSpeedMultiplier
    {
        get => movementSpeedMultiplier;
        set => movementSpeedMultiplier = value;
    }

    // starting position for reseting
    private Vector3 startingPos;

    // bools for game paused (= disable movement) & player dead (= resetting player position when unpausing)
    private bool gamePaused = true;
    public bool GamePaused
    {
        get => gamePaused;
        set => gamePaused = value;
    }

    private bool playerDead = false;
    public bool PlayerDead
    {
        get => gamePaused;
        set => playerDead = value;
    }
    
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        
        startingPos = rb.position;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        
        uiController.ShowStartHint();
    }

    void Update()
    {
        
        animator.SetBool("isRunning", !gamePaused);

        
        // unpause game
        if (gamePaused && Input.GetKeyDown(KeyCode.Return))
        {
            gamePaused = false;

            uiController.HideHints();
            
            // if player dead, reset player pos when 'unpausing'
            if (playerDead)
            {
                pathToBeOn = Path.Mid;
                MovementSpeedMultiplier = 1;

                // reset position
                rb.position = startingPos;

                playerDead = false;
            }
        }
        
        
        // if game is paused, ignore movement key inputs
        if (gamePaused)
            return;

        
        // **********Movement********** //
        // Jump when touching ground (check if vertical (((velocity is near 0 AND))) if y is near starting y (ground)
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
            && rb.position.y < startingPos.y + 0.1)
        {           
            rb.AddForce(Vector3.up * 12.5f, ForceMode.VelocityChange);
            animator.SetTrigger("jump");
        }

        // right
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangePathToBeOn(Direction.Right);
        }

        // left
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangePathToBeOn(Direction.Left);
        }
    }

    private void FixedUpdate()
    {
        // if game paused -> don't move forward
        if (gamePaused)
            return;
        
        MoveForward();
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
        

        Vector3 pathPos = new Vector3(GetPathX(pathToBeOn), pos.y, pos.z);
        Vector3 newPos = Vector3.MoveTowards(pos, pathPos, HorizontalMovSpeed * movementSpeedMultiplier);

        rb.MovePosition(newPos);
    }


    private void MoveForward()
    {   
        Vector3 pos = rb.position;
        Vector3 forward = pos + new Vector3(0, 0, ForwardMovSpeed * movementSpeedMultiplier);

        rb.MovePosition(forward);
    }
}