using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public float welcomeTimer;
    public PlaatsLetters plaatletters;
    public GameObject[] panels;
    public Material[] rightHighlightShader;
    public Material[] leftHighlightShader;

    private RaycastHit hit;
    private bool timerBool;
    private bool toggleShaderGrab;
    private bool toggleTeleportShader;
    private bool dissolvedConfirm;
    public GameObject tutorialObjects;

    private void Awake()
    {
        dissolvedConfirm = plaatletters.GetComponent<PlaatsLetters>().dissolved;
        timerBool = true;
        tutorialObjects.transform.parent = this.gameObject.transform;
    }
    private void Update()
    { 
        WelcomeTutorial();
        HeadTutorial();
        GrabTutorial();

       /*
       PlacementTutorial();
       TeleportationTutorial();
       */
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
                toggleShaderGrab = true;
            }
        }
    }

    private void GrabTutorial()
    {
        if (toggleShaderGrab)
        {
            rightHighlightShader[1].SetInt("_ToggleShader", 1);
        }
        else if (!toggleShaderGrab)
        {
            rightHighlightShader[1].SetInt("_ToggleShader", 0);
        }
    }

    private void PlacementTutorial()
    {
        panels[3].SetActive(false);
        panels[4].SetActive(true);
    }

    private void TeleportationTutorial()
    {
        if (dissolvedConfirm)
        {
            toggleTeleportShader = true;
            if (toggleTeleportShader)
            {
                rightHighlightShader[0].SetInt("_ToggleShader", 1);
                leftHighlightShader[0].SetInt("_ToggleShader", 1);
            }
            else if (!toggleTeleportShader)
            {
                rightHighlightShader[0].SetInt("_ToggleShader", 0);
                leftHighlightShader[0].SetInt("_ToggleShader", 0);
            }
        } 
    }
}
