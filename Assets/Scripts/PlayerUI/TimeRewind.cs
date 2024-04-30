using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class TimeRewind : MonoBehaviour
{
    private bool timeRewind = false;
    private Stack<PointInTime> pointsInTime;
    public Rigidbody2D rigidbody;
    private PointInTime pointInTime;
    public float maxRewindDuration = 5f;
    private PlayerInventory playerInventory;
    private bool canRewind;

    // Input action asset
    public InputActionAsset actionAsset;
    private InputAction rewindAction;


    void Awake()
    {
        rewindAction = actionAsset.FindAction("RewindTime");
        rewindAction.Enable();
        rewindAction.performed += ctx => RewindStarted();
        rewindAction.canceled += ctx => RewindStopped();
    }

    void Start()
    {
        pointsInTime = new Stack<PointInTime>();
        rigidbody = GetComponent<Rigidbody2D>();
        playerInventory = GetComponent<PlayerInventory>();
    }


    private bool RewindStarted()
    {
        CheckForPossibilityOfRewind();
        if (!canRewind) return timeRewind = false;
        playerInventory.rewindQuantity--;
        
        return timeRewind = true;
    }

    private bool RewindStopped()
    {
        return timeRewind = false;
    }

    void FixedUpdate()
    {
        if (!timeRewind)
            Record();
        else
            Rewind();
    }

    bool CheckForPossibilityOfRewind()
    {
        if (playerInventory.rewindQuantity <= 0) return canRewind = false;

        return canRewind = true;
    }

    void Record() // Record Stack initialiazing and add an element. 
    {
        pointInTime = new PointInTime(transform.position, rigidbody.velocity);
        pointsInTime.Push(pointInTime);
        // Debug.Log($"Record {pointsInTime.Count} records in time.");

        if (pointsInTime.Count >
            MathF.Round(maxRewindDuration / Time.deltaTime)) //Max Rewind Duration of one record element
        {
            pointsInTime.Clear();
        }
    }

    public void Rewind()
    {
        Debug.Log("Rewind");

        PointInTime pointInTime;
        if (pointsInTime.Count > 0)
        {
            pointInTime = pointsInTime.Pop();
        }
        else
        {
            pointInTime = pointsInTime.Peek();
        }

        transform.position = pointInTime.GetPosition();
        rigidbody.velocity = pointInTime.GetVelocity();
    }

    void OnDisable()
    {
        rewindAction.Disable();
    }
}