using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTracker : MonoBehaviour
{
    [SerializeField] private float _far;
    [SerializeField] private GameObject _target;

    void Update()
    {
        transform.position = new Vector3(_target.transform.position.x,transform.position.y, _far);
    }
}
