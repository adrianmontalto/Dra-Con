using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyHealthCalculator : MonoBehaviour
{
    public Enemy enemy;
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
            GameItem newEnemy = dragonWarrior.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }

        //adds a dragon tank to the enemyUnits list for each dragon tank initialiased
        for (int i = 0; i < enemy.m_dragonTankNum; ++i)
        {
            GameItem newEnemy = dragonTank.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }

        //adds a dragon to the enemy unit list for each dragon that you have
        for (int i = 0; i < enemy.m_dragonNum; ++i)
        {
            GameItem newEnemy = dragon.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }

        //adds a miner to the enemy unit list for each miner that you have
        for (int i = 0; i < enemy.m_minerNum; ++i)
        {
            GameItem newEnemy = miner.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }

        //adds a advance miner for each advanced miner that you have
        for (int i = 0; i < enemy.m_advanceminerNum; ++i)
        {
            GameItem newEnemy = advanceMiner.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }
    }

    //set up the buildings
    void SetUpBuildings()
    {
        //adds a barack to the enemy units list for each barrack the player has
        for (int i = 0; i < enemy.m_barrackNum; ++i)
        {
            GameItem newEnemy = barrack.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }

        //adds a dragon portal to the enemy units list for each dragon portal the player has
        for (int i = 0; i < enemy.m_dragonPortalNum; ++i)
        {
            GameItem newEnemy = dragonPortal.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }

        //adds a wall to the enemy units list for each wall the player has
        for (int i = 0; i < enemy.m_wallNum; ++i)
        {
            GameItem newEnemy = wall.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }

        //adds a anti air turrets to the enemy units list for each anti air turret the player has
        for (int i = 0; i < enemy.m_antiAirTurretNum; ++i)
        {
            GameItem newEnemy = antiAirTurret.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }

        //adds a mine to the enemy units list for each mine the player has
        for (int i = 0; i < enemy.m_mineNum; ++i)
        {
            GameItem newEnemy = mine.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(newEnemy);
        }
    }
}
