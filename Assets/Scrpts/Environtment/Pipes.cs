using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private Transform _topPipeTransform;
    [SerializeField] private Transform _downPipeTransform;
    [SerializeField] private float _height = 2;

    float topHieght;
    float downHieght;

    public void Init(Vector3 position)
    {
        transform.position = position;
    }

    private void Awake()
    {
        Vector3 startPosition = transform.position;
        topHieght = _topPipeTransform.gameObject.GetComponent<BoxCollider2D>().size.y;
        downHieght = _downPipeTransform.gameObject.GetComponent<BoxCollider2D>().size.y;

        _topPipeTransform.position = startPosition + new Vector3(0, _height / 2 + topHieght / 2, 0);
        _downPipeTransform.position = startPosition - new Vector3(0, _height / 2 + downHieght / 2, 0);
    }
}