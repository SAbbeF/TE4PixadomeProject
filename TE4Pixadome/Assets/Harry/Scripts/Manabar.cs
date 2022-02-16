using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manabar : MonoBehaviour
{
    public Slider slider;
    public bool isManaUseable;
    //sätter maxvärdet slidern kan  har och hur lång den nuvarande är
    public void SetMaxMana(float mana)
    {
        slider.maxValue = mana;
        slider.value = mana;
    }

    //sätter det nuvaranade värdet till slidern 
    //används så att slidern faktisk ändrar storlek
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

    //ska Regena mana och skicka tillbaka det nya värdet
    public float ManaRegen(float currentMana, float maxMana, float manaRegenAmount)
    {
        if (currentMana < maxMana)
        {
            currentMana += manaRegenAmount * Time.deltaTime;
        }
        return currentMana;
    }
}
