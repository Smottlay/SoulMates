using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthMaskScript : MonoBehaviour
{
    public GameObject[] maskedOBJ;
    void Start()
    {
        for (int i = 0; i < maskedOBJ.Length; i++)
        {
            maskedOBJ[i].GetComponent<MeshRenderer>().material.renderQueue = 3002;
        }
    }
}

