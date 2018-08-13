using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct RegionData {
    public GameObject prefab;
    public float length;
    public string name;
    public string desc;
    public int spawnProbability;
    public List<GameObject> objectsInArea;
}
