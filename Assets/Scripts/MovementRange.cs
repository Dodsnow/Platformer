using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRange : MonoBehaviour
{
    public Transform corner_min;
    public Transform corner_max;
    private float x_min;
    private float y_min;
    private float x_max;
    private float y_max;

    private void Awake()
    {
        x_max = corner_max.position.x;
        x_min = corner_min.position.x;
        y_max = corner_max.position.y;
        y_min = corner_min.position.y;
    }
    

    private void FixedUpdate()
    {
        KeepWithinMinMaxRectangle();
    }
    private void KeepWithinMinMaxRectangle()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        float clampedX = Mathf.Clamp(x, x_min, x_max);
        float clampedY = Mathf.Clamp(y, y_min, y_max);
        transform.position = new Vector3(clampedX, clampedY, z);
    }
}
