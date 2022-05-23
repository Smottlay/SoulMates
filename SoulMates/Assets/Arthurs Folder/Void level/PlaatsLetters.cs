using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public RaycastHit hit;
    private void Update() {
        if(Input.GetButtonDown("Fire1")) {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1000)) {
                if(hit.collider.tag == "letter") {

                }
            }
        }
    }
}
