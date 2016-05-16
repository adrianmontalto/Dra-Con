using UnityEngine;
using System.Collections;

public class EnemyUnitBuilder : MonoBehaviour
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

    public Enemy enemy;
    public GameItemList gameItemList;

    public void AddEnemyBuildings()
    {
        for (int i = 0; i < m_barracksNum; ++i)
        {
            GameItem enemyBuildings = gameItemList.barracks.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyBuildings);
            enemy.m_health += gameItemList.barracks.health;
        }

        for (int i = 0; i < m_dragonPortalsNum; ++i)
        {
            GameItem enemyBuildings = gameItemList.dragonPortal.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyBuildings);
            enemy.m_health += gameItemList.dragonPortal.health;
        }

        for (int i = 0; i < m_antiAirTurretNum; ++i)
        {
            GameItem enemyBuildings = gameItemList.antiAirTurret.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyBuildings);
            enemy.m_health += gameItemList.antiAirTurret.health;
        }

        for (int i = 0; i < m_wallNum; ++i)
        {
            GameItem enemyBuildings = gameItemList.wall.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyBuildings);
            enemy.m_health += gameItemList.wall.health;
        }

        for (int i = 0; i < m_minesNum; ++i)
        {
            GameItem enemyBuildings = gameItemList.mine.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyBuildings);
            enemy.m_health += gameItemList.mine.health;
        }
    }

    public void AddEnemyUnits()
    {
        for (int i = 0; i < m_minerNum; ++i)
        {
            GameItem enemyUnit = gameItemList.miner.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyUnit);
            enemy.m_health += gameItemList.miner.health;
        }

        for (int i = 0; i < m_advanceMinerNum; ++i)
        {
            GameItem enemyUnit = gameItemList.advanceMiner.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyUnit);
            enemy.m_health += gameItemList.advanceMiner.health;
        }

        for (int i = 0; i < m_dragonWarriorNum; ++i)
        {
            GameItem enemyUnit = gameItemList.dragonWarrior.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyUnit);
            enemy.m_health += gameItemList.dragonWarrior.health;
        }

        for (int i = 0; i < m_dragonTankNum; ++i)
        {
            GameItem enemyUnit = gameItemList.dragonTank.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyUnit);
            enemy.m_health += gameItemList.dragonTank.health;
        }

        for (int i = 0; i < m_dragonNum; ++i)
        {
            GameItem enemyUnit = gameItemList.dragon.gameObject.GetComponent<GameItem>();
            enemy.m_enemyUnits.Add(enemyUnit);
            enemy.m_health += gameItemList.dragon.health;
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
