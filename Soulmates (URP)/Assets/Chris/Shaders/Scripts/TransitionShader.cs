using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TransitionShader : MonoBehaviour
{
    public Material[] transMats;
    public bool toggleShader;
    public float growthSpeed;
    private float speed;

    public void Update()
    {
        Shader.SetGlobalVector("_DissolvePosition", transform.position);

        if (toggleShader)
        {
            foreach(Material mats in transMats)
            {
                speed += growthSpeed;
                Shader.SetGlobalFloat("_DissolveRange", speed);
            }
        }

    }
}
