using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveProp : MonoBehaviour
{
    public GameObject propInHand;
    public LayerMask grabableLayer;
    public LayerMask placeableLayer;

    public void OnGrab(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("lol");
        if (callbackContext.started && !propInHand && Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 100f, grabableLayer))
        {
            propInHand = hit.collider.GetComponentInParent<Prop>().gameObject;
        }
        else if (callbackContext.started && propInHand)
        {
            propInHand = null;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (propInHand && Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 100f, propInHand.GetComponent<Prop>().mask))
        {
            Debug.Log(hit.normal);
            propInHand.transform.position = hit.point;
            propInHand.transform.rotation = Quaternion.FromToRotation(Vector3.back, hit.normal);
            propInHand.transform.Rotate(propInHand.GetComponent<Prop>().rot);
        }
    }
}
