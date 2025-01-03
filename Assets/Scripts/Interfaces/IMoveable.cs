using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Interfaz que define el contrato de las funciones de movimiento
/// </summary>
/// <remarks>
/// Esta interfaz permite implementar diferentes estrategias de movimiento para 
/// objetos del juego, como jugadores, enemigos o NPCs
/// </remarks>
public interface IMoveable
{
    /// <summary>Realiza un movimiento lateral</summary>
    /// <param name="inputH">Dirección del movimiento, entre -1 (izquierda) y 1 (derecha). 
    /// 0 indica que no hay movimiento</param>
    void Move(float inputH);
    
    /// <summary>Realiza un salto</summary>
    void Jump();
}
