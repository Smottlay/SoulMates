using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceProp : MonoBehaviour
{
    public GameObject prop;
    public MoveProp moveProp;
    public Transform newParent;

    public void PlaceNewProp()
    {
        moveProp.propInHand = Instantiate(prop, transform.parent.position, Quaternion.identity, newParent).GetComponent<Prop>();
        moveProp.propInHand.OnSelectProp();
    }
}
