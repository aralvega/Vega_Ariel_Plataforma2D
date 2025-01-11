using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Controla el movimiento del jugador basado en el input del usuario.</summary>
/// <remarks>
/// Este script utiliza un Rigidbody2D para aplicar movimiento f�sico y responde a
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
    /// <summary>Indica el estado del ataque</summary>
    private bool _isAttacking;
    
    private Animator _animator;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _speed = 10;
        _jumpForce = 26;
        _animator = GetComponent<Animator>();
        _isAttacking = false;    
    }

    /// <summary>Realiza un movimiento lateral</summary>
    /// <param name="inputH">Direcci�n del movimiento, entre -1 (izquierda) y 1 (derecha). 
    /// 0 indica que no hay movimiento</param>
    public void Move(float inputH)
    { 
        if (_isAttacking) return; //Bloquea el movieminto si est� atacando

        _rb.velocity = new Vector2 (inputH * _speed, _rb.velocity.y);
        if (inputH != 0)
        {
            _animator.SetBool("isRunning", true);
            if (inputH > 0)
            {
                transform.eulerAngles = Vector2.zero;
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }

    /// <summary>Realiza un salto</summary>
    public void Jump()
    {
        if( _isAttacking) return; //Bloquea si est� atacando
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _animator.SetTrigger("jump");
        
    }

    /// <summary>Realiza un ataque</summary>
    public void Attack()
    {
        _isAttacking = true; //Marca como atacando
        //_rb.velocity = Vector2.zero; //Detiene el movimiento horizontal
        _animator.SetTrigger("attack");
    }


    /// <summary>Determina si el jugador se puede mover en base a 
    /// la animaci�n que se est� ejecutando. Mientras ataca no puede moverse</summary>
    public bool CanMove()
    {  
        return !_isAttacking;
        
    }

    /// <summary>Finaliza el ataque (deber�a ser llamado desde un evento de la animaci�n)</summary>
    public void EndAttack()
    {
        _isAttacking = false; // Libera el estado de ataque
    }
}
