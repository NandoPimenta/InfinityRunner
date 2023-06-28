using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public SOInt planets;


    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        planets.value = 0;

    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
    }

    public void AddPlanets(int amount = 1)
    {
        planets.value += amount;
    }
}
