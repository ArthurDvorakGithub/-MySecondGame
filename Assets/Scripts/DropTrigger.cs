using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTrigger : MonoBehaviour
{
    [SerializeField] private AirDrop _zone;

    private void OnTriggerExit2D(Collider2D collision)
    {
        _zone.Drop();

        Destroy(gameObject);
    }

}
