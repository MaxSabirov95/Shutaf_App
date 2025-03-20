using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectPool
{
#pragma warning disable 0649
    [SerializeField] private string _objectsName;
#pragma warning restore 0649
    public string objectName = "";
    public GameObject critterPrefab;
    public Queue<GameObject> critterPool = new Queue<GameObject>();
    public int poolStartSize = 5;
}

public class ObjectPooler : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private List<ObjectPool> _objectsToPool;
    [SerializeField] private Transform _pooledObjectsHolder;
#pragma warning restore 0649

    void Start()
    {
        for (int i = 0; i < _objectsToPool.Count; i++)
        {
            for (int j = 0; j < _objectsToPool[i].poolStartSize; j++)
            {
                GameObject critter = Instantiate(_objectsToPool[i].critterPrefab, _pooledObjectsHolder);
                _objectsToPool[i].critterPool.Enqueue(critter);
                critter.SetActive(false);

                if (_objectsToPool[i].objectName == "")
                    _objectsToPool[i].objectName = critter.name;
            }
        }
    }

    public GameObject GetCritter(GameObject gameObject)
    {
        for (int i = 0; i < _objectsToPool.Count; i++)
        {
            if (_objectsToPool[i].objectName == gameObject.name + "(Clone)")
            {
                GameObject critter;
                if (_objectsToPool[i].critterPool.Count > 0)
                {
                    critter = _objectsToPool[i].critterPool.Dequeue();
                    critter.SetActive(true);
                    return critter;
                }
                else
                {
                    critter = Instantiate(_objectsToPool[i].critterPrefab, _pooledObjectsHolder);
                    _objectsToPool[i].critterPool.Enqueue(critter);
                    critter.SetActive(false);

                    _objectsToPool[i].poolStartSize++;
                    critter = _objectsToPool[i].critterPool.Dequeue();
                    critter.SetActive(true);
                    return critter;
                }
            }
        }

        Debug.LogError("No Match For " + gameObject.name + " Object");
        return null;
    }

    public void ReturnCritter(GameObject critter)
    {
        for (int i = 0; i < _objectsToPool.Count; i++)
        {
            if(_objectsToPool[i].objectName == critter.name)
            {
                _objectsToPool[i].critterPool.Enqueue(critter);
                critter.SetActive(false);
                return;
            }
        }

        Debug.LogError(critter.name + " Didnt Enqueue");
    }
}