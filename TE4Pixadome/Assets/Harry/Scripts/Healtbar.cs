using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healtbar : MonoBehaviour
{
    public Slider slider;

    //sätter maxvärdet slidern kan  har och hur lång den nuvarande är
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //sätter det nuvaranade värdet till slidern 
    //används så att slidern faktisk ändrar storlek
    public void SetHealthValue(float health)
    {
        slider.value = health;
    }
}
