using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawnPoint;

    private float _spawnCoolDown = 2 ;
    private float _elapsedTime = 0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnCoolDown)
        {
            _elapsedTime = 0;

            Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
        }
    }
}
