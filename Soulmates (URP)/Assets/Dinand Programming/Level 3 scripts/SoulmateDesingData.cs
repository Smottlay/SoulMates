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
    public int propIndex;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public PropInfo()
    {

    }
    public PropInfo(PropInfo newProp)
    {
        this.propIndex = newProp.propIndex;
        this.position = newProp.position;
        this.rotation = newProp.rotation;
        this.scale = newProp.scale;
    }
    public PropInfo(int index, Vector3 pos, Quaternion rot, Vector3 scl)
    {
        this.propIndex = index;
        this.position = pos;
        this.rotation = rot;
        this.scale = scl;
    }
}