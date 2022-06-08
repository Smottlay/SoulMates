using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaatsLetters : MonoBehaviour
{
    public GameObject trigger;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("S")) {
            this.transform.position = other.transform.position;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.transform.rotation = other.transform.rotation;
            this.GetComponent<BoxCollider>().isTrigger = true;
            trigger = other.gameObject;
        }
    }
    public void DropLetter() {
        this.GetComponent<RotateAround>().enabled = false;
    }
}
