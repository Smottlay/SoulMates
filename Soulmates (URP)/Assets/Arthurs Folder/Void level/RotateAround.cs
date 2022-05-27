using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    Quaternion rotation;
    public GameObject target;
    public float leftOrRight;
    private void Start() {
        leftOrRight = Random.Range(1, 3);
    }
    void Update() {
        
        if (leftOrRight <= 1.5f) {
            transform.RotateAround(target.transform.position, Vector3.up, Random.Range(30, 60) * Time.deltaTime);
        } else {
            transform.RotateAround(target.transform.position, Vector3.down, Random.Range(30, 60) * Time.deltaTime);
        }
        Debug.Log(leftOrRight);

    }

    void Awake() {
        rotation = transform.rotation;
    }
    void LateUpdate() {
        transform.rotation = rotation;
    }
}
