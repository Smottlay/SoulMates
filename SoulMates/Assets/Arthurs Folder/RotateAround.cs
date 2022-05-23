using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject target;
    public float leftOrRight;
    public float upOrDown;
    private void Start() {
        leftOrRight = Random.Range(1, 3);
        upOrDown = Random.Range(1, 3);
    }
    void Update() {
        
        if (upOrDown <= 1.5f) {
            transform.RotateAround(target.transform.position, Vector3.up, Random.Range(2, 30) * Time.deltaTime);
        } else {
            transform.RotateAround(target.transform.position, Vector3.down, Random.Range(2, 30) * Time.deltaTime);
        }
        
        Debug.Log(leftOrRight);
        Debug.Log(upOrDown);
        if (leftOrRight <= 1.5f) {
            transform.RotateAround(target.transform.position, Vector3.left, Random.Range(2, 30) * Time.deltaTime);
        } else {
            transform.RotateAround(target.transform.position, Vector3.right, Random.Range(2, 30) * Time.deltaTime);
        }
    }
}
