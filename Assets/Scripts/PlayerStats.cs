using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money; //static variables will cary on from one scene to another.
    public static int Lives; //static variables will cary on from one scene to another.
    public int startMoney = 400;
    public int startLives = 20;
    public static PlayerStats playerStats;
    public static int roundsSurvived;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        roundsSurvived = 0;
    }

    private void Awake()
    {
        if(playerStats == null)
        {
            playerStats = this;
        }
        else { return; }
    }

    public void ReduceHP(int amount)
    {
        Lives -= amount;
    }
}
