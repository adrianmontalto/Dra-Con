using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealthCalculator : MonoBehaviour
{
    public Player player;
    [HideInInspector]
    public List<GameItem> playerUnits;
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
        playerUnits = new List<GameItem>();
        SetUpUnits();
        SetUpBuildings();
        for (int i = 0; i < playerUnits.Count; ++i)
        {
            player.health += playerUnits[i].health;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    //sets up the units
    void SetUpUnits()
    {
        //adds a dragon warrior to the player unit list for the initial amount of dragon warriors
        for (int i = 0; i < player.dragonWarriorNum; ++i)
        {
            playerUnits.Add(new GameItem(dragonWarrior.objectName, dragonWarrior.goldCost, dragonWarrior.shardCost, dragonWarrior.health, dragonWarrior.attack));
        }

        //adds a dragon tank to the playerUnits list for each dragon tank initialiased
        for (int i = 0; i < player.dragonTankNum; ++i)
        {
            playerUnits.Add(new GameItem(dragonTank.objectName, dragonTank.goldCost, dragonTank.shardCost, dragonTank.health, dragonTank.attack));
        }

        //adds a dragon to the player unit list for each dragon that you have
        for (int i = 0; i < player.dragonNum; ++i)
        {
            playerUnits.Add(new GameItem(dragon.objectName, dragon.goldCost, dragon.shardCost, dragon.health, dragon.attack));
        }

        //adds a miner to the player unit list for each miner that you have
        for (int i = 0; i < player.minerNum; ++i)
        {
            playerUnits.Add(new GameItem(miner.objectName, miner.goldCost, miner.shardCost, miner.health, miner.attack));
        }

        //adds a advance miner for each advanced miner that you have
        for (int i = 0; i < player.advanceminerNum; ++i)
        {
            playerUnits.Add(new GameItem(advanceMiner.objectName, advanceMiner.goldCost, advanceMiner.shardCost, advanceMiner.health, advanceMiner.attack));
        }
    }

    //set up the buildings
    void SetUpBuildings()
    {
        //adds a barack to the player units list for each barrack the player has
        for (int i = 0; i < player.barrackNum;++i)
        {
            playerUnits.Add(new GameItem(barrack.name,barrack.goldCost,barrack.shardCost,barrack.health,barrack.attack));
        }

        //adds a dragon portal to the player units list for each dragon portal the player has
        for(int i =0; i < player.dragonPortalNum;++i)
        {
            playerUnits.Add(new GameItem(dragonPortal.name,dragonPortal.goldCost,dragonPortal.shardCost,dragonPortal.health,
                                         dragonPortal.attack));
        }

        //adds a wall to the player units list for each wall the player has
        for(int i = 0; i < player.wallNum; ++ i)
        {
            playerUnits.Add(new GameItem(wall.name,wall.goldCost,wall.shardCost,wall.health,wall.attack));
        }

        //adds a anti air turrets to the player units list for each anti air turret the player has
        for(int i = 0; i < player.antiAirTurretNum; ++i)
        {
            playerUnits.Add(new GameItem(antiAirTurret.name,antiAirTurret.goldCost,antiAirTurret.shardCost,
                                         antiAirTurret.health,antiAirTurret.attack));
        }

        //adds a mine to the player units list for each mine the player has
        for(int i = 0; i < player.mineNum; ++i)
        {
            playerUnits.Add(new GameItem(mine.name,mine.goldCost,mine.shardCost,mine.health,mine.attack));
        }
    }
}
