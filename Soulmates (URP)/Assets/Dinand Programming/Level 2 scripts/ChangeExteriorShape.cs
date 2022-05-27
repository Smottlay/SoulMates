using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeExteriorShape : MonoBehaviour
{
    public GameObject[] shapes;
    int currentShape;
    GameObject activeShape;
    public Transform shapePos;
    public void NextShape()
    {
        currentShape++;
        if (currentShape == shapes.Length)
        {
            currentShape = 0;
        }
        LoadShape();
    }
    public void PreviousShape()
    {
        if (currentShape == 0)
        {
            currentShape = shapes.Length;
        }
        currentShape--;
        LoadShape();
    }
    void LoadShape()
    {
        Destroy(activeShape);
        activeShape = Instantiate(shapes[currentShape], shapePos.position, shapePos.rotation, shapePos);
    }
}
