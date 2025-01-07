using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Controla el movimiento del jugador basado en el input del usuario.</summary>
/// <remarks>
/// Este script utiliza un Rigidbody2D para aplicar movimiento físico y responde a
/// las entradas del usuario procesadas por el script InputHandler. <see cref="InputHandler"/>
/// </remarks> 
public class PlayerMovement : MonoBehaviour, IMoveable
{
    /// <summary>Referencia al Rigidbody2D del jugador</summary>
    private Rigidbody2D _rb;
    /// <summary>Velocidad horizontal del jugador en unidades por segundo</summary>
    private float _speed;
    /// <summary>Impuso del jugador cuando salta</summary>
    private float _jumpForce;
    /// <summary>Indica si está pisando el suelo</summary>
    private bool _isGrounded;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _speed = 10;
        _jumpForce = 26;
        _isGrounded = true;
    }

    /// <summary>Realiza un movimiento lateral</summary>
    /// <param name="inputH">Dirección del movimiento, entre -1 (izquierda) y 1 (derecha). 
    /// 0 indica que no hay movimiento</param>
    public void Move(float inputH)
    {
        _rb.velocity = new Vector2 (inputH * _speed, _rb.velocity.y);
    }

    /// <summary>Realiza un salto</summary>
    public void Jump()
    {
        //if (_isGrounded)
        //{
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
          //  _isGrounded=false;
        //}
    }

    /// <summary>Determina si existe una colisión con un objeto ubicado en la parte inferior
    /// y establece que lo está pisando</summary>
    /// <param name="collision">Representa el collider del objeto colisionante</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Analiza colisióncollision con múltiples puntos que están por encima del objeto (normal).
        foreach (var contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                _isGrounded = true;
                return;
            }
        }
    }




}
