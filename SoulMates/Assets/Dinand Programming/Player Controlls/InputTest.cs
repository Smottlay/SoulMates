using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    public void A(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            print("A pressed");
        }
        else if (callbackContext.canceled)
        {
            print("A released");
        }
    }
    public void B(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            print("B pressed");
        }
        else if (callbackContext.canceled)
        {
            print("B released");
        }
    }
    public void X(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            print("X pressed");
        }
        else if (callbackContext.canceled)
        {
            print("X released");
        }
    }
    public void Y(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            print("Y pressed");
        }
        else if (callbackContext.canceled)
        {
            print("Y released");
        }
    }
    public void LT(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            print("Left Trigger pressed");
        }
        else if (callbackContext.canceled)
        {
            print("Lift Trigger released");
        }
    }
    public void LG(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            print("Left Grip pressed");
        }
        else if (callbackContext.canceled)
        {
            print("Left Grip released");
        }
    }
    public void RT(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            print("Right Trigger pressed");
        }
        else if (callbackContext.canceled)
        {
            print("Right Trigger released");
        }
    }
    public void RG(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            print("Right Grip pressed");
        }
        else if (callbackContext.canceled)
        {
            print("Right Grip released");
        }
    }
    public void LS(InputAction.CallbackContext callbackContext)
    {
        Vector2 vector2 = callbackContext.ReadValue<Vector2>();
        print("Left: " + vector2.x + " " + vector2.y);
    }
    public void RS(InputAction.CallbackContext callbackContext)
    {
        Vector2 vector2 = callbackContext.ReadValue<Vector2>();
        print("Right: " + vector2.x + " " + vector2.y);
    }
}
