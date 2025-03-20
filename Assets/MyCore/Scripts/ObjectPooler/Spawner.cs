using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private ObjectPooler _objectPool;
    [SerializeField] private GameObject _cube;
#pragma warning restore 0649
    private float _timeToSpawn = 1f;
    private float _timeSinceSpawn;

    void Update()
    {
        _timeSinceSpawn += Time.deltaTime;
        if (_timeSinceSpawn >= _timeToSpawn)
        {
            GameObject newCritter = _objectPool.GetCritter(_cube);
            newCritter.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
            _timeSinceSpawn = 0f;
        }
    }
}
