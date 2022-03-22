using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultyScaling : MonoBehaviour
{
    //behöver göra en allmän tid scale strength after that clock

    Stats stats;
    public float difficultyScalingTime = 300.0f;
    public float difficultyScaling;
    bool increaseDifficulty;

    public bool increaseDifficultyByTime;
    public bool increaseDifficultyByLevel;

    //static int globalIncreases;
    //int ownIncreases;

    //Denna stat ökare ökar med tid men man skulle kunna öka med waves istället
    //skulle behöva en allmän timer för alla

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

        if (increaseDifficultyByLevel)
        {

        }
        else if (increaseDifficultyByTime)
        {

            if (increaseDifficulty)
            {

                IncreaseDifficulty(1.1f);

                increaseDifficulty = false;
                //ownIncreases++;
                StartCoroutine(DifficultyScalingCooldown());
            }

        }
    }


    public void IncreaseDifficulty(float statIncreaseMultiplier)
    {

        stats.maxHealth = stats.maxHealth * statIncreaseMultiplier;
        stats.currentHealth = stats.currentHealth * statIncreaseMultiplier;
        stats.damage = stats.damage * statIncreaseMultiplier;
        stats.armor = stats.armor * statIncreaseMultiplier;
        stats.magicDefense = stats.magicDefense * statIncreaseMultiplier;

    }

    IEnumerator DifficultyScalingCooldown()
    {

        yield return new WaitForSeconds(difficultyScalingTime);
        increaseDifficulty = true;
        //globalIncreases++;

    }
}
