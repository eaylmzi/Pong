using Assets.Scripts.Constants;
using System;
using UnityEngine;

public class ComputerPaddle : Paddle
{
    public Rigidbody2D ball;
    private Vector2 _direction;
    private Action moveMethod;
    void Start()
    {
        if (GameData.GAME_DATA == GameMode.SINGLE_PLAYER)
        {
            moveMethod = HandleAIDirection; 
        }
        else
        {
            moveMethod = HandleSecondPlayerDirection; 
        }
    }
    private void Update()
    {
        moveMethod?.Invoke();
    }
    private void FixedUpdate()
    {
     
        if (_direction.sqrMagnitude != 0)
        {
            _rigidbody.AddForce(_direction * this.speed);
        }
    }

    private void HandleAIDirection()
    {
        if (this.ball.linearVelocity.x > 0.0f)
        {
            if (this.ball.position.y > this.transform.position.y)
            {
                _direction = Vector2.up;
            }
            else if (this.ball.position.y < this.transform.position.y)
            {
                _direction = Vector2.down;
            }
        }
        else
        {
            if (this.transform.position.y > 0.0f)
            {
                _direction = Vector2.down;
            }
            else if (this.transform.position.y < 0.0f)
            {
                _direction = Vector2.up;
            }
        }
    }

    public void HandleSecondPlayerDirection()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
        }
        else
        {
            _direction = Vector2.zero;
        }
    }
}
