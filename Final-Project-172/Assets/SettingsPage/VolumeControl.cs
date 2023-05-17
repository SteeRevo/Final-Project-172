using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public TextMeshProUGUI volumeTextUI;
    // [SerializeField] Text volumeTextUI;

    public void VolumeSlider(float volume) {
        volumeTextUI.text = volume.ToString("0.0");
    }

    void Start() {
        if (!PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        } else {
            Load();
        }
    }

    void Update() {
        volumeTextUI.text = volumeSlider.value.ToString("0.0");
    }

    public void ChangeVolume() {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    public void Save() {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    private void Load() {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
}
