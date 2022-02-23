using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private string playerName;
    private float playerHealth;
    public string testString;

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }
    public float PlayerHealth
    {
        get { return playerHealth; }
        set { playerHealth = value; }
    }

    public PlayerData(string playerName, float playerHealth, string test)
    {
        PlayerName = playerName;
        PlayerHealth = playerHealth;
        this.testString = test;
    }

    public override string ToString()
    {
        return playerName + "has" + playerHealth + " . Also " + testString;
    }
}