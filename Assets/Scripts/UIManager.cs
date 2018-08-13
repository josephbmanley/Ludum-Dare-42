using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    Player_Manager player;
    public GameObject checkoutGUI;
    public Text itemCount;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Manager>();
	}
	
	// Update is called once per frame
	void Update () {
        itemCount.text = player.itemCount.ToString();
	}
    public void CheckoutUI(int cashTotal, List<collected> itemCollected)
    {
        checkoutGUI.transform.Find("Total").GetComponent<Text>().text = "TOTAL DEBT: $" + cashTotal.ToString();
        string receipt = "";
        foreach(collected item in itemCollected)
        {
            receipt += item.name + "    x" + item.number.ToString() +"\n";
        }
        checkoutGUI.transform.Find("Receipt").GetComponent<Text>().text = receipt;
        checkoutGUI.SetActive(true);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
