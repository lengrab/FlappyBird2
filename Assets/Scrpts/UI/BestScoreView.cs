using TMPro;
using UnityEngine;

public class BestScoreView : MonoBehaviour
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
        
        _text.text = _player.BestScore.ToString();
    }
}
