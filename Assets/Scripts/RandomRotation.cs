using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {
    public float upRot = 1f;
    public float rightRot = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(transform.up * Time.deltaTime * upRot);
        transform.Rotate(transform.right* Time.deltaTime * rightRot);
    }
}
