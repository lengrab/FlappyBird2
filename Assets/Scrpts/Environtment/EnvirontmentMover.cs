using System.Collections.Generic;
using UnityEngine;

public class EnvirontmentMover : MonoBehaviour
{
    [SerializeField] private Transform _birdTransform;
    [SerializeField] private int _poolSize = 3;
    [SerializeField] private GameObject _template;
    [SerializeField] private Vector3 _startPosition = Vector3.zero;
    
    private GameObject _lastInstance;
    private float _width;
    private Queue<GameObject> _queue;

    public void Reset()
    {
        while (_queue?.Count > 0)
        {
            Destroy(_queue.Dequeue().gameObject);
            _lastInstance = null;
        }
        
        _queue = new Queue<GameObject>();
        for (int i = 0; i < _poolSize; i++)
        {
            _queue.Enqueue(AddInstance());
        }
    }

    private void Awake()
    {
        _width = GetWidth();
        Reset();
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