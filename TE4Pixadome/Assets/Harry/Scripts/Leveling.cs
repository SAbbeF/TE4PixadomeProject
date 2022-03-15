using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leveling : MonoBehaviour
{

    //skada behöver en ägare som behövs checkas av när fiender dör. att ifall man dog så ser man vem som gjorde skadan
    [Space(10)]

    public float currentXp;
    public float xpNeededToLevel;


    [Header("Increasing Stats")]
    [Tooltip("current stat value multiplies with writen value when leveling up")]
    public float maxHealthIncrease = 1;

    [Tooltip("current stat value multiplies with writen value when leveling up")]
    public float maxManaIncrease = 1;

    [Tooltip("current stat value multiplies with writen value when leveling up")]
    public float damageIncrease = 1;

    [Tooltip("current stat value multiplies with writen value when leveling up")]
    public float armourIncrease = 1;

    [Tooltip("current stat value multiplies with writen value when leveling up")]
    public float magicDefenseIncrease = 1;

    Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentXp >= xpNeededToLevel)
        {
            stats.maxHealth = stats.maxHealth * maxHealthIncrease;
            stats.currentHealth = stats.currentHealth * maxHealthIncrease;

            stats.maxMana = stats.maxMana * maxManaIncrease;
            stats.currentMana = stats.currentMana * maxManaIncrease;

            stats.damage = stats.damage * damageIncrease;

            stats.armor = stats.armor * armourIncrease;
            stats.magicDefense = stats.magicDefense * magicDefenseIncrease;

            currentXp = currentXp - xpNeededToLevel;
            xpNeededToLevel = xpNeededToLevel * 1.2f;
        }
    }
}
