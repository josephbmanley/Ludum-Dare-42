using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRandomChild : MonoBehaviour {
    public List<GameObject> generatables;
    public int noChance = 8;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < noChance; i++)
        {
            generatables.Add(null);
        }
        GameObject create = generatables[Random.Range(0, generatables.Count)];
        if(create != null)
        {
            Instantiate(create).transform.SetParent(this.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
