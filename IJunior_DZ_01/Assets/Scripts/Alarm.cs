using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Swindler>(out Swindler swindler))
        {
            _reached?.Invoke();
        }
    }
}
