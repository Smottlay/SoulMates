using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWallMaterial : MonoBehaviour
{
    public Material wallMaterial;
    public static Material[] materials;
    int currentMaterial;

    private void Start()
    {
        currentMaterial = 0;
        wallMaterial = materials[0];
    }
    public void NextMat()
    {
        currentMaterial++;
        if (currentMaterial == materials.Length)
        {
            currentMaterial = 0;
        }
        wallMaterial = materials[currentMaterial];
    }
    public void PrevMat()
    {
        if (currentMaterial == 0)
        {
            currentMaterial = materials.Length;
        }
        currentMaterial--;
        wallMaterial = materials[currentMaterial];
    }

    public void SelectMat(int mat)
    {
        currentMaterial = mat;
        wallMaterial = materials[currentMaterial];
    }
}
