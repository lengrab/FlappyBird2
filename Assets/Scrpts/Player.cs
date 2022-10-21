using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string BestScoreHash = "best_score";
    private int _score;
    private int _bestScore;

    public event Action<int> ChangeScore;
    
    public int Score => _score;
    public int BestScore => _bestScore;

    public void AddPoint()
    {
        _score++;
        ChangeScore?.Invoke(_score);
            
        if (_score > _bestScore)
        {
            _bestScore = _score;
        }
    }
    
    public void Reset()
    {
        _score = 0;
    }

    private void Awake()
    {
        Load();
    }
    
    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }
    
    private void Load()
    {
        _bestScore = ES3.Load(BestScoreHash,0);
    }
    
    private void Save()
    {
        ES3.Save(BestScoreHash,_bestScore);
    }
}
