using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public int deathCount;
    public Vector3 playerPosition;
    public StatsData statsData;
    public LevelSystem levelSystem;
    public InventoryData inventoryData;
    public float fireTime =0;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData()
    {
        playerPosition = Vector3.zero;
        statsData = new StatsData();
        inventoryData = new InventoryData();
        levelSystem = new LevelSystem();
        fireTime = 0;
    }

    public int GetPercentageComplete()
    {
        // viet code tinh phan tram tien trinh choi o day

        return 100;
    }
   
}