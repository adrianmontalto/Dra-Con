using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;//the game manager
    [SerializeField]
    private WinningGoalsManager winningGoalManager;
    
    [SerializeField]
    private int m_gold = 0;
    [SerializeField]
    private int m_shards = 0;
    [SerializeField]
    private int m_dragonWarriorNum = 0;
    [SerializeField]
    private int m_dragonTankNum = 0;
    [SerializeField]
    private int m_dragonNum = 0;
    [SerializeField]
    private int m_minerNum = 0;
    [SerializeField]
    private int m_advanceminerNum = 0;
    [SerializeField]
    private int m_barrackNum = 0;
    [SerializeField]
    private int m_dragonPortalNum = 0;
    [SerializeField]
    private int m_wallNum = 0;
    [SerializeField]
    private int m_antiAirTurretNum = 0;
    [SerializeField]
    private int m_mineNum = 0;

    private int m_health = 0;
    private List<GameItem> m_enemyUnits = new List<GameItem>();
    private float m_closenessToWinGoal = 0;
    private float m_closenessToShardGoal;
    private float m_closenessToGoldGoal;
    private int m_totalUnitCount = 0;
    private int m_totalResourceUnits = 0;
    private int m_dragonWarriorsDestroyed = 0;
    private int m_dragonTanksDestroyed = 0;
    private int m_dragonsDestroyed = 0;

    
    private float m_maxClosenessToWinGoal = 0;
    private int m_maxGold = 0;
    private int m_maxShard = 0;
    private int m_maxTotalUnitCount = 0;
    private int m_maxHealth = 0;
    private int m_maxTotalResourceUnits = 0;
    private int m_maxMinerNum = 0;
    private int m_maxAdvanceMinerNum = 0;
    private int m_maxMineNum = 0;
    private int m_maxWallNum = 0;
    private int m_maxAntiAirTurretNum = 0;
    private int m_maxBarracksNum = 0;
    private int m_maxDragonPortalNum = 0;
    private int m_maxDragonWarriorNum = 0;
    private int m_maxDragonTankNum = 0;
    private int m_maxDragonNum = 0;
    // Use this for initialization
    void Start ()
    {
        SetMaxValues();
    }
	
	// Update is called once per frame
	void Update ()
    {
        m_closenessToGoldGoal = m_gold / winningGoalManager.GetGoldNeeded();
        m_closenessToShardGoal = m_shards / winningGoalManager.GetShardsNeeded();
        m_closenessToWinGoal = (m_closenessToGoldGoal + m_closenessToShardGoal) / 2;

        m_totalUnitCount = m_dragonWarriorNum + m_dragonTankNum + m_dragonNum;
        m_totalResourceUnits = m_minerNum + m_advanceminerNum;
    }

    public void ReduceUnitNumber(string unitName)
    {
        if(unitName == "barracks")
        {
            m_barrackNum --;
        }
        
        if(unitName == "dragonPortal")
        {
            m_dragonPortalNum --;
        }

        if(unitName == "antiAirTurret")
        {
            m_antiAirTurretNum --;
        }

        if(unitName == "mine")
        {
            m_mineNum --;
        }

        if (unitName == "miner")
        {
            m_minerNum --;
        }

        if (unitName == "advanceMiner")
        {
            m_advanceminerNum --;
        }

        if (unitName == "dragonWarrior")
        {
            m_dragonWarriorNum --;
        }

        if (unitName == "dragonTank")
        {
            m_dragonTankNum --;
        }

        if (unitName == "dragon")
        {
            m_dragonNum --;
        }
    }

    public void DestroyGroundUnit(int damage)
    {
        int unitDamage = damage;
        while(unitDamage > 0)
        {
            int index = ChooseWhichUnitToDestroy();
            if (unitDamage > m_enemyUnits[index].GetHealth())
            {
                unitDamage -= m_enemyUnits[index].GetHealth();
                if (m_enemyUnits[index].name == "dragonWarrior")
                {
                    DestroyLastDragonWarrior(index);
                }
                if (m_enemyUnits[index].name == "dragonTank")
                {
                    DestroyLastDragonTank(index);
                }
            }
            else
            {
                m_enemyUnits[index].ReduceHealth(unitDamage);
                unitDamage = 0;
            }
        }
    }

    void DestroyLastDragonWarrior(int index)
    {
        if(index > -1)
        {
            m_enemyUnits.RemoveAt(index);
            m_dragonWarriorNum --;
            m_dragonWarriorsDestroyed ++;
        }
    }

    void DestroyLastDragonTank(int index)
    {
        m_enemyUnits.RemoveAt(index);
        m_dragonTankNum --;
        m_dragonTanksDestroyed ++;
    }

    int ChooseWhichUnitToDestroy()
    {
        int lastWarrior = m_enemyUnits.FindLastIndex((GameItem item) =>
        { return item.GetName() == "dragonWarrior"; });
        int lastTank = m_enemyUnits.FindLastIndex((GameItem item) =>
        { return item.GetName() == "dragonTank"; });

        if (lastWarrior > lastTank)
        {
            return lastWarrior;
        }
        else
            return lastTank;
    }

    public void DestroyDragons(int damage)
    {
        int dragonDamage = damage;
        while (dragonDamage > 0)
        {
            int lastDragon = m_enemyUnits.FindLastIndex((GameItem item) => 
                                { return item.GetName() == "dragon"; });
            if (dragonDamage > m_enemyUnits[lastDragon].GetHealth())
            {
                dragonDamage -= m_enemyUnits[lastDragon].GetHealth();
                DestroyLastDragon(lastDragon);
            }
            else
            {
                m_enemyUnits[lastDragon].ReduceHealth(dragonDamage);
                dragonDamage = 0;
            }
        }
    }

    void DestroyLastDragon(int index)
    {
        m_enemyUnits.RemoveAt(index);
        m_dragonNum--;
        m_dragonsDestroyed ++;
    }

    public void DestroyMines(int number)
    {
        for(int i = 0; i < number;++i)
        {
            int lastMine = m_enemyUnits.FindLastIndex((GameItem item) => { return item.GetName() == "mines";});

            if(lastMine > -1)
            {
                m_enemyUnits.RemoveAt(lastMine);
                m_mineNum--;
            }
        }
    }

    public void SetMaxValues()
    {
        if (m_closenessToWinGoal > m_maxClosenessToWinGoal)
        {
            m_maxClosenessToWinGoal = m_closenessToWinGoal;
        }

        if (m_gold > m_maxGold)
        {
            m_maxGold = m_gold;
        }

        if (m_shards > m_maxShard)
        {
            m_maxShard = m_shards;
        }

        if (m_totalUnitCount > m_maxTotalUnitCount)
        {
            m_maxTotalUnitCount = m_totalUnitCount;
        }

        if (m_health > m_maxHealth)
        {
            m_maxHealth = m_health;
        }

        if (m_totalResourceUnits > m_maxTotalResourceUnits)
        {
            m_maxTotalResourceUnits = 0;
        }

        if (m_minerNum > m_maxMinerNum)
        {
            m_maxMinerNum = m_minerNum;
        }

        if (m_advanceminerNum > m_maxAdvanceMinerNum)
        {
            m_maxAdvanceMinerNum = m_advanceminerNum;
        }

        if (m_mineNum > m_maxMinerNum)
        {
            m_maxMineNum = m_mineNum;
        }

        if (m_wallNum > m_maxWallNum)
        {
            m_maxWallNum = m_wallNum;
        }

        if (m_antiAirTurretNum > m_maxAntiAirTurretNum)
        {
            m_maxAntiAirTurretNum = m_antiAirTurretNum;
        }

        if (m_barrackNum > m_maxBarracksNum)
        {
            m_maxBarracksNum = m_barrackNum;
        }

        if (m_dragonPortalNum > m_maxDragonPortalNum)
        {
            m_maxDragonPortalNum = m_dragonPortalNum;
        }

        if (m_dragonWarriorNum > m_maxDragonWarriorNum)
        {
            m_maxDragonWarriorNum = m_dragonWarriorNum;
        }

        if (m_dragonTankNum > m_maxDragonTankNum)
        {
            m_maxDragonTankNum = m_dragonTankNum;
        }

        if (m_dragonNum > m_maxDragonNum)
        {
            m_maxDragonNum = m_dragonNum;
        }
    }

    public int GetGold()
    {
        return m_gold;
    }

    public void ReduceGold(int amount)
    {
        m_gold -= amount;
    }

    public void AddGold(int amount)
    {
        m_gold += amount;
    }

    public int GetShards()
    {
        return m_shards;
    }

    public void ReduceShards(int amount)
    {
        m_shards -= amount;
    }

    public void AddShards(int amount)
    {
        m_shards += amount;
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
        return m_advanceminerNum;
    }

    public void ReduceAdvanceMinerNumber(int amount)
    {
        m_advanceminerNum -= amount;
    }

    public void AddAdvanceMinerNumber(int amount)
    {
        m_advanceminerNum += amount;
    }

    public int GetBarracksNumber()
    {
        return m_barrackNum;
    }

    public void ReduceBarracksNumber(int amount)
    {
        m_barrackNum -= amount;
    }

    public void AddBarracksNumber(int amount)
    {
        m_barrackNum += amount;
    }

    public int GetDragonPortalNumber()
    {
        return m_dragonPortalNum;
    }

    public void ReduceDragonPortalNumber(int amount)
    {
        m_dragonPortalNum -= amount;
    }

    public void AddDragonPortalNumber(int amount)
    {
        m_dragonPortalNum += amount;
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

    public int GetMineNumber()
    {
        return m_mineNum;
    }

    public void ReduceMineNumber(int amount)
    {
        m_mineNum -= amount;
    }

    public void AddMineNumber(int amount)
    {
        m_mineNum += amount;
    }

    public List<GameItem> GetEnemyUnits()
    {
        return m_enemyUnits;
    }

    public int GetHealth()
    {
        return m_health;
    }

    public void ReduceHealth(int amount)
    {
        m_health -= amount;
    }

    public void AddHealth(int amount)
    {
        m_health += amount;
    }

    public float GetClosenessToWinGoal()
    {
        return m_closenessToWinGoal;
    }

    public float GetClosenessToShardGoal()
    {
        return m_closenessToShardGoal;
    }

    public float GetClosenessToGoldGoal()
    {
        return m_closenessToGoldGoal;
    }
    
    public int GetTotalUnitCount()
    {
        return m_totalUnitCount;
    }

    public int GetTotalResourceUnits()
    {
        return m_totalResourceUnits;
    }

    public int GetDragonWarriorsDestroyed()
    {
        return m_dragonWarriorsDestroyed;
    }

    public int GetDragonTanksDestroyed()
    {
        return m_dragonTanksDestroyed;
    }

    public int GetDragonsDestroyed()
    {
        return m_dragonsDestroyed;
    }

    public float GetMaxClosenessToWinGoal()
    {
        return m_maxClosenessToWinGoal;
    }

    public int GetMaxGold()
    {
        return m_maxGold;
    }

    public int GetMaxShard()
    {
        return m_maxShard;
    }

    public int GetMaxTotalUnitCount()
    {
        return m_maxTotalUnitCount;
    }

    public int GetMaxHealth()
    {
        return m_maxHealth;
    }

    public int GetMaxTotalResourceUnits()
    {
        return m_maxTotalResourceUnits;
    }

    public int GetMaxMinerNum()
    {
        return m_maxMinerNum;
    }

    public int GetMaxAdvanceMinerNum()
    {
        return m_maxAdvanceMinerNum;
    }

    public int GetMaxMineNum()
    {
        return m_maxMineNum;
    }

    public int GetMaxWallNum()
    {
        return m_maxWallNum;
    }

    public int GetMaxAntiAirTurretNum()
    {
        return m_maxAntiAirTurretNum;
    }

    public int GetMaxBarracksNum()
    {
        return m_maxBarracksNum;
    }

    public int GetMaxDragonPortalNum()
    {
        return m_maxDragonPortalNum;
    }

    public int GetMaxDragonWarriorNum()
    {
        return m_maxDragonWarriorNum;
    }

    public int GetMaxDragonTankNum()
    {
        return m_maxDragonTankNum;
    }

    public int GetMaxDragonNum()
    {
        return m_maxDragonNum;
    }
}
