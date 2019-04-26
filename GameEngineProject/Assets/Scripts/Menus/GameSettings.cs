using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameSettings : MonoBehaviour
{
    private Resolution[] resolutions;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Toggle toggleAudio;
    [SerializeField] private Toggle toggleFullScreen;
    [SerializeField] private Slider musicVolume;
    [SerializeField] private Slider sfxVolume;
    [SerializeField] private Dropdown dropdownQualityLevel;
    [SerializeField] private Dropdown dropdownResolution;

    void Start()
    {
        toggleAudio.isOn = (PlayerPrefs.GetInt("audioMute") == 1) ? true : false;
        toggleFullScreen.isOn = (PlayerPrefs.GetInt("fullscreen") == 1) ? true : false;
        musicVolume.value = PlayerPrefs.GetFloat("musicVolume", 0);
        audioMixer.SetFloat("musicVolume", musicVolume.value);
        sfxVolume.value = PlayerPrefs.GetFloat("sfxVolume", 0);
        audioMixer.SetFloat("sfxVolume", sfxVolume.value);

        SetQuality(PlayerPrefs.GetInt("qualityIndex", QualitySettings.GetQualityLevel()));

        GetResolutions();
    }

    public void MuteAudio()
    {
        audioMixer.SetFloat("masterVolume", (toggleAudio.isOn) ? 0.0f : -80.0f);
        PlayerPrefs.SetInt("audioMute", (toggleAudio.isOn) ? 1 : 0);
    }

    public void SetVolumeMusic()
    {
        audioMixer.SetFloat("musicVolume", musicVolume.value);
        PlayerPrefs.SetFloat("musicVolume", musicVolume.value);
    }

    public void SetVolumeSFX()
    {
        audioMixer.SetFloat("sfxVolume", sfxVolume.value);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume.value);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityIndex", qualityIndex);

        dropdownQualityLevel.value = qualityIndex;
        dropdownQualityLevel.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolutionIndex", resolutionIndex);
    }

    public void FullScreen()
    {
        Screen.fullScreen = toggleFullScreen.isOn;
        PlayerPrefs.SetInt("fullscreen", (toggleFullScreen.isOn) ? 1 : 0);
    }

    void GetResolutions()
    {
        resolutions = Screen.resolutions;

        dropdownResolution.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        //int currentResolutionIndex = PlayerPrefs.GetInt("resolutionIndex", 0);

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        dropdownResolution.AddOptions(options);
        dropdownResolution.value = PlayerPrefs.GetInt("resolutionIndex", currentResolutionIndex);
        dropdownResolution.RefreshShownValue();
    }
}
