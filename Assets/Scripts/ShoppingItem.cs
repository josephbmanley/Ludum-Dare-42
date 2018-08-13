using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingItem : MonoBehaviour {
    public float value = 1;
    const float rotateSpeed = 30f;
    bool pickedUp = false;
    public bool rotates = true;
    Collider2D collidercomp;
    Player_Manager player;

	// Use this for initialization
	void Start () {
        if (this.gameObject.GetComponent<Collider2D>() == null)
        {
            this.gameObject.AddComponent<BoxCollider2D>();
        }
        collidercomp = this.GetComponent<Collider2D>();
        collidercomp.isTrigger = true;
        player = GameObject.FindObjectOfType<Player_Manager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (rotates)
        {
            transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" & pickedUp == false)
        {
            pickedUp = true;
            player.itemCount++;
            player.totalValue += value;

            bool copyNotFound = true;
            for(int i = 0; i < player.itemsCollected.Count; i++)
            {
                if(player.itemsCollected[i].name == this.name)
                {
                    copyNotFound = false;
                    player.itemsCollected[i].number++;
                    break;
                }
            }
            if(copyNotFound)
            {
                collected item = new collected();
                item.name = this.name;
                item.number = 1;
                player.itemsCollected.Add(item);
            }

            Destroy(this.gameObject);
        }
    }

    public void SetGlobalScale()
    {
        Vector3 globalScale = new Vector3(0.25f, 0.25f, 0.25f);
        transform.localScale = Vector3.one;
        transform.localScale = new Vector3(globalScale.x / transform.lossyScale.x, globalScale.y / transform.lossyScale.y, globalScale.z / transform.lossyScale.z);
    }
}
