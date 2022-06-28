using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Desing Data", menuName = "ScriptableObjects/Data/Design Data")]
public class SoulmateDesingData : ScriptableObject
{
    public string shape;
    public int floorTextureIndex;
    public int wallTextrureIndex;
    public int ceilingTextureIndex;
    public List<PropInfo> windows = new List<PropInfo>();
    public List<PropInfo> props = new List<PropInfo>();
}

[System.Serializable]
public class PropInfo
{
    public string propName;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public PropInfo()
    {

    }
    public PropInfo(PropInfo newProp)
    {
        this.propName = newProp.propName;
        this.position = newProp.position;
        this.rotation = newProp.rotation;
        this.scale = newProp.scale;
    }
    public PropInfo(string name, Vector3 pos, Quaternion rot, Vector3 scl)
    {
        this.propName = name;
        this.position = pos;
        this.rotation = rot;
        this.scale = scl;
    }
}