using System;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private Player _player;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _player = _gameManager.Player;
        
    }

    private void OnEnable()
    {
        if (_player == null)
        {
            return;
        }
        
        UpdateView(_player.Score);
        _player.ChangeScore += UpdateView;
    }

    private void OnDisable()
    {
        if (_player == null)
        {
            return;
        }
        
        _player.ChangeScore -= UpdateView;
    }

    private void UpdateView(int score)
    {
        _text.text = score.ToString();
    }
}
