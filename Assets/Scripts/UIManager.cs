using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    Player_Manager player;
    Fader fader;
    public GameObject checkoutGUI;
    public Text itemCount;

    IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(fader.fadeTime * 4);
        SceneManager.LoadScene(0);
    }
    IEnumerator GoToGameOver()
    {
        yield return new WaitForSeconds(fader.fadeTime * 4);
        SceneManager.LoadScene(2);
    }

    void Start () {
        //Get play component
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Manager>();
        //Get the fader
        fader = FindObjectOfType<Fader>();
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
        fader.FadeIn = false;
        StartCoroutine(GoToMainMenu());
    }
    public void LoadGameOver()
    {
        fader.FadeIn = false;
        fader.fadeTime = 0.25f;
        StartCoroutine(GoToGameOver());
    }
}
