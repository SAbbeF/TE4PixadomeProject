using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultyScaling : MonoBehaviour
{
    //beh�ver g�ra en allm�n tid scale strength after that clock

    Stats stats;
    public float difficultyScalingTime = 300.0f;
    public float difficultyScaling;
    bool increaseDifficulty;

    //static int globalIncreases;
    //int ownIncreases;

    //Denna stat �kare �kar med tid men man skulle kunna �ka med waves ist�llet
    //skulle beh�va en allm�n timer f�r alla

    void Start()
    {
        stats = GetComponent<Stats>();
        increaseDifficulty = true;
        //globalIncreases = 0;
        //ownIncreases = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (ownIncreases != globalIncreases && globalIncreases != 0)
        //{
        //    stats.maxHealth = stats.maxHealth * 1.1f;
        //    stats.currentHealth = stats.currentHealth * 1.1f;
        //    stats.damage = stats.damage * 1.1f;
        //    stats.armor = stats.armor * 1.1f;
        //    stats.magicDefense = stats.magicDefense * 1.1f;

        //    ownIncreases++;
        //}

        if (increaseDifficulty)
        {

            stats.maxHealth = stats.maxHealth * 1.1f;
            stats.currentHealth = stats.currentHealth * 1.1f;
            stats.damage = stats.damage * 1.1f;
            stats.armor = stats.armor * 1.1f;
            stats.magicDefense = stats.magicDefense * 1.1f;

            increaseDifficulty = false;
            //ownIncreases++;
            StartCoroutine(DifficultyScalingCooldown());
        }
    }

    IEnumerator DifficultyScalingCooldown()
    {

        yield return new WaitForSeconds(difficultyScalingTime);
        increaseDifficulty = true;
        //globalIncreases++;

    }
}