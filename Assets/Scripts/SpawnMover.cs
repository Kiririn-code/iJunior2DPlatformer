using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnMover : MonoBehaviour
{
    [SerializeField] private int _leftMaxPosition = -9;
    [SerializeField] private int _rightMaxposition = 9;
    [SerializeField] private int _speed = 2;

    private bool _doChangeSide;

    
    private void Update()
    {
        if (transform.position.x >= _rightMaxposition)
            _doChangeSide = false;

        if (transform.position.x <= _leftMaxPosition)
            _doChangeSide = true;

        transform.Translate(_speed * (_doChangeSide ? 1 : -1) * Time.deltaTime, 0, 0);
    }
}
