using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public void ExitGame()
    {
        Application.Quit();
        if (Application.isEditor)
        {
            Debug.LogWarning("Unable to exit game in editor!");
        }
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);

    }
    public void Settings()
    {
        transform.Find("Default").gameObject.SetActive(false);
        transform.Find("Settings").gameObject.SetActive(true);
    }
    public void Back()
    {
        PlayerPrefs.Save();
        transform.Find("Settings").gameObject.SetActive(false);
        transform.Find("Default").gameObject.SetActive(true);
    }
}
