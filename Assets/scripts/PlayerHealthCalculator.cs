using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealthCalculator : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameItemList itemList;

	// Use this for initialization
	void Start ()
    {
        player.SetPlayerUnitsList(new List<GameItem>());
        SetUpUnits();
        SetUpBuildings();
        for (int i = 0; i < player.GetPlayerUnitsList().Count; ++i)
        {
            player.AddHealth(player.GetPlayerUnitsList()[i].GetHealth());
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
        for (int i = 0; i < player.GetDragonWarriorNumber(); ++i)
        {
            GameItem newPlayer = itemList.GetDragonWarrior().gameObject.GetComponent<GameItem>();
            player.GetPlayerUnitsList().Add(newPlayer);
        }

        //adds a dragon tank to the enemyUnits list for each dragon tank initialiased
        for (int i = 0; i < player.GetDragonTankNumber(); ++i)
        {
            GameItem newPlayer = itemList.GetDragonTank().gameObject.GetComponent<GameItem>();
            player.GetPlayerUnitsList().Add(newPlayer);
        }

        //adds a dragon to the enemy unit list for each dragon that you have
        for (int i = 0; i < player.GetDragonNumber(); ++i)
        {
            GameItem newPlayer = itemList.GetDragon().gameObject.GetComponent<GameItem>();
            player.GetPlayerUnitsList().Add(newPlayer);
        }

        //adds a miner to the enemy unit list for each miner that you have
        for (int i = 0; i < player.GetMinerNumber(); ++i)
        {
            GameItem newPlayer = itemList.GetMiner().gameObject.GetComponent<GameItem>();
            player.GetPlayerUnitsList().Add(newPlayer);
        }

        //adds a advance miner for each advanced miner that you have
        for (int i = 0; i < player.GetAdvanceMinerNumber(); ++i)
        {
            GameItem newPlayer = itemList.GetAdvanceMiner().gameObject.GetComponent<GameItem>();
            player.GetPlayerUnitsList().Add(newPlayer);
        }
    }

    //set up the buildings
    void SetUpBuildings()
    {
        //adds a barack to the enemy units list for each barrack the player has
        for (int i = 0; i < player.GetBarracksNumber(); ++i)
        {
            GameItem newPlayer = itemList.GetBarracks().gameObject.GetComponent<GameItem>();
            player.GetPlayerUnitsList().Add(newPlayer);
        }

        //adds a dragon portal to the enemy units list for each dragon portal the player has
        for (int i = 0; i < player.GetDragonPortalNumber(); ++i)
        {
            GameItem newPlayer = itemList.GetDragonPortal().gameObject.GetComponent<GameItem>();
            player.GetPlayerUnitsList().Add(newPlayer);
        }

        //adds a wall to the enemy units list for each wall the player has
        for (int i = 0; i < player.GetWallNumber(); ++i)
        {
            GameItem newPlayer = itemList.GetWall().gameObject.GetComponent<GameItem>();
            player.GetPlayerUnitsList().Add(newPlayer);
        }

        //adds a anti air turrets to the enemy units list for each anti air turret the player has
        for (int i = 0; i < player.GetAntiAirTurretNumber(); ++i)
        {
            GameItem newPlayer = itemList.GetAntiAirTurret().gameObject.GetComponent<GameItem>();
            player.GetPlayerUnitsList().Add(newPlayer);
        }

        //adds a mine to the enemy units list for each mine the player has
        for (int i = 0; i < player.GetMineNumber(); ++i)
        {
            GameItem newPlayer = itemList.GetMine().gameObject.GetComponent<GameItem>();
            player.GetPlayerUnitsList().Add(newPlayer);
        }
    }
}
