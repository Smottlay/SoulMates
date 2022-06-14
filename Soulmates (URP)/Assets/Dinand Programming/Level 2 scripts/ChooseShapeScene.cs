using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChooseShapeScene : MonoBehaviour
{
    //public LayerMask mask;
    public void GoToShapeScene(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started && Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 5f))
        {
            if (hit.collider.GetComponent<ShapeID>())
            {
                SceneManager.LoadScene(hit.collider.GetComponent<ShapeID>().shapeSceneId);
            }
        }
    }
}
