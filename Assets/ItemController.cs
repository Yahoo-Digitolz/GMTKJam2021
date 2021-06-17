using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemController : MonoBehaviour
{
    [SerializeField] private UnityEvent _onCollect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            _onCollect.Invoke();
        }
    }
}
