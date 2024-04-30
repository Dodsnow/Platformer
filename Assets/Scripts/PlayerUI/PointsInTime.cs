using UnityEngine;


public struct PointInTime
{
    public Vector2 position;
    public Vector2 velocity;

    public PointInTime(Vector2 _position, Vector2 _velocity)
    {
        position = _position;
        velocity = _velocity;
    }

    public Vector2 GetPosition()
    {
        return position;
    }

    public Vector2 GetVelocity()
    {
        return velocity;
    }
}



