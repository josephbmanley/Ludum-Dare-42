using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    Fader fader;
    private void Start()
    {
        fader = FindObjectOfType<Fader>();
    }

    IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(fader.fadeTime * 4);
        SceneManager.LoadScene(0);
    }
    public void LoadMainMenu()
    {
        fader.FadeIn = false;
        StartCoroutine(GoToMainMenu());
    }

    IEnumerator GoToGame()
    {
        yield return new WaitForSeconds(fader.fadeTime * 4);
        SceneManager.LoadScene(1);
    }
    public void LoadGame()
    {
        fader.FadeIn = false;
        StartCoroutine(GoToGame());
    }
}
