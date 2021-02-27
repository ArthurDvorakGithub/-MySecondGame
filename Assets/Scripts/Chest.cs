using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public TreasureData TreasureData;

    [SerializeField] private GameObject _treasure;

    public void Open()
    {
        Treasure treasure = Instantiate(_treasure, transform.position, Quaternion.identity).GetComponent<Treasure>();
        treasure.Data = TreasureData;
        Destroy(gameObject); 

    }
}
