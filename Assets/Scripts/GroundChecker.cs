using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public GameObject CheckGroundPoint;
    public float RadiusCircle;
    public LayerMask WhatIsGround;

    public bool CheckGround()
    {
        return Physics2D.OverlapCircle(CheckGroundPoint.transform.position, RadiusCircle, WhatIsGround);
    }
}
