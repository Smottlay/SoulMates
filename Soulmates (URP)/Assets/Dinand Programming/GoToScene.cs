using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToScene : MonoBehaviour
{
    public int newScene;
    public GameObject[] panels;

    public void SwithScene()
    {
        SceneManager.LoadScene(newScene);
    }

    public void SwitchPanel()
    {
        panels[0].SetActive(true);
        panels[1].SetActive(false);
    }
}
