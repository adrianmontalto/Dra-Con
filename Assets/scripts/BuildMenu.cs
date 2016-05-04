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
            GameItem playerBuilding = barracks.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(playerBuilding);
            player.health += barracks.health;
        }

        for (int i = 0; i < dragonPortalsNum; ++i)
        {
            GameItem playerBuilding = dragonPortal.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(playerBuilding);
            player.health += dragonPortal.health;
        }

        for (int i = 0; i < antiAirTurretNum; ++i)
        {
            GameItem playerBuilding = antiAirTurret.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(playerBuilding);
            player.health += antiAirTurret.health;
        }

        for (int i = 0; i < wallNum; ++i)
        {
            GameItem playerBuilding = wall.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(playerBuilding);
            player.health += wall.health;
        }

        for (int i = 0; i < minesNum; ++i)
        {
            GameItem playerBuilding = mines.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(playerBuilding);
            player.health += mines.health;
        }
    }

    public void AddPlayerUnits()
    {
        for (int i = 0; i < minerNum; ++i)
        {
            GameItem playerUnits = miner.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(playerUnits);
            player.health += miner.health;
        }

        for (int i = 0; i < advanceMinerNum; ++i)
        {
            GameItem playerUnits = advanceMiner.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(playerUnits);
            player.health += advanceMiner.health;
        }

        for (int i = 0; i < dragonWarriorNum; ++i)
        {
            GameItem playerUnits = dragonWarrior.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(playerUnits);
            player.health += dragonWarrior.health;
        }

        for (int i = 0; i < dragonTankNum; ++i)
        {
            GameItem playerUnits = dragonTank.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(playerUnits);
            player.health += dragonTank.health;
        }

        for (int i = 0; i < dragonNum; ++i)
        {
            GameItem playerUnits = dragon.gameObject.GetComponent<GameItem>();
            player.playerUnits.Add(playerUnits);
            player.health += dragon.health;
        }
    }

    public void AddEnemyBuildings()
    {
        for (int i = 0; i < barracksNum; ++i)
        {
            GameItem enemyBuildings = barracks.gameObject.GetComponent<GameItem>();
            enemy.enemyUnits.Add(enemyBuildings);
            enemy.health += barracks.health;
        }

        for (int i = 0; i < dragonPortalsNum; ++i)
        {
            GameItem enemyBuildings = dragonPortal.gameObject.GetComponent<GameItem>();
            enemy.enemyUnits.Add(enemyBuildings);
            enemy.health += dragonPortal.health;
        }

        for (int i = 0; i < antiAirTurretNum; ++i)
        {
            GameItem enemyBuildings = antiAirTurret.gameObject.GetComponent<GameItem>();
            enemy.enemyUnits.Add(enemyBuildings);
            enemy.health += antiAirTurret.health;
        }

        for (int i = 0; i < wallNum; ++i)
        {
            GameItem enemyBuildings = wall.gameObject.GetComponent<GameItem>();
            enemy.enemyUnits.Add(enemyBuildings);
            enemy.health += wall.health;
        }

        for (int i = 0; i < minesNum; ++i)
        {
            GameItem enemyBuildings = mines.gameObject.GetComponent<GameItem>();
            enemy.enemyUnits.Add(enemyBuildings);
            enemy.health += mines.health;
        }
    }

    public void AddEnemyUnits()
    {
        for (int i = 0; i < minerNum; ++i)
        {
            GameItem enemyUnit = miner.gameObject.GetComponent<GameItem>();
            enemy.enemyUnits.Add(enemyUnit);
            enemy.health += miner.health;
        }

        for (int i = 0; i < advanceMinerNum; ++i)
        {
            GameItem enemyUnit = advanceMiner.gameObject.GetComponent<GameItem>();
            enemy.enemyUnits.Add(enemyUnit);
            enemy.health += advanceMiner.health;
        }

        for (int i = 0; i < dragonWarriorNum; ++i)
        {
            GameItem enemyUnit = dragonWarrior.gameObject.GetComponent<GameItem>();
            enemy.enemyUnits.Add(enemyUnit);
            enemy.health += dragonWarrior.health;
        }

        for (int i = 0; i < dragonTankNum; ++i)
        {
            GameItem enemyUnit =dragonTank.gameObject.GetComponent<GameItem>();
            enemy.enemyUnits.Add(enemyUnit);
            enemy.health += dragonTank.health;
        }

        for (int i = 0; i < dragonNum; ++i)
        {
            GameItem enemyUnit = dragon.gameObject.GetComponent<GameItem>();
            enemy.enemyUnits.Add(enemyUnit);
            enemy.health += dragon.health;
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
