using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaScript : MonoBehaviour
{

    public Slider slider;

    public float ManaRegeneration(float currentMana, float maxMana, float regenTickRate)
    {
        currentMana += regenTickRate * Time.fixedDeltaTime;

        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }

        return currentMana;

    }

    public float ManaSubtraction(float currentMana, float manaCost)
    {

        currentMana =- manaCost;

        return currentMana;

    }

    public void SetMaxMana(float mana)
    {
        slider.maxValue = mana;
        slider.value = mana;
    }

    public void SetManaValue(float mana)
    {
        slider.value = mana;
    }

}
