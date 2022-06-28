using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaatsLetters : MonoBehaviour
{
    public GameObject LettersWithShader;
    public GameObject Letters;
    public Renderer disolveShader;
    float dissolve;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == this.gameObject.name) {
            Color newcolor = other.GetComponent<MeshRenderer>().material.color;
            newcolor.a = 255;
            other.GetComponent<MeshRenderer>().material.color = newcolor;
            Destroy(this.gameObject);
            if (this.transform.parent.childCount <= 1) {
                Debug.Log("Laatste letter is geplaatst");
                LettersWithShader.SetActive(true);
                Letters.SetActive(false);
                dissolve = 5f;
                for (int i = 0; i < 10; i++) {
                    
                    disolveShader.material.SetFloat("DissolveRange", dissolve);
                }
            }
        }
    }
}
