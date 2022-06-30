using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlaatsLetters : MonoBehaviour
{
    public GameObject lettersWithShader;
    public GameObject letters;
    public GameObject[] bigLetters;
    public Animator bigLettersAnim;
    public Animator disolveAnimation;
    public Renderer disolveShader;
    public bool dissolved;
    public static int lettersplaced;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == this.gameObject.name) {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<RotateAround>().enabled = false;
            Color newcolor = other.GetComponent<MeshRenderer>().material.color;
            newcolor.a = 255;
            other.GetComponent<MeshRenderer>().material.color = newcolor;
            lettersplaced++;
            if (lettersplaced == 8)
            {
                StartCoroutine(AnimationTime());
            }
        }
    }
    IEnumerator AnimationTime() {
        GetComponent<MeshRenderer>().enabled = false;
        lettersWithShader.SetActive(true);
        disolveAnimation.SetTrigger("Dissolve");
        yield return new WaitForSeconds(1);
        letters.SetActive(false);
        dissolved = true;
        yield return new WaitForSeconds(1);
        for (int i = 0; i < bigLetters.Length; i++)
        {
            bigLetters[i].SetActive(true);
            bigLetters[i].GetComponent<Animator>().SetTrigger("UnDissolve");

        }
        Debug.Log("Dit runned");
        gameObject.SetActive(false);
    }
}
