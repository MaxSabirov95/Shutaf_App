using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterReturn : MonoBehaviour
{
    private ObjectPooler _objectPool;
#pragma warning disable 0649
    [SerializeField] private int _poolStartSize = 10;
#pragma warning restore 0649
    void Start()
    {
        _objectPool = FindObjectOfType<ObjectPooler>();
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(_poolStartSize);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(nameof(Disable));
    }

    private void OnDisable()
    {
        if (_objectPool != null)
            _objectPool.ReturnCritter(gameObject);
    }
}
