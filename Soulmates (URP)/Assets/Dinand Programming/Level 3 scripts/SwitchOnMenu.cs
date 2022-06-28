using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchOnMenu : MonoBehaviour
{
    public GameObject menu;
    public void SwitchMenu(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started && menu.activeInHierarchy == true)
        {
            menu.SetActive(false);
        }
        else if (callbackContext.started && menu.activeInHierarchy == false)
        {
            menu.SetActive(true);
        }
    }
}
