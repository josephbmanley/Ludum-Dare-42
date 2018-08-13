using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionDeathMachine : MonoBehaviour {

    Transform player;

    public float DestroyDistance;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update () {
		if(Mathf.Abs(player.transform.position.x - this.transform.position.x) > DestroyDistance)
        {
            Destroy(this.gameObject);
        }
	}
}
