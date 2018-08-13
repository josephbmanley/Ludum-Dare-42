using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathVoid : MonoBehaviour {
    public float deathSpeed; //Rate at which player needs to run for his life.
    public float delay = 5f;

	
	// Update is called once per frame
	void Update () {
        if (delay < 0)
        {
            transform.position += new Vector3(Time.deltaTime * deathSpeed, 0, 0);
        }
        if(delay >= 0)
        {
            delay -= Time.deltaTime;
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player died");
            GameObject.FindObjectOfType<UIManager>().LoadGameOver();
        }
    }
}
