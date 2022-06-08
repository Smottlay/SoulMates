using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILerp : MonoBehaviour
{
    public float offsetRadius;
    public float headDistance;
    public float imageHeight;

    public Camera mainCam;

    [Range(0, 1)]
    public float smoothFactor;

    private void Update()
    {
        Vector3 height = new Vector3(0, imageHeight / 100, 0);
        transform.position += height;

        transform.rotation = mainCam.transform.rotation;
        var camCenter = mainCam.transform.position + mainCam.transform.forward * headDistance;
        var currentPos = transform.position;

        var direction = currentPos - camCenter;
        var targetPosition = camCenter + direction.normalized * offsetRadius;

        transform.position = Vector3.Lerp(currentPos, targetPosition, smoothFactor);
    }
}
