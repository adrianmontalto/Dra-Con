using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealthCalculator : MonoBehaviour
{
    public Player player;
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
        player.playerUnits = new List<GameItem>();
        SetUpUnits();
        SetUpBuildings();
        for (int i = 0; i < player.playerUnits.Count; ++i)
        {
            player.health += player.playerUnits[i].health;
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
        for (int i = 0; i < player.dragonWarriorNum; ++i)
        {
            GameItem newPlayer = dragonWarrior.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(newPlayer);
        }

        //adds a dragon tank to the enemyUnits list for each dragon tank initialiased
        for (int i = 0; i < player.dragonTankNum; ++i)
        {
            GameItem newPlayer = dragonTank.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(newPlayer);
        }

        //adds a dragon to the enemy unit list for each dragon that you have
        for (int i = 0; i < player.dragonNum; ++i)
        {
            GameItem newPlayer = dragon.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(newPlayer);
        }

        //adds a miner to the enemy unit list for each miner that you have
        for (int i = 0; i < player.minerNum; ++i)
        {
            GameItem newPlayer = miner.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(newPlayer);
        }

        //adds a advance miner for each advanced miner that you have
        for (int i = 0; i < player.advanceminerNum; ++i)
        {
            GameItem newPlayer = advanceMiner.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(newPlayer);
        }
    }

    //set up the buildings
    void SetUpBuildings()
    {
        //adds a barack to the enemy units list for each barrack the player has
        for (int i = 0; i < player.barrackNum; ++i)
        {
            GameItem newPlayer = barrack.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(newPlayer);
        }

        //adds a dragon portal to the enemy units list for each dragon portal the player has
        for (int i = 0; i < player.dragonPortalNum; ++i)
        {
            GameItem newPlayer = dragonPortal.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(newPlayer);
        }

        //adds a wall to the enemy units list for each wall the player has
        for (int i = 0; i < player.wallNum; ++i)
        {
            GameItem newPlayer = wall.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(newPlayer);
        }

        //adds a anti air turrets to the enemy units list for each anti air turret the player has
        for (int i = 0; i < player.antiAirTurretNum; ++i)
        {
            GameItem newPlayer = antiAirTurret.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(newPlayer);
        }

        //adds a mine to the enemy units list for each mine the player has
        for (int i = 0; i < player.mineNum; ++i)
        {
            GameItem newPlayer = mine.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(newPlayer);
        }
    }
}
