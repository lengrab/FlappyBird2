using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private const string GameSceneHash = "Game";

    public void LoadGame()
    {
        SceneManager.LoadScene(GameSceneHash, LoadSceneMode.Single);
    }
}