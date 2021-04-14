using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private Vector3 camOffset;
    private Vector3 velocity = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        camOffset = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = playerTransform.position + camOffset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.1f);
    }
}
