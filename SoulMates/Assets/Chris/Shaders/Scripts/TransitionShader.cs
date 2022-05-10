using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionShader : MonoBehaviour
{
    public static int shaderProp = Shader.PropertyToID("_DissolvePosition");
  
    void Update()
    {
        Shader.SetGlobalVector("_DissolvePosition", transform.position);
    }
}
