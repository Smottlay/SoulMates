using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaatsLetters : MonoBehaviour
{
    private GameObject trigger;
    private Vector3 rotat;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == this.gameObject.name) {
            Destroy(this.gameObject);
            Color newcolor = other.GetComponent<MeshRenderer>().material.color;
            
            newcolor.a = 255;
            other.GetComponent<MeshRenderer>().material.color = newcolor;
            /*
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<RotateAround>().enabled = false;
            this.GetComponent<BoxCollider>().isTrigger = true;
            this.transform.rotation = other.transform.rotation;
            this.transform.position = other.transform.position;
            trigger = other.gameObject;
            */
        }
    }
}
