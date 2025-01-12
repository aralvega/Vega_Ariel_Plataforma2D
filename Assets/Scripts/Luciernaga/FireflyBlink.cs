using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.Universal;

public class FireflyBlink : MonoBehaviour
{
    private Light2D _spotLight;
    private float _blinkInterval;

    // Start is called before the first frame update
    void Start()
    {
        _spotLight = GetComponent<Light2D>();
        _blinkInterval = 1f;
        if (_spotLight == null)
        {
            Debug.LogError("No se encontró el componente Light2D en el GameObject.");
            return;
        }
        // Inicia la corrutina de titileo
        StartCoroutine(BlinkLight());
    }

    private IEnumerator BlinkLight()
    {
        while (true)
        {
            _spotLight.enabled = !_spotLight.enabled; // Alterna el estado del spotlight
            yield return new WaitForSeconds(_blinkInterval); // Espera el intervalo
        }
    }
}
