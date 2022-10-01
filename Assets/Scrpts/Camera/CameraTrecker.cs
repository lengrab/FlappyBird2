using UnityEngine;

public class CameraTrecker : MonoBehaviour
{
    [SerializeField] Transform _birdTransform;
    [SerializeField] Vector3 _cameraOffset;

    private void Awake()
    {
        if (_birdTransform == null)
        {
            gameObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        transform.position = _birdTransform.position + _cameraOffset;
    }
}
