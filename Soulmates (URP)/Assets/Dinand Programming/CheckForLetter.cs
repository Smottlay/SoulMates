using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForLetter : MonoBehaviour
{
    public bool isHoldingLetter;
    public LayerMask layerMask;
    public float rad;

    public void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, rad, layerMask);
        if (colliders.Length > 0)
        {
            isHoldingLetter = true;
        }
        else isHoldingLetter = false;
    }
}
