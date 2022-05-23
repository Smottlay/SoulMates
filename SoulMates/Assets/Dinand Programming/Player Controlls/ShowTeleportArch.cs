using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.XR.OpenVR;

public class ShowTeleportArch : MonoBehaviour
{
    public Transform playerDummy;
    public LineRenderer lr;
    bool show;

    public void ShowTp(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            show = true;
            lr.enabled = true;
        }
        else if (callbackContext.canceled)
        {
            show = false;
            lr.enabled = false;
            playerDummy.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (show == true)
        {
            lr.SetPosition(0, transform.position);
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 500f))
            {
                lr.SetPosition(1, hit.point);
                if (hit.collider.tag == "Floor")
                {
                    playerDummy.gameObject.SetActive(true);
                    playerDummy.position = hit.point;
                    playerDummy.eulerAngles = new Vector3();
                }
                else playerDummy.gameObject.SetActive(false);
            }
            else
            {
                lr.SetPosition(1, transform.position + transform.forward * 500f);
                playerDummy.gameObject.SetActive(false);
            }
        }
    }
}
