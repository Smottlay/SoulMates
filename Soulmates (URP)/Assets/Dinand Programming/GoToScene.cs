using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public int newScene;

    public void SwithScene()
    {
        SceneManager.LoadScene(newScene);
    }
}
