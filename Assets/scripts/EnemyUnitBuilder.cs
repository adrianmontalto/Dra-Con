using UnityEngine;
using System.Collections;

public class EnemyUnitBuilder : MonoBehaviour
{
    private int m_minerNum = 0;
    private int m_advanceMinerNum = 0;
    private int m_dragonWarriorNum = 0;
    private int m_dragonTankNum = 0;
    private int m_dragonNum = 0;
    private int m_barracksNum = 0;
    private int m_dragonPortalsNum = 0;
    private int m_antiAirTurretNum = 0;
    private int m_minesNum = 0;
    private int m_wallNum = 0;

    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private GameItemList gameItemList;

    public void AddEnemyBuildings()
    {
        for (int i = 0; i < m_barracksNum; ++i)
        {
            GameItem enemyBuildings = gameItemList.GetBarracks().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(enemyBuildings);
            enemy.AddHealth(gameItemList.GetBarracks().GetHealth());
        }

        for (int i = 0; i < m_dragonPortalsNum; ++i)
        {
            GameItem enemyBuildings = gameItemList.GetDragonPortal().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(enemyBuildings);
            enemy.AddHealth(gameItemList.GetDragonPortal().GetHealth());
        }

        for (int i = 0; i < m_antiAirTurretNum; ++i)
        {
            GameItem enemyBuildings = gameItemList.GetAntiAirTurret().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(enemyBuildings);
            enemy.AddHealth(gameItemList.GetAntiAirTurret().GetHealth());
        }

        for (int i = 0; i < m_wallNum; ++i)
        {
            GameItem enemyBuildings = gameItemList.GetWall().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(enemyBuildings);
            enemy.AddHealth(gameItemList.GetWall().GetHealth());
        }

        for (int i = 0; i < m_minesNum; ++i)
        {
            GameItem enemyBuildings = gameItemList.GetMine().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(enemyBuildings);
            enemy.AddHealth(gameItemList.GetMine().GetHealth());
        }
    }

    public void AddEnemyUnits()
    {
        for (int i = 0; i < m_minerNum; ++i)
        {
            GameItem enemyUnit = gameItemList.GetMiner().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(enemyUnit);
            enemy.AddHealth(gameItemList.GetMiner().GetHealth());
        }

        for (int i = 0; i < m_advanceMinerNum; ++i)
        {
            GameItem enemyUnit = gameItemList.GetAdvanceMiner().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(enemyUnit);
            enemy.AddHealth(gameItemList.GetAdvanceMiner().GetHealth());
        }

        for (int i = 0; i < m_dragonWarriorNum; ++i)
        {
            GameItem enemyUnit = gameItemList.GetDragonWarrior().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(enemyUnit);
            enemy.AddHealth(gameItemList.GetDragonWarrior().GetHealth());
        }

        for (int i = 0; i < m_dragonTankNum; ++i)
        {
            GameItem enemyUnit = gameItemList.GetDragonTank().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(enemyUnit);
            enemy.AddHealth(gameItemList.GetDragonTank().GetHealth());
        }

        for (int i = 0; i < m_dragonNum; ++i)
        {
            GameItem enemyUnit = gameItemList.GetDragon().gameObject.GetComponent<GameItem>();
            enemy.GetEnemyUnits().Add(enemyUnit);
            enemy.AddHealth(gameItemList.GetDragon().GetHealth());
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

    public int GetDragonWarriorNumber()
    {
        return m_dragonWarriorNum;
    }

    public void ReduceDragonWarriorNumber(int amount)
    {
        m_dragonWarriorNum -= amount;
    }

    public void AddDragonWarriorNumber(int amount)
    {
        m_dragonWarriorNum += amount;
    }

    public int GetDragonTankNumber()
    {
        return m_dragonTankNum;
    }

    public void ReduceDragonTankNumber(int amount)
    {
        m_dragonTankNum -= amount;
    }

    public void AddDragonTankNumber(int amount)
    {
        m_dragonTankNum += amount;
    }

    public int GetDragonNumber()
    {
        return m_dragonNum;
    }

    public void ReduceDragonNumber(int amount)
    {
        m_dragonNum -= amount;
    }

    public void AddDragonNumber(int amount)
    {
        m_dragonNum += amount;
    }

    public int GetMinerNumber()
    {
        return m_minerNum;
    }

    public void ReduceMinerNumber(int amount)
    {
        m_minerNum -= amount;
    }

    public void AddMinerNumber(int amount)
    {
        m_minerNum += amount;
    }

    public int GetAdvanceMinerNumber()
    {
        return m_advanceMinerNum;
    }

    public void ReduceAdvanceMinerNumber(int amount)
    {
        m_advanceMinerNum -= amount;
    }

    public void AddAdvanceMinerNumber(int amount)
    {
        m_advanceMinerNum += amount;
    }

    public int GetBarracksNum()
    {
        return m_barracksNum;
    }

    public void ReduceBarracksNum(int amount)
    {
        m_barracksNum -= amount;
    }

    public void AddBarracksNum(int amount)
    {
        m_barracksNum += amount;
    }
    public int GetDragonPortalNumber()
    {
        return m_dragonPortalsNum;
    }

    public void ReduceDragonPortalNumber(int amount)
    {
        m_dragonPortalsNum -= amount;
    }

    public void AddDragonPortalNumber(int amount)
    {
        m_dragonPortalsNum += amount;
    }

    public int GetWallNumber()
    {
        return m_wallNum;
    }

    public void ReduceWallNumber(int amount)
    {
        m_wallNum -= amount;
    }

    public void AddWallNumber(int amount)
    {
        m_wallNum += amount;
    }

    public int GetAntiAirTurretNumber()
    {
        return m_antiAirTurretNum;
    }

    public void ReduceAntiAirTurretNumber(int amount)
    {
        m_antiAirTurretNum -= amount;
    }

    public void AddAntiAirTurretNumber(int amount)
    {
        m_antiAirTurretNum += amount;
    }

    public int GetMinesNum()
    {
        return m_minesNum;
    }

    public void ReduceMineNum(int amount)
    {
        m_minesNum -= amount;
    }

    public void AddMineNum(int amount)
    {
        m_minesNum += amount;
    }
}
