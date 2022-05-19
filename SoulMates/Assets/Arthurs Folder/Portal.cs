using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform player;

    private bool playerIsOverLapping = false;

    void Update() {
        if (playerIsOverLapping) {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if (dotProduct < 0f) {
                Debug.Log("It Worky");
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            playerIsOverLapping = true;
        }
    }
}
