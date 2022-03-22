using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultyScaling : MonoBehaviour
{
    //behöver göra en allmän tid scale strength after that clock

    Stats stats;
    public float timeWhenDifficultyChanges = 300.0f;
    public float difficultyScaling;
    bool increaseDifficulty;
    static float globalTimer;

    public int timesDifficultyIncreased = 0;

    public bool increaseDifficultyByTime = true;
    public bool increaseDifficultyByLevel;


    void Start()
    {
        stats = GetComponent<Stats>();
        increaseDifficulty = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (increaseDifficultyByTime)
        {
            globalTimer = globalTimer * Time.deltaTime;

            if (globalTimer / timeWhenDifficultyChanges > timesDifficultyIncreased)
            {

                IncreaseDifficulty(1.1f);

                timeWhenDifficultyChanges = timeWhenDifficultyChanges + 300;

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

        timesDifficultyIncreased++;

    }

}
