using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>Captura y procesa el input del jugador</summary>
/// <remarks>Este script encapsula la lógica del input, separándola de la lógica del movimiento</remarks>
public class InputHandler : MonoBehaviour
{
    /// <summary>Referencia a un objeto que implementa la interfaz <see cref="IMoveable"/>
    /// </summary>
    /// <remarks>Este componente se utiliza para delegar las acciones de movimiento 
    /// basadas en el input del usuario.</remarks>
    private IMoveable _moveable;
    // Start is called before the first frame update
    void Start()
    {
        // Obtiene el componente que implementa IMoveable en el mismo GameObject.
        _moveable = GetComponent<IMoveable>();
        if( _moveable == null)
        {
            Debug.LogError("No se encontró un componente que implemente IMoveable en el GameObject");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveable == null) { return; }

        // Captura el input horizontal del usuario y delega la acción a _moveable
        float inputH = Input.GetAxisRaw("Horizontal");
        _moveable.Move(inputH);

        // Si captura el input de alto del usuario delega la acción a _moveable
        if (Input.GetButtonDown("Jump"))
        {
            _moveable.Jump();
        }
    }
}
