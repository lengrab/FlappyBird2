using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class BirdCollisionHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _achivment;
    [SerializeField] private UnityEvent _fail;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Gate gate))
        {
            _achivment.Invoke();
        }

        if (collision.TryGetComponent(out Ground ground))
        {
            _fail.Invoke();
        }
    }
}