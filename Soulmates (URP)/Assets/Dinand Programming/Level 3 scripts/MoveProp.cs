using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveProp : MonoBehaviour
{
    public Prop propInHand;
    public LayerMask grabableLayer;
    public LayerMask placeableLayer;
    bool canMove;

    public void OnGrab(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("lol");
        if (callbackContext.started && propInHand)
        {
            canMove = true;
        }
        else if (callbackContext.canceled && propInHand)
        {
            canMove = false;
        }
    }
    public void OnSelectProp(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started && !propInHand && Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 100f, grabableLayer))
        {
            propInHand = hit.collider.GetComponentInParent<Prop>();
        }
        else if (callbackContext.started && propInHand)
        {
            propInHand = null;
            canMove = false;
        }
    }

    public void TransformProp(InputAction.CallbackContext callbackContext)
    {
        if (propInHand)
        {
            Vector2 transformVector = callbackContext.ReadValue<Vector2>();
            if (propInHand.propType == PropType.Window)
            {
                propInHand.transform.localScale += new Vector3(transformVector.x * 0.05f, transformVector.y * 0.05f, 0);
                if (propInHand.transform.localScale.x < 0.1f)
                {
                    propInHand.transform.localScale = new Vector3(0.1f, propInHand.transform.localScale.y, propInHand.transform.localScale.z);
                }
                if (propInHand.transform.localScale.y < 0.1f)
                {
                    propInHand.transform.localScale = new Vector3(propInHand.transform.localScale.x, 0.1f, propInHand.transform.localScale.z);
                }
            }
            else
            {
                propInHand.transform.Rotate(0, -transformVector.x, 0);
                propInHand.rot.y -= transformVector.x;
            }
        }
    }

    void FixedUpdate()
    {
        if (canMove && propInHand.propType == PropType.Window && Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 100f, propInHand.GetComponent<Prop>().mask))
        {
            propInHand.transform.position = hit.point;
            propInHand.transform.rotation = Quaternion.FromToRotation(Vector3.back, hit.normal);
            //propInHand.transform.Rotate(propInHand.GetComponent<Prop>().rot);
        }
        else if (canMove && propInHand.propType != PropType.Window && Physics.Raycast(transform.position, transform.forward, out RaycastHit hit2, 100f, propInHand.GetComponent<Prop>().mask))
        {
            if (hit2.normal == new Vector3(0, 1, 0))
            {
                propInHand.transform.position = hit2.point;
                propInHand.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit2.normal);
                propInHand.transform.Rotate(propInHand.GetComponent<Prop>().rot);
            }
            Debug.Log(hit2.normal);
        }
    }
}
