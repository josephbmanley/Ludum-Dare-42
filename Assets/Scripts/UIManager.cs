using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    Player_Manager player;
    public GameObject checkoutGUI;
    public Text itemCount;


	
	void Start () {
        //Get play component
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Manager>();
	}
	
	void Update () {
        //Update item GUI
        itemCount.text = player.itemCount.ToString();
	}
    public void CheckoutUI(int cashTotal, List<collected> itemCollected)
    {
        //Display total
        checkoutGUI.transform.Find("Total").GetComponent<Text>().text = "TOTAL DEBT: $" + cashTotal.ToString();
        //Generate receipt display
        string receipt = "";
        foreach(collected item in itemCollected)
        {
            receipt += item.name + "    x" + item.number.ToString() +"\n";
        }
        checkoutGUI.transform.Find("Receipt").GetComponent<Text>().text = receipt;
        //Display 'checkout'
        checkoutGUI.SetActive(true);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
