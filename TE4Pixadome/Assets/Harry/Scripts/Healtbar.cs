using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healtbar : MonoBehaviour
{
    public Slider slider;

    //s�tter maxv�rdet slidern kan  har och hur l�ng den nuvarande �r
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //s�tter det nuvaranade v�rdet till slidern 
    //anv�nds s� att slidern faktisk �ndrar storlek
    public void SetHealthValue(float health)
    {
        slider.value = health;
    }
}
