using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveData : MonoBehaviour
{
    public SoulmateDesingData data;

    public void Start()
    {

    }

    public void SaveNewData()
    {
        string dateTime = System.DateTime.Now.ToString().Replace(':', '-');
        Debug.Log(dateTime);
        XmlSerializer serializer = new XmlSerializer(typeof(SoulmateDesingData));
        var encoding = System.Text.Encoding.GetEncoding("UTF-8");
        StreamWriter stream = new StreamWriter(Application.dataPath + "\\StreamingAssets\\SaveData\\" + dateTime + ".xml", false, encoding);
        serializer.Serialize(stream, data);
        stream.Close();
    }
}
