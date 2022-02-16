using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manabar : MonoBehaviour
{
    public Slider slider;
    public bool isManaUseable;
    //s�tter maxv�rdet slidern kan  har och hur l�ng den nuvarande �r
    public void SetMaxMana(float mana)
    {
        slider.maxValue = mana;
        slider.value = mana;
    }

    //s�tter det nuvaranade v�rdet till slidern 
    //anv�nds s� att slidern faktisk �ndrar storlek
    public void SetManaValue(float mana)
    {
        slider.value = mana;
    }

    //should be the code that check if u are able to use mana
    public float UseMana(float amountMana, float manaUsed)
    {
        if (amountMana < manaUsed)
        {
            isManaUseable = false;
            return amountMana;
        }

        amountMana = amountMana - manaUsed;
        isManaUseable = true;

        return amountMana;
    }

    //ska Regena mana och skicka tillbaka det nya v�rdet
    public float ManaRegen(float currentMana, float maxMana, float manaRegenAmount)
    {
        if (currentMana < maxMana)
        {
            currentMana += manaRegenAmount * Time.deltaTime;
        }
        return currentMana;
    }
}
