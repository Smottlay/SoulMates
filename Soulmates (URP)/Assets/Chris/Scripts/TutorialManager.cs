using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Unity.XR.OpenVR;

public class TutorialManager : MonoBehaviour
{
    public float welcomeTimer;
    public GameObject[] panels;
    public Material[] rightHighlightShader;
    public Material[] leftHighlightShader;
    public GameObject tutorialObjects;

    public CheckForLetter checkForLetter;
    public PlaatsLetters plaats;

    private RaycastHit hit;
    private bool timerBool;
    private bool confirmDissolve;
    private bool holding;
    

    private void Awake()
    {
        timerBool = true;
        tutorialObjects.transform.parent = this.gameObject.transform;
        holding = checkForLetter.GetComponent<CheckForLetter>().isHoldingLetter;
        confirmDissolve = plaats.GetComponent<PlaatsLetters>().dissolved;

        panels[2].GetComponent<UILerp>().enabled = false;
        panels[3].GetComponent<UILerp>().enabled = false;
    }
    private void Update()
    { 
        WelcomeTutorial();
        HeadTutorial();
        GrabTutorial();
    }

    private void WelcomeTutorial()
    {
        if (timerBool)
        {
            welcomeTimer -= Time.deltaTime;

            if (welcomeTimer < 0)
            {
                panels[0].SetActive(false);
                panels[1].SetActive(true);
                timerBool = false;

                tutorialObjects.transform.parent = null;
            }
        }
    }

    private void HeadTutorial()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.CompareTag("HeadCheck"))
            {
                panels[1].SetActive(false);
                panels[2].SetActive(true);
                tutorialObjects.gameObject.SetActive(false);
                Debug.Log("destroyed");
            }
        }
    }

    private void GrabTutorial()
    {
        
        if (!holding & !confirmDissolve)
        {
            panels[2].SetActive(true);
            panels[3].SetActive(false);
            rightHighlightShader[1].SetInt("_ToggleShader", 1);
            leftHighlightShader[1].SetInt("_ToggleShader", 1);
        }
        else if (holding & !confirmDissolve)
        {
            panels[2].SetActive(false);
            panels[3].SetActive(true);
            rightHighlightShader[1].SetInt("_ToggleShader", 0);
            leftHighlightShader[1].SetInt("_ToggleShader", 0);
        }

        if (confirmDissolve)
        {
            rightHighlightShader[1].SetInt("_ToggleShader", 0);
            leftHighlightShader[1].SetInt("_ToggleShader", 0);
            panels[2].SetActive(false);
            panels[3].SetActive(false);

            panels[4].SetActive(true);
        }
    }

    private void TeleportationTutorial(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            panels[4].SetActive(false);
        }
        else if (callbackContext.canceled)
        {
            panels[4].SetActive(true);
        }
    }
}
