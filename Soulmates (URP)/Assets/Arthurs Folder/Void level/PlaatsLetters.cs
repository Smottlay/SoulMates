using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaatsLetters : MonoBehaviour
{
    private GameObject trigger;
    private Vector3 rotat;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag(this.gameObject.name)) {
            this.transform.position = other.transform.position;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.transform.rotation = other.transform.rotation;
            this.GetComponent<BoxCollider>().isTrigger = true;
            trigger = other.gameObject;
        }
    }
    public void PickUpLetter() {
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().rotation = new Quaternion(0, 90, 0, 0);
    }
    public void DropLetter() {
        // maak het zo dat als je hem los laat en hij zit niet op de juiste plek, dat hij dan weer terug gaat naar de orginele locatie en weer om je heen draait
        // zodat je hem weer opnieuw kan pakken:) veel succes mfer, beter ga je deze shit snel af maken anders krijg je izjem klap op je bek
        //this.GetComponent<RotateAround>().enabled = false;
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Rigidbody>().rotation = new Quaternion(0, 0, 0, 0);
    }
}
