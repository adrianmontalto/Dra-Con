using UnityEngine;
using System.Collections;

public class BuildMenu : MonoBehaviour
{
    [HideInInspector]
    public int minerNum = 0;
    [HideInInspector]
    public int advanceMinerNum = 0;
    [HideInInspector]
    public int dragonWarriorNum = 0;
    [HideInInspector]
    public int dragonTankNum = 0;
    [HideInInspector]
    public int dragonNum = 0;
    [HideInInspector]
    public int barracksNum = 0;
    [HideInInspector]
    public int dragonPortalsNum = 0;
    [HideInInspector]
    public int antiAirTurretNum = 0;
    [HideInInspector]
    public int minesNum = 0;
    [HideInInspector]
    public int wallNum = 0;
   
    public Player player;
    public Enemy enemy;
    public GameObject initImage;
    public GameObject previousImage;
    public GameItem barracks;
    public GameItem dragonPortal;
    public GameItem antiAirTurret;
    public GameItem mines;
    public GameItem wall;
    public GameItem miner;
    public GameItem advanceMiner;
    public GameItem dragonWarrior;
    public GameItem dragonTank;
    public GameItem dragon;

    // Use this for initialization
    void Start ()
    {
        previousImage = initImage;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void AddPlayerBuildings()
    {
        for(int i = 0; i < barracksNum; ++i)
        {
            player.playerUnits.Add(new GameItem(barracks.objectName,barracks.goldCost,barracks.shardCost,barracks.health,barracks.attack));
        }

        for (int i = 0; i < dragonPortalsNum; ++i)
        {
            player.playerUnits.Add(new GameItem(dragonPortal.objectName, dragonPortal.goldCost, dragonPortal.shardCost, dragonPortal.health, dragonPortal.attack));
        }

        for (int i = 0; i < antiAirTurretNum; ++i)
        {
            player.playerUnits.Add(new GameItem(antiAirTurret.objectName, antiAirTurret.goldCost, antiAirTurret.shardCost, antiAirTurret.health, antiAirTurret.attack));
        }

        for (int i = 0; i < wallNum; ++i)
        {
            player.playerUnits.Add(new GameItem(wall.objectName, wall.goldCost, wall.shardCost, wall.health, wall.attack));
        }

        for (int i = 0; i < minesNum; ++i)
        {
            player.playerUnits.Add(new GameItem(mines.objectName, mines.goldCost, mines.shardCost, mines.health, mines.attack));
        }
    }

    public void AddPlayerUnits()
    {
        for (int i = 0; i < minerNum; ++i)
        {
            player.playerUnits.Add(new GameItem(miner.objectName, miner.goldCost, miner.shardCost, miner.health, miner.attack));
        }

        for (int i = 0; i < advanceMinerNum; ++i)
        {
            player.playerUnits.Add(new GameItem(advanceMiner.objectName, advanceMiner.goldCost, advanceMiner.shardCost, advanceMiner.health, advanceMiner.attack));
        }

        for (int i = 0; i < dragonWarriorNum; ++i)
        {
            player.playerUnits.Add(new GameItem(dragonWarrior.objectName, dragonWarrior.goldCost, dragonWarrior.shardCost, dragonWarrior.health, dragonWarrior.attack));
        }

        for (int i = 0; i < dragonTankNum; ++i)
        {
            player.playerUnits.Add(new GameItem(dragonTank.objectName, dragonTank.goldCost, dragonTank.shardCost, dragonTank.health, dragonTank.attack));
        }

        for (int i = 0; i < dragonNum; ++i)
        {
            player.playerUnits.Add(new GameItem(dragon.objectName, dragon.goldCost, dragon.shardCost, dragon.health, dragon.attack));
        }
    }

    public void AddEnemyBuildings()
    {
        for (int i = 0; i < barracksNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(barracks.objectName, barracks.goldCost, barracks.shardCost, barracks.health, barracks.attack));
        }

        for (int i = 0; i < dragonPortalsNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(dragonPortal.objectName, dragonPortal.goldCost, dragonPortal.shardCost, dragonPortal.health, dragonPortal.attack));
        }

        for (int i = 0; i < antiAirTurretNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(antiAirTurret.objectName, antiAirTurret.goldCost, antiAirTurret.shardCost, antiAirTurret.health, antiAirTurret.attack));
        }

        for (int i = 0; i < wallNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(wall.objectName, wall.goldCost, wall.shardCost, wall.health, wall.attack));
        }

        for (int i = 0; i < minesNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(mines.objectName, mines.goldCost, mines.shardCost, mines.health, mines.attack));
        }
    }

    public void AddEnemyUnits()
    {
        for (int i = 0; i < minerNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(miner.objectName, miner.goldCost, miner.shardCost, miner.health, miner.attack));
        }

        for (int i = 0; i < advanceMinerNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(advanceMiner.objectName, advanceMiner.goldCost, advanceMiner.shardCost, advanceMiner.health, advanceMiner.attack));
        }

        for (int i = 0; i < dragonWarriorNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(dragonWarrior.objectName, dragonWarrior.goldCost, dragonWarrior.shardCost, dragonWarrior.health, dragonWarrior.attack));
        }

        for (int i = 0; i < dragonTankNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(dragonTank.objectName, dragonTank.goldCost, dragonTank.shardCost, dragonTank.health, dragonTank.attack));
        }

        for (int i = 0; i < dragonNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(dragon.objectName, dragon.goldCost, dragon.shardCost, dragon.health, dragon.attack));
        }
    }

    public void ResetNumbers()
    {
        minerNum = 0;
        advanceMinerNum = 0;
        dragonWarriorNum = 0;
        dragonTankNum = 0;
        dragonNum = 0;
        barracksNum = 0;
        dragonPortalsNum = 0;
        antiAirTurretNum = 0;
        minesNum = 0;
        wallNum = 0;
    }
}
