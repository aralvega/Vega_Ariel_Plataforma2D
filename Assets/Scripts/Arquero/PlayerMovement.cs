using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMoveable
{
    private Rigidbody2D _rb;
    private float _speed;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _speed = 5;
    }

    public void Move(float inputH)
    {
        _rb.velocity = new Vector2 (inputH * _speed, _rb.velocity.y);
    }

    
}
