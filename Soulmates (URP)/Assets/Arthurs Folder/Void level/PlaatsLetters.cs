using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlaatsLetters : MonoBehaviour
{
    public GameObject lettersWithShader;
    public GameObject letters;
    public GameObject bigLetters;
    public Animator bigLettersAnim;
    public Animator disolveAnimation;
    public Renderer disolveShader;
    public bool dissolved;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == this.gameObject.name) {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<RotateAround>().enabled = false;
            Color newcolor = other.GetComponent<MeshRenderer>().material.color;
            newcolor.a = 255;
            other.GetComponent<MeshRenderer>().material.color = newcolor;
            if (this.transform.parent.childCount <= 1) {
                StartCoroutine(AnimationTime());
            }
        }
    }
    IEnumerator AnimationTime() {
        lettersWithShader.SetActive(true);
        disolveAnimation.SetTrigger("Dissolve");
        yield return new WaitForSeconds(1);
        letters.SetActive(false);
        dissolved = true;
        yield return new WaitForSeconds(1);
        bigLetters.SetActive(true);
        bigLettersAnim.SetTrigger("UnDissolve");
        Debug.Log("Dit runned");
    }
}
