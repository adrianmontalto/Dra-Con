using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyHealthCalculator : MonoBehaviour
{
    public Enemy enemy;
    public GameItemList itemList;

	// Use this for initialization
	void Start ()
    {
        SetUpUnits();
        SetUpBuildings();
        for(int i = 0; i < enemy.m_enemyUnits.Count;++i)
        {
            enemy.m_health += enemy.m_enemyUnits[i].health;
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
        for (int i = 0; i < enemy.m_dragonWarriorNum; ++i)
        {
            GameItem newEnemy = itemList.dragonWarrior.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }

        //adds a dragon tank to the enemyUnits list for each dragon tank initialiased
        for (int i = 0; i < enemy.m_dragonTankNum; ++i)
        {
            GameItem newEnemy = itemList.dragonTank.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }

        //adds a dragon to the enemy unit list for each dragon that you have
        for (int i = 0; i < enemy.m_dragonNum; ++i)
        {
            GameItem newEnemy = itemList.dragon.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }

        //adds a miner to the enemy unit list for each miner that you have
        for (int i = 0; i < enemy.m_minerNum; ++i)
        {
            GameItem newEnemy = itemList.miner.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }

        //adds a advance miner for each advanced miner that you have
        for (int i = 0; i < enemy.m_advanceminerNum; ++i)
        {
            GameItem newEnemy = itemList.advanceMiner.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }
    }

    //set up the buildings
    void SetUpBuildings()
    {
        //adds a barack to the enemy units list for each barrack the player has
        for (int i = 0; i < enemy.m_barrackNum; ++i)
        {
            GameItem newEnemy = itemList.barracks.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }

        //adds a dragon portal to the enemy units list for each dragon portal the player has
        for (int i = 0; i < enemy.m_dragonPortalNum; ++i)
        {
            GameItem newEnemy = itemList.dragonPortal.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }

        //adds a wall to the enemy units list for each wall the player has
        for (int i = 0; i < enemy.m_wallNum; ++i)
        {
            GameItem newEnemy = itemList.wall.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }

        //adds a anti air turrets to the enemy units list for each anti air turret the player has
        for (int i = 0; i < enemy.m_antiAirTurretNum; ++i)
        {
            GameItem newEnemy = itemList.antiAirTurret.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }

        //adds a mine to the enemy units list for each mine the player has
        for (int i = 0; i < enemy.m_mineNum; ++i)
        {
            GameItem newEnemy = itemList.mine.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }
    }
}
