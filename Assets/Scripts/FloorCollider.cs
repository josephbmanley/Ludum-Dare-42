using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour {

    Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
	}
}
