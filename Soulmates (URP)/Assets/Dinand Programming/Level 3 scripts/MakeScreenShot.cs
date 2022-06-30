using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MakeScreenShot : MonoBehaviour
{
    public Camera[] cams;
    void Awake()
    {
        for (int i = 0; i < cams.Length; i++)
        {
            cams[i].gameObject.SetActive(false);
        }
    }
    public void TakeScreenShots()
    {
        RenderTexture activeRT = RenderTexture.active;
        string fileName = System.DateTime.Now.ToString().Replace(':', '-');
        for (int i = 0; i < cams.Length; i++)
        {
            cams[i].gameObject.SetActive(true);
            RenderTexture.active = cams[i].targetTexture;

            cams[i].Render();

            Texture2D image = new Texture2D(cams[i].targetTexture.width, cams[i].targetTexture.height);
            image.ReadPixels(new Rect(0, 0, cams[i].targetTexture.width, cams[i].targetTexture.height), 0, 0);
            image.Apply();
            RenderTexture.active = activeRT;

            byte[] bytes = image.EncodeToPNG();

            File.WriteAllBytes(Application.dataPath + "\\StreamingAssets\\ScreenShots\\" + fileName + "-" + i.ToString() + ".png", bytes);
            cams[i].gameObject.SetActive(false);
        }
    }
}
