using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Enemy : MonoBehaviour
{
    
    public GameManager gameManager;//the game manager
    public WinningGoalsManager winningGoalManager;
    
    public int m_gold = 0;
    public int m_shards = 0;
    public int m_dragonWarriorNum = 0;
    public int m_dragonTankNum = 0;
    public int m_dragonNum = 0;
    public int m_minerNum = 0;
    public int m_advanceminerNum = 0;
    public int m_barrackNum = 0;
    public int m_dragonPortalNum = 0;
    public int m_wallNum = 0;
    public int m_antiAirTurretNum = 0;
    public int m_mineNum = 0;
    [HideInInspector]
    public int m_health = 0;
    [HideInInspector]
    public List<GameItem> m_enemyUnits = new List<GameItem>();
    [HideInInspector]
    public float m_closenessToWinGoal = 0;
    [HideInInspector]
    public float m_closenessToShardGoal;
    [HideInInspector]
    public float m_closenessToGoldGoal;
    [HideInInspector]
    public int m_totalUnitCount = 0;
    [HideInInspector]
    public int m_totalResourceUnits = 0;
    [HideInInspector]
    public int m_dragonWarriorsDestroyed = 0;
    [HideInInspector]
    public int m_dragonTanksDestroyed = 0;
    [HideInInspector]
    public int m_dragonsDestroyed = 0;
    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        m_closenessToGoldGoal = m_gold / winningGoalManager.goldNeeded;
        m_closenessToShardGoal = m_shards / winningGoalManager.shardsNeeded;
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
            if (unitDamage > m_enemyUnits[index].health)
            {
                unitDamage -= m_enemyUnits[index].health;
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
                m_enemyUnits[index].health -= unitDamage;
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
        { return item.objectName == "dragonWarrior"; });
        int lastTank = m_enemyUnits.FindLastIndex((GameItem item) =>
        { return item.objectName == "dragonTank"; });

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
                                { return item.objectName == "dragon"; });
            if (dragonDamage > m_enemyUnits[lastDragon].health)
            {
                dragonDamage -= m_enemyUnits[lastDragon].health;
                DestroyLastDragon(lastDragon);
            }
            else
            {
                m_enemyUnits[lastDragon].health -= dragonDamage;
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
            int lastMine = m_enemyUnits.FindLastIndex((GameItem item) => { return item.objectName == "mines";});

            if(lastMine > -1)
            {
                m_enemyUnits.RemoveAt(lastMine);
                m_mineNum--;
            }
        }
    }
}
