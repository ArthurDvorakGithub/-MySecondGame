using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDrop : MonoBehaviour
{
    [SerializeField] private GameObject _dropItem;
    [SerializeField] private List<TreasureData> _treasures;

    private BoxCollider2D _collider;
    private float _halfSize;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _halfSize = _collider.size.x / 2;

    }

    public void Drop()
    {
        foreach (TreasureData treasure in _treasures)
        {
            Chest chest = Instantiate(_dropItem, new Vector2(Random.Range(transform.position.x - _halfSize, transform.position.x + _halfSize), transform.position.y), Quaternion.identity).GetComponent<Chest>();
            chest.TreasureData = treasure;

        }
        Destroy(gameObject);
    }

}
