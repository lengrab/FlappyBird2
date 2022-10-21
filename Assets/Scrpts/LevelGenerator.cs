using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _spaceBetweenPipes;
    [SerializeField] private int _countPipesOnStart = 3;
    [SerializeField] private int _maxPipesOnScene = 6;
    [SerializeField] private float _heightRange = 3;
    [SerializeField] private float _maxHeight = 2;
    private Queue<Pipes> _pipesQueue;
    private Vector3 _nextPosition;
    private Pipes _pipe;

    public void Reset()
    {  
        while (_pipesQueue?.Count > 0)
        {
            Destroy(_pipesQueue.Dequeue().gameObject);
        }
        
        _pipesQueue = new Queue<Pipes>();
        _nextPosition = _startPosition;

        for (int i = 0; i < _countPipesOnStart; i++)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        var offset = 0.5f;
        var height = Mathf.PerlinNoise(1, 0.5f * _nextPosition.x) * _heightRange - _heightRange / 2 + offset;
        var difference = _nextPosition.y - height;

        if (difference > _maxHeight)
        {
            if (height - _nextPosition.y > 0)
            {
                height = _nextPosition.y - _maxHeight;
            }
            else
            {
                height = _nextPosition.y + _maxHeight;
            }
        }

        _pipe = _pipesQueue.Count < _maxPipesOnScene
            ? Instantiate(_template, transform).GetComponent<Pipes>()
            : _pipesQueue.Dequeue();
        _pipe.Init(_nextPosition + Vector3.up * height);
        _nextPosition += _spaceBetweenPipes * Vector3.right;
        _pipesQueue.Enqueue(_pipe);
    }

    private void Awake()
    {
        Reset();
    }
}