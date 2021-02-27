using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public TreasureData Data;

    public TreasureData Take()
    {
        Destroy(gameObject);
        return Data;
    }
}

