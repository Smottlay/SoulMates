using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] panels;
    public float welcomeTimer;
   
    private RaycastHit hit;
    private bool timerBool;
    public GameObject tutorialObjects;

    private void Awake()
    {
        timerBool = true;
        tutorialObjects.transform.parent = this.gameObject.transform;
    }
    private void Update()
    { 
        WelcomeTutorial();
        HeadTutorial();
        /*
        GrabTutorial();
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
            }
        }
    }

    private void GrabTutorial()
    {
        panels[2].SetActive(false);
        panels[3].SetActive(true);
    }

    private void PlacementTutorial()
    {
        panels[3].SetActive(false);
        panels[4].SetActive(true);
    }

    private void TeleportationTutorial()
    {
        panels[4].SetActive(false);
        panels[5].SetActive(true);
    }
}
