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
        player.m_playerUnits = new List<GameItem>();
        SetUpUnits();
        SetUpBuildings();
        for (int i = 0; i < player.m_playerUnits.Count; ++i)
        {
            player.m_health += player.m_playerUnits[i].health;
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
        for (int i = 0; i < player.m_dragonWarriorNum; ++i)
        {
            GameItem newPlayer = itemList.dragonWarrior.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(newPlayer);
        }

        //adds a dragon tank to the enemyUnits list for each dragon tank initialiased
        for (int i = 0; i < player.m_dragonTankNum; ++i)
        {
            GameItem newPlayer = itemList.dragonTank.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(newPlayer);
        }

        //adds a dragon to the enemy unit list for each dragon that you have
        for (int i = 0; i < player.m_dragonNum; ++i)
        {
            GameItem newPlayer = itemList.dragon.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(newPlayer);
        }

        //adds a miner to the enemy unit list for each miner that you have
        for (int i = 0; i < player.m_minerNum; ++i)
        {
            GameItem newPlayer = itemList.miner.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(newPlayer);
        }

        //adds a advance miner for each advanced miner that you have
        for (int i = 0; i < player.m_advanceminerNum; ++i)
        {
            GameItem newPlayer = itemList.advanceMiner.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(newPlayer);
        }
    }

    //set up the buildings
    void SetUpBuildings()
    {
        //adds a barack to the enemy units list for each barrack the player has
        for (int i = 0; i < player.m_barrackNum; ++i)
        {
            GameItem newPlayer = itemList.barracks.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(newPlayer);
        }

        //adds a dragon portal to the enemy units list for each dragon portal the player has
        for (int i = 0; i < player.m_dragonPortalNum; ++i)
        {
            GameItem newPlayer = itemList.dragonPortal.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(newPlayer);
        }

        //adds a wall to the enemy units list for each wall the player has
        for (int i = 0; i < player.m_wallNum; ++i)
        {
            GameItem newPlayer = itemList.wall.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(newPlayer);
        }

        //adds a anti air turrets to the enemy units list for each anti air turret the player has
        for (int i = 0; i < player.m_antiAirTurretNum; ++i)
        {
            GameItem newPlayer = itemList.antiAirTurret.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(newPlayer);
        }

        //adds a mine to the enemy units list for each mine the player has
        for (int i = 0; i < player.m_mineNum; ++i)
        {
            GameItem newPlayer = itemList.mine.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(newPlayer);
        }
    }
}
