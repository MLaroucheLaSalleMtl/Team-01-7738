using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private Toggle audioToggle;
    [SerializeField] private Slider musicVolume;
    [SerializeField] private Slider sfxVolume;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Dropdown qualityLevel;

    void Start()
    {
        audioToggle.isOn = (PlayerPrefs.GetInt("audioMute") == 1) ?  true : false;
        musicVolume.value = PlayerPrefs.GetFloat("musicVolume", 0);
        audioMixer.SetFloat("musicVolume", musicVolume.value);
        sfxVolume.value = PlayerPrefs.GetFloat("sfxVolume", 0);
        audioMixer.SetFloat("sfxVolume", sfxVolume.value);

        SetQuality(PlayerPrefs.GetInt("qualityIndex", QualitySettings.GetQualityLevel()));
    }

    public void MuteAudio()
    {
        audioMixer.SetFloat("masterVolume", (audioToggle.isOn) ? 0.0f : -80.0f);
        PlayerPrefs.SetInt("audioMute", (audioToggle.isOn) ? 1 : 0);
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

        qualityLevel.value = qualityIndex;
        qualityLevel.RefreshShownValue();
    }
}
