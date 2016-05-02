using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyHealthCalculator : MonoBehaviour
{
    public Enemy enemy;
    [HideInInspector]
    public GameItem barrack;
    public GameItem dragonPortal;
    public GameItem antiAirTurret;
    public GameItem mine;
    public GameItem wall;
    public GameItem miner;
    public GameItem advanceMiner;
    public GameItem dragonWarrior;
    public GameItem dragonTank;
    public GameItem dragon;
	// Use this for initialization
	void Start ()
    {
        SetUpUnits();
        SetUpBuildings();
        for(int i = 0; i < enemy.enemyUnits.Count;++i)
        {
            enemy.health += enemy.enemyUnits[i].health;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //sets up the units
    void SetUpUnits()
    {
        //adds a dragon warrior to the enemy unit list for the initial amount of dragon warriors
        for (int i = 0; i < enemy.dragonWarriorNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(dragonWarrior.objectName, dragonWarrior.goldCost, dragonWarrior.shardCost, dragonWarrior.health, dragonWarrior.attack));
        }

        //adds a dragon tank to the enemyUnits list for each dragon tank initialiased
        for (int i = 0; i < enemy.dragonTankNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(dragonTank.objectName, dragonTank.goldCost, dragonTank.shardCost, dragonTank.health, dragonTank.attack));
        }

        //adds a dragon to the enemy unit list for each dragon that you have
        for (int i = 0; i < enemy.dragonNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(dragon.objectName, dragon.goldCost, dragon.shardCost, dragon.health, dragon.attack));
        }

        //adds a miner to the enemy unit list for each miner that you have
        for (int i = 0; i < enemy.minerNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(miner.objectName, miner.goldCost, miner.shardCost, miner.health, miner.attack));
        }

        //adds a advance miner for each advanced miner that you have
        for (int i = 0; i < enemy.advanceminerNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(advanceMiner.objectName, advanceMiner.goldCost, advanceMiner.shardCost, advanceMiner.health, advanceMiner.attack));
        }
    }

    //set up the buildings
    void SetUpBuildings()
    {
        //adds a barack to the enemy units list for each barrack the player has
        for (int i = 0; i < enemy.barrackNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(barrack.name, barrack.goldCost, barrack.shardCost, barrack.health, barrack.attack));
        }

        //adds a dragon portal to the enemy units list for each dragon portal the player has
        for (int i = 0; i < enemy.dragonPortalNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(dragonPortal.name, dragonPortal.goldCost, dragonPortal.shardCost, dragonPortal.health,
                                         dragonPortal.attack));
        }

        //adds a wall to the enemy units list for each wall the player has
        for (int i = 0; i < enemy.wallNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(wall.name, wall.goldCost, wall.shardCost, wall.health, wall.attack));
        }

        //adds a anti air turrets to the enemy units list for each anti air turret the player has
        for (int i = 0; i < enemy.antiAirTurretNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(antiAirTurret.name, antiAirTurret.goldCost, antiAirTurret.shardCost,
                                         antiAirTurret.health, antiAirTurret.attack));
        }

        //adds a mine to the enemy units list for each mine the player has
        for (int i = 0; i < enemy.mineNum; ++i)
        {
            enemy.enemyUnits.Add(new GameItem(mine.name, mine.goldCost, mine.shardCost, mine.health, mine.attack));
        }
    }
}
