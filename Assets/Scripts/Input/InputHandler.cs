using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private IMoveable _moveable;
    // Start is called before the first frame update
    void Start()
    {
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

        float inputH = Input.GetAxisRaw("Horizontal");
        _moveable.Move(inputH);
    }
}
