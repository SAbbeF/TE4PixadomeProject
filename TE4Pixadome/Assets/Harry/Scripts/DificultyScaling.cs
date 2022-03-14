using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultyScaling : MonoBehaviour
{

    Stats stats;
    public float difficultyScalingTime = 300.0f;
    bool increaseDifficulty;

    //Denna stat ökare ökar med tid men man skulle kunna öka med waves istället

    void Start()
    {
        stats = GetComponent<Stats>();
        increaseDifficulty = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (increaseDifficulty)
        {

            stats.maxHealth = stats.maxHealth * 1.1f;
            stats.currentHealth = stats.currentHealth * 1.1f;
            stats.damage = stats.damage * 1.1f;
            stats.armor = stats.armor * 1.1f;
            stats.magicDefense = stats.magicDefense * 1.1f;

            increaseDifficulty = false;
            StartCoroutine(DifficultyScalingCooldown());
        }
    }

    IEnumerator DifficultyScalingCooldown()
    {

        yield return new WaitForSeconds(difficultyScalingTime);
        increaseDifficulty = true;

    }
}
