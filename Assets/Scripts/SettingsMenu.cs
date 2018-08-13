using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider guiVolumeSlider;
    public Slider intercomVolumeSlider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("fullscreen"))
        {
            Screen.fullScreen = (PlayerPrefs.GetInt("fullscreen") == 1);
            fullscreenToggle.isOn = (PlayerPrefs.GetInt("fullscreen") == 1);
        }

        if(PlayerPrefs.HasKey("MasterVolume"))
        {
            SetMasterVolume(PlayerPrefs.GetFloat("MasterVolume"));
            masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        }
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
            musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        if (PlayerPrefs.HasKey("GUIVolume"))
        {
            SetGUIVolume(PlayerPrefs.GetFloat("GUIVolume"));
            guiVolumeSlider.value = PlayerPrefs.GetFloat("GUIVolume");
        }
        if (PlayerPrefs.HasKey("IntercomVolume"))
        {
            SetIntercomVolume(PlayerPrefs.GetFloat("IntercomVolume"));
            intercomVolumeSlider.value = PlayerPrefs.GetFloat("IntercomVolume");
        }
        if(PlayerPrefs.HasKey("ResWidth"))
        {
            if(PlayerPrefs.HasKey("ResHeight"))
            {
                try
                {
                    Screen.SetResolution(PlayerPrefs.GetInt("ResWidth"), PlayerPrefs.GetInt("ResHeight"), Screen.fullScreen);
                }
                catch
                {
                    Debug.LogError("Unable to set saved resolution!");
                }
            }
        }


        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        int currentRes = 0;
        List<string> options = new List<string>();
        for(int i = 0; i < resolutions.Length; i++)
        {
            options.Add(resolutions[i].width.ToString() + " x " + resolutions[i].height.ToString());
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentRes = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentRes;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("ResWidth", resolutions[resolutionIndex].width);
        PlayerPrefs.SetInt("ResHeight", resolutions[resolutionIndex].height);
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void SetGUIVolume(float volume)
    {
        audioMixer.SetFloat("GUIVolume", volume);
        PlayerPrefs.SetFloat("GUIVolume", volume);
    }
    public void SetIntercomVolume(float volume)
    {
        audioMixer.SetFloat("IntercomVolume", volume);
        PlayerPrefs.SetFloat("IntercomVolume", volume);
    }
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if (isFullscreen)
        {
            PlayerPrefs.SetInt("fullscreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("fullscreen", 0);
        }
    }
}
