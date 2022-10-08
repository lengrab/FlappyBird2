using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _template;

    private void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Pipes temp = Instantiate(_template).GetComponent<Pipes>();
        temp.Init(new Vector3(2,0,0));
    }
}
