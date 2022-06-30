using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlaatsLetters : MonoBehaviour
{
    public GameObject lettersWithShader;
    public GameObject letters;
    public GameObject bigLetters;
    public Animator disolveAnimation;
    public Renderer disolveShader;
    float dissolve;
    public bool skipLetters;
    public bool dissolved;
    /*
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == this.gameObject.name || skipLetters == true) {
            Color newcolor = other.GetComponent<MeshRenderer>().material.color;
            newcolor.a = 255;
            other.GetComponent<MeshRenderer>().material.color = newcolor;
            Destroy(this.gameObject);
            if (this.transform.parent.childCount <= 1 || skipLetters == true) {
                Debug.Log("Laatste letter is geplaatst");
                LettersWithShader.SetActive(true);
                Letters.SetActive(false);
                dissolve = 5f;
                for (int i = 0; i < 10; i++) {

                    //disolveShader.material.SetFloat("DissolveRange", dissolve);
                    Debug.Log(dissolve);
                    dissolve -= 1;
                }
            }
        }
    }
    */
    public void Update() {
        if (skipLetters == true) {
            //Color newcolor = other.GetComponent<MeshRenderer>().material.color;
            //newcolor.a = 255;
            //other.GetComponent<MeshRenderer>().material.color = newcolor;
            Destroy(this.gameObject);
            if (this.transform.parent.childCount <= 1 || skipLetters == true) {
                Debug.Log("Laatste letter is geplaatst");
                lettersWithShader.SetActive(true);
                letters.SetActive(false);
                disolveAnimation.SetTrigger("Dissolve");
                Debug.Log("destroy letters");
                Debug.Log("Spawn de nieuwe letters");
                dissolved = true;
                //StartCoroutine(Dissolve());
                Debug.Log("Done");
            }
        }
    }
}
