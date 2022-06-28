using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveData : MonoBehaviour
{
    public SoulmateDesingData data;

    public string shape;
    public ChangeWallMaterial floorMaterial;
    public ChangeWallMaterial wallMaterial;
    public ChangeWallMaterial ceilingMaterial;

    public void Start()
    {

    }

    public void PrepareData()
    {
        data.shape = shape;
        data.floorTextureIndex = floorMaterial.currentMaterial;
        data.wallTextrureIndex = wallMaterial.currentMaterial;
        if (ceilingMaterial)
        {
            data.ceilingTextureIndex = ceilingMaterial.currentMaterial;
        }
        else
        {
            data.ceilingTextureIndex = 0;
        }
        data.windows.Clear();
        data.props.Clear();
        Prop[] props = FindObjectsOfType<Prop>();
        foreach (Prop prop in props)
        {
            if (prop.propType == PropType.Window)
            {
                data.windows.Add(new PropInfo(prop.propName, prop.transform.localPosition, prop.transform.rotation, prop.transform.localScale));
            }
            else
            {
                data.props.Add(new PropInfo(prop.propName, prop.transform.localPosition, prop.transform.rotation, prop.transform.localScale));
            }
        }
        SaveNewData();
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
