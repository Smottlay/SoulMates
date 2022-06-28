using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public string propName;
    public PropType propType;
    public LayerMask mask;
    public Vector3 rot;
    public Transform selection;
    bool align = false;
    Transform lookAt;

    private void Start()
    {
        lookAt = FindObjectOfType<SwitchOnMenu>().GetComponentInChildren<Camera>().transform;
    }
    public void OnSelectProp()
    {
        selection.gameObject.SetActive(true);
        align = true;
    }
    public void OnDeselectProp()
    {
        selection.gameObject.SetActive(false);
        align = false;
    }
    private void FixedUpdate()
    {
        if (align)
        {
            selection.LookAt(lookAt);
        }
    }
}

public enum PropType
{
    Window,
    Decoration,
    Furniture
}