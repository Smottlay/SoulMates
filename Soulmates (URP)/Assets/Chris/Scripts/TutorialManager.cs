using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject[] turorialObject;
    public float welcomeTimer;
   
    private RaycastHit hit;
    private bool tutBool;
    private bool timerBool;

    private void Awake()
    {
        tutBool = false;
        timerBool = true;
    }
    private void Update()
    {
        TutorialObjects();
        WelcomeTutorial();
        HeadTutorial();
        GrabTutorial();
        PlacementTutorial();
        TeleportationTutorial();
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
                tutBool = true;
                timerBool = false;
            }
        }
    }

    private void HeadTutorial()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.CompareTag("HeadCheck"))
            {
                tutBool = false;
                panels[1].SetActive(false);
                panels[2].SetActive(true); 
            }
        }
    }

    private void GrabTutorial()
    {
        
    }

    private void PlacementTutorial()
    {

    }

    private void TeleportationTutorial()
    {

    }

    private void TutorialObjects()
    {
        if(tutBool)
        {
            foreach (GameObject tutOBJ in turorialObject)
            {
                tutOBJ.SetActive(true);
            }
        }
        else if (!tutBool)
        {
            foreach (GameObject tutOBJ in turorialObject)
            {
                tutOBJ.SetActive(false);
            }
        }
    }
}
