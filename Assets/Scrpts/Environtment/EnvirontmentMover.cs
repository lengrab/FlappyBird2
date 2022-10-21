using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnvirontmentMover : MonoBehaviour
{
    [SerializeField] private Transform _birdTransform;
    private Queue<GameObject> _queue;
    [SerializeField] private GameObject _template;
    [SerializeField] private Vector3 _startPosition = Vector3.zero;
    private GameObject _lastInstance;
    [SerializeField] private float _width;
    [SerializeField] private int _poolSize = 3;

    private void Awake()
    {
        _width = GetWidth();
        _queue = new Queue<GameObject>();
        for (int i = 0; i < _poolSize; i++)
        {
            _queue.Enqueue(AddInstance());
        }
    }

    private void MoveLast()
    {
        GameObject instance = _queue.Dequeue();
        instance.transform.position = _lastInstance.transform.position + Vector3.right * _width;
        _lastInstance = instance;
        _queue.Enqueue(instance);
    }
    
    private float GetWidth()
    {
        return _template.GetComponent<SpriteRenderer>().bounds.size.x - 0.001f;
    }

    private GameObject AddInstance()
    {
        GameObject instance = Instantiate(_template, transform);
        if (_lastInstance == null)
        {
            instance.transform.position = _startPosition;
        }
        else
        {
            instance.transform.position = _lastInstance.transform.position + Vector3.right * _width;
        }

        _lastInstance = instance;
        return instance;
    }
    
    private void FixedUpdate()
    {
        if (_birdTransform.position.x >= _lastInstance.transform.position.x)
        {
            MoveLast();
        }
    }
}