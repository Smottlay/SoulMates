using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public int propIndex;
    public PropType propType;
    public LayerMask mask;
    public Vector3 rot;
}

public enum PropType
{
    Window,
    Decoration,
    Furniture
}