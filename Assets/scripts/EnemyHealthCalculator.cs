using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyHealthCalculator : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private GameItemList itemList;

	// Use this for initialization
	void Start ()
    {
        SetUpUnits();
        SetUpBuildings();
        for(int i = 0; i < enemy.GetEnemyUnits().Count;++i)
        {
            enemy.AddHealth(enemy.GetEnemyUnits()[i].GetHealth());
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
        for (int i = 0; i < enemy.GetDragonWarriorNumber(); ++i)
        {
            GameItem newEnemy = itemList.GetDragonWarrior().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(newEnemy);
        }

        //adds a dragon tank to the enemyUnits list for each dragon tank initialiased
        for (int i = 0; i < enemy.GetDragonTankNumber(); ++i)
        {
            GameItem newEnemy = itemList.GetDragonTank().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(newEnemy);
        }

        //adds a dragon to the enemy unit list for each dragon that you have
        for (int i = 0; i < enemy.GetDragonNumber(); ++i)
        {
            GameItem newEnemy = itemList.GetDragon().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(newEnemy);
        }

        //adds a miner to the enemy unit list for each miner that you have
        for (int i = 0; i < enemy.GetMinerNumber(); ++i)
        {
            GameItem newEnemy = itemList.GetMiner().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(newEnemy);
        }

        //adds a advance miner for each advanced miner that you have
        for (int i = 0; i < enemy.GetAdvanceMinerNumber(); ++i)
        {
            GameItem newEnemy = itemList.GetAdvanceMiner().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(newEnemy);
        }
    }

    //set up the buildings
    void SetUpBuildings()
    {
        //adds a barack to the enemy units list for each barrack the player has
        for (int i = 0; i < enemy.GetBarracksNumber(); ++i)
        {
            GameItem newEnemy = itemList.GetBarracks().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(newEnemy);
        }

        //adds a dragon portal to the enemy units list for each dragon portal the player has
        for (int i = 0; i < enemy.GetDragonPortalNumber(); ++i)
        {
            GameItem newEnemy = itemList.GetDragonPortal().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(newEnemy);
        }

        //adds a wall to the enemy units list for each wall the player has
        for (int i = 0; i < enemy.GetWallNumber(); ++i)
        {
            GameItem newEnemy = itemList.GetWall().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(newEnemy);
        }

        //adds a anti air turrets to the enemy units list for each anti air turret the player has
        for (int i = 0; i < enemy.GetAntiAirTurretNumber(); ++i)
        {
            GameItem newEnemy = itemList.GetAntiAirTurret().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(newEnemy);
        }

        //adds a mine to the enemy units list for each mine the player has
        for (int i = 0; i < enemy.GetMineNumber(); ++i)
        {
            GameItem newEnemy = itemList.GetMine().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(newEnemy);
        }
    }
}
