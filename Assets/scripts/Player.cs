using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    private int m_health = 0;//players health
    [SerializeField]
    private int m_gold = 0;//players gold
    [SerializeField]
    private int m_shards = 0;//players shards
    [SerializeField]
    private int m_dragonWarriorNum = 0;//the number of dragon warriors the player has
    [SerializeField]
    private int m_dragonTankNum = 0;//the number of dragon tanks the player has
    [SerializeField]
    private int m_dragonNum = 0;//the number of dragons the player has
    [SerializeField]
    private int m_minerNum = 0;//the number of miners the player has
    [SerializeField]
    private int m_advanceminerNum = 0;//the number of advance miners the player has
    [SerializeField]
    private int m_barrackNum = 0;//the number of barracks the player has
    [SerializeField]
    private int m_dragonPortalNum = 0;//the number or dragon portals the player has
    [SerializeField]
    private int m_wallNum = 0;//the number of walls the player has
    [SerializeField]
    private int m_antiAirTurretNum = 0;//the number of anti air turrets the player has
    [SerializeField]
    private int m_mineNum = 0;//the number of mines the player has
    private List<GameItem> m_playerUnits = new List<GameItem>();//a list of all the players units and buildings
    private int m_unitNumber = 0;//the number of units the player has
    private int m_maxHealth = 0;
    private int m_maxUnitNumber = 0;
    // Use this for initialization
    void Start ()
    {
        SetMaxHealth();
        SetMaxUnitNumber();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //calculate the number of units the player has
        m_unitNumber = m_dragonWarriorNum + m_dragonTankNum + m_dragonNum + m_minerNum + m_advanceminerNum;
    }

    public void DestroyMines(int number)
    {
        for(int i = 0; i < number;++i)
        {
            int lastMine = m_playerUnits.FindLastIndex((GameItem item) => { return item.GetName() == "mines";});

            if(lastMine > -1)
            {
                m_playerUnits.RemoveAt(lastMine);
                m_mineNum--;
            }
        }
    }

    public void ReduceUnitNumber(string unitName)
    {
        if (unitName == "barracks")
        {
            m_barrackNum--;
        }

        if (unitName == "dragonPortal")
        {
            m_dragonPortalNum--;
        }

        if (unitName == "antiAirTurret")
        {
            m_antiAirTurretNum--;
        }

        if (unitName == "mine")
        {
            m_mineNum--;
        }

        if (unitName == "miner")
        {
            m_minerNum--;
        }

        if (unitName == "advanceMiner")
        {
            m_advanceminerNum--;
        }

        if (unitName == "dragonWarrior")
        {
            m_dragonWarriorNum--;
        }

        if (unitName == "dragonTank")
        {
            m_dragonTankNum--;
        }

        if (unitName == "dragon")
        {
            m_dragonNum--;
        }
    }

    public void DestroyGroundUnit(int damage)
    {
        int unitDamage = damage;
        while(unitDamage > 0)
        {
            int index = ChooseWhichUnitToDestroy();
            if(unitDamage > m_playerUnits[index].GetHealth())
            {
                unitDamage -= m_playerUnits[index].GetHealth();
                if(m_playerUnits[index].name == "dragonWarrior")
                {
                    DestroyLastDragonWarrior(index);
                }
                if(m_playerUnits[index].name == "dragonTank")
                {
                    DestroyLastDragonTank(index);
                }
            }
            else
            {
                m_playerUnits[index].ReduceHealth(unitDamage);
                unitDamage = 0;
            }
        }

    }

    void DestroyLastDragonWarrior(int index)
    {
        if(index > -1)
        {
            m_playerUnits.RemoveAt(index);
            m_dragonWarriorNum--;
        }
    }

    void DestroyLastDragonTank(int index)
    {
        m_playerUnits.RemoveAt(index);
        m_dragonTankNum --;
    }

    int ChooseWhichUnitToDestroy()
    {
        int lastWarrior = m_playerUnits.FindLastIndex((GameItem item) =>
                            { return item.GetName() == "dragonWarrior"; });
        int lastTank = m_playerUnits.FindLastIndex((GameItem)=> 
                            {return GameItem.GetName() == "dragonTank"; });

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
        while(dragonDamage > 0)
        {
            int lastDragon = m_playerUnits.FindLastIndex((GameItem item) =>
                                { return item.GetName() == "dragon"; });
            if(dragonDamage > m_playerUnits[lastDragon].GetHealth())
            {
                dragonDamage -= m_playerUnits[lastDragon].GetHealth();
                DestroyLastDragon(lastDragon);
            }
            else
            {
                m_playerUnits[lastDragon].ReduceHealth(dragonDamage);
                dragonDamage = 0;
            }
        }
    }

    void DestroyLastDragon(int index)
    {
        m_playerUnits.RemoveAt(index);
        m_dragonNum --;
    }

    public void SetMaxHealth()
    {
        if (m_health > m_maxHealth)
        {
            m_maxHealth = m_health;
        }
    }
    public void SetMaxUnitNumber()
    {
        if(m_unitNumber > m_maxUnitNumber)
        {
            m_maxUnitNumber = m_unitNumber;
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
    public List<GameItem> GetPlayerUnitsList()
    {
        return m_playerUnits;
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

    public int GetUnitNumber()
    {
        return m_unitNumber;
    }

    public int GetMaxHealth()
    {
        return m_maxHealth;
    }

    public int GetMaxUnitNumber()
    {
        return m_maxUnitNumber;
    }
}
