using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _pointsPatrol;
    private float _speedPatrol;
    private Vector3 _currentDestination;
    private int _indexPointPatrol;

    // Start is called before the first frame update
    void Start()
    {
        _indexPointPatrol = 0;
        _currentDestination = _pointsPatrol[_indexPointPatrol].position;
        _speedPatrol = 2f;
        StartCoroutine(Patrullar());
    }

    IEnumerator Patrullar()
    {
        while (true) {
            while (transform.position != _currentDestination)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, _currentDestination, _speedPatrol * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            ActualizarDestino();
        }
    }

    private void ActualizarDestino()
    {
        _indexPointPatrol++;
        if (_indexPointPatrol >= _pointsPatrol.Length) { _indexPointPatrol = 0; }
        _currentDestination = _pointsPatrol[_indexPointPatrol].position;
    }

}
