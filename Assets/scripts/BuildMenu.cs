using UnityEngine;
using System.Collections;

public class BuildMenu : MonoBehaviour
{
    [HideInInspector]
    public int m_minerNum = 0;
    [HideInInspector]
    public int m_advanceMinerNum = 0;
    [HideInInspector]
    public int m_dragonWarriorNum = 0;
    [HideInInspector]
    public int m_dragonTankNum = 0;
    [HideInInspector]
    public int m_dragonNum = 0;
    [HideInInspector]
    public int m_barracksNum = 0;
    [HideInInspector]
    public int m_dragonPortalsNum = 0;
    [HideInInspector]
    public int m_antiAirTurretNum = 0;
    [HideInInspector]
    public int m_minesNum = 0;
    [HideInInspector]
    public int m_wallNum = 0;
   
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
        for(int i = 0; i < m_barracksNum; ++i)
        {
            GameItem playerBuilding = barracks.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(playerBuilding);
            player.m_health += barracks.health;
        }

        for (int i = 0; i < m_dragonPortalsNum; ++i)
        {
            GameItem playerBuilding = dragonPortal.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(playerBuilding);
            player.m_health += dragonPortal.health;
        }

        for (int i = 0; i < m_antiAirTurretNum; ++i)
        {
            GameItem playerBuilding = antiAirTurret.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(playerBuilding);
            player.m_health += antiAirTurret.health;
        }

        for (int i = 0; i < m_wallNum; ++i)
        {
            GameItem playerBuilding = wall.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(playerBuilding);
            player.m_health += wall.health;
        }

        for (int i = 0; i < m_minesNum; ++i)
        {
            GameItem playerBuilding = mines.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(playerBuilding);
            player.m_health += mines.health;
        }
    }

    public void AddPlayerUnits()
    {
        for (int i = 0; i < m_minerNum; ++i)
        {
            GameItem playerUnits = miner.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(playerUnits);
            player.m_health += miner.health;
        }

        for (int i = 0; i < m_advanceMinerNum; ++i)
        {
            GameItem playerUnits = advanceMiner.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(playerUnits);
            player.m_health += advanceMiner.health;
        }

        for (int i = 0; i < m_dragonWarriorNum; ++i)
        {
            GameItem playerUnits = dragonWarrior.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(playerUnits);
            player.m_health += dragonWarrior.health;
        }

        for (int i = 0; i < m_dragonTankNum; ++i)
        {
            GameItem playerUnits = dragonTank.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(playerUnits);
            player.m_health += dragonTank.health;
        }

        for (int i = 0; i < m_dragonNum; ++i)
        {
            GameItem playerUnits = dragon.gameObject.GetComponent<GameItem>();
            player.m_playerUnits.Add(playerUnits);
            player.m_health += dragon.health;
        }
    }

    public void AddEnemyBuildings()
    {
        for (int i = 0; i < m_barracksNum; ++i)
        {
            GameItem enemyBuildings = barracks.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyBuildings);
            enemy.m_health += barracks.health;
        }

        for (int i = 0; i < m_dragonPortalsNum; ++i)
        {
            GameItem enemyBuildings = dragonPortal.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyBuildings);
            enemy.m_health += dragonPortal.health;
        }

        for (int i = 0; i < m_antiAirTurretNum; ++i)
        {
            GameItem enemyBuildings = antiAirTurret.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyBuildings);
            enemy.m_health += antiAirTurret.health;
        }

        for (int i = 0; i < m_wallNum; ++i)
        {
            GameItem enemyBuildings = wall.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyBuildings);
            enemy.m_health += wall.health;
        }

        for (int i = 0; i < m_minesNum; ++i)
        {
            GameItem enemyBuildings = mines.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyBuildings);
            enemy.m_health += mines.health;
        }
    }

    public void AddEnemyUnits()
    {
        for (int i = 0; i < m_minerNum; ++i)
        {
            GameItem enemyUnit = miner.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyUnit);
            enemy.m_health += miner.health;
        }

        for (int i = 0; i < m_advanceMinerNum; ++i)
        {
            GameItem enemyUnit = advanceMiner.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyUnit);
            enemy.m_health += advanceMiner.health;
        }

        for (int i = 0; i < m_dragonWarriorNum; ++i)
        {
            GameItem enemyUnit = dragonWarrior.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyUnit);
            enemy.m_health += dragonWarrior.health;
        }

        for (int i = 0; i < m_dragonTankNum; ++i)
        {
            GameItem enemyUnit =dragonTank.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyUnit);
            enemy.m_health += dragonTank.health;
        }

        for (int i = 0; i < m_dragonNum; ++i)
        {
            GameItem enemyUnit = dragon.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyUnit);
            enemy.m_health += dragon.health;
        }
    }

    public void ResetNumbers()
    {
        m_minerNum = 0;
        m_advanceMinerNum = 0;
        m_dragonWarriorNum = 0;
        m_dragonTankNum = 0;
        m_dragonNum = 0;
        m_barracksNum = 0;
        m_dragonPortalsNum = 0;
        m_antiAirTurretNum = 0;
        m_minesNum = 0;
        m_wallNum = 0;
    }
}
