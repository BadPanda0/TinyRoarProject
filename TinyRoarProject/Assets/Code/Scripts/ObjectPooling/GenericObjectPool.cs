using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericObjectPool<TypeToPool> : MonoBehaviour where TypeToPool : Component 
{
    [SerializeField] private TypeToPool _prefab;

    public static GenericObjectPool<TypeToPool> Instance { get; private set; }
    private Queue<TypeToPool> _objects = new Queue<TypeToPool>();

    private void Awake()
    {
        Instance = this;
    }

    public TypeToPool Get()
    {
        if (_objects.Count == 0)
            AddObjects(1);
        return _objects.Dequeue();
    }

    public void ReturnToPool(TypeToPool objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        _objects.Enqueue(objectToReturn);
    }

    private void AddObjects(int count)
    {
        var newObject = GameObject.Instantiate(_prefab);
        newObject.gameObject.SetActive(false);
        _objects.Enqueue(newObject);
    }
}
