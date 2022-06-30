using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.XR.Interaction.Toolkit;

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
    bool b;
    public Collider _collider;
    public XRController xR1;
    public XRController xR2;

    private void Awake()
    {
        _collider.enabled = false;
        lettersplaced = 0;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == this.gameObject.name && b == false) {
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
            b = true;
        }
    }
    IEnumerator AnimationTime() {
        xR1.selectUsage = InputHelpers.Button.Grip;
        xR2.selectUsage = InputHelpers.Button.Grip;
        GetComponent<MeshRenderer>().enabled = false;
        lettersWithShader.SetActive(true);
        Animator[] anims = lettersWithShader.GetComponentsInChildren<Animator>();
        for (int i = 0; i < anims.Length; i++)
        {
            anims[i].SetTrigger("Dissolve");
        }
        yield return new WaitForSeconds(1);
        letters.SetActive(false);
        dissolved = true;
        yield return new WaitForSeconds(1);
        for (int i = 0; i < bigLetters.Length; i++)
        {
            bigLetters[i].SetActive(true);
            bigLetters[i].GetComponent<Animator>().SetTrigger("UnDissolve");

        }
        _collider.enabled = true;
        Debug.Log("Dit runned");
        gameObject.SetActive(false);
    }
}
