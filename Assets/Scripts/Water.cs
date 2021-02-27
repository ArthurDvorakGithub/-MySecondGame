using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _timeBetweenDamage;
    private float _time;

    private void Start()
    {
        _time = _timeBetweenDamage;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_time <= 0)
            {
                collision.gameObject.GetComponent<Player>().TakeDamage(_damage);
                _time = _timeBetweenDamage;
            }
            _time -= Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _time = _timeBetweenDamage;
        }
    }
}
