using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Camera_Manager : MonoBehaviour {

    Transform player;
    float xOffset = 0f;
    float yOffset = 0f;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        xOffset = this.transform.position.x;
        yOffset = this.transform.position.y;
	}
	
	void Update () {
        this.transform.position = new Vector3(player.position.x + xOffset, player.position.y + yOffset, this.transform.position.z);
	}
}
