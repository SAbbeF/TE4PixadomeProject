using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsScript : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    public SettingsScript()
    {



    }
        
    public void SetVolume(float volume)
    {

        audioMixer.SetFloat("MasterVolume", volume);

    }

    public void SetGraphics(int dropDownIndex)
    {

        QualitySettings.SetQualityLevel(dropDownIndex);

    }

}
