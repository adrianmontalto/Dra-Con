using UnityEngine;
using System.Collections;

public class BuildMenu : MonoBehaviour
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
    private Player m_player;
    [SerializeField]
    private GameItemList m_gameItemList;
    [SerializeField]
    private GameObject m_initImage;
    [SerializeField]
    private GameObject m_previousImage;

    // Use this for initialization
    void Start ()
    {
        m_previousImage = m_initImage;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void AddPlayerBuildings()
    {
        for(int i = 0; i < m_barracksNum; ++i)
        {
            GameItem playerBuilding = m_gameItemList.GetBarracks().gameObject.GetComponent<GameItem>();
            m_player.ReduceGold(m_gameItemList.GetBarracks().GetGoldCost());
            m_player.ReduceShards(m_gameItemList.GetBarracks().GetShardCost());
            m_player.AddBarracksNumber(1);
            m_player.GetPlayerUnitsList().Add(playerBuilding);
            m_player.AddHealth(m_gameItemList.GetBarracks().GetHealth());
        }

        for (int i = 0; i < m_dragonPortalsNum; ++i)
        {
            GameItem playerBuilding = m_gameItemList.GetDragonPortal().gameObject.GetComponent<GameItem>();
            m_player.ReduceGold(m_gameItemList.GetDragonPortal().GetGoldCost());
            m_player.ReduceShards(m_gameItemList.GetDragonPortal().GetShardCost());
            m_player.AddDragonPortalNumber(1);
            m_player.GetPlayerUnitsList().Add(playerBuilding);
            m_player.AddHealth(m_gameItemList.GetDragonPortal().GetHealth());
        }

        for (int i = 0; i < m_antiAirTurretNum; ++i)
        {
            GameItem playerBuilding = m_gameItemList.GetAntiAirTurret().gameObject.GetComponent<GameItem>();
            m_player.ReduceGold(m_gameItemList.GetAntiAirTurret().GetGoldCost());
            m_player.ReduceShards(m_gameItemList.GetAntiAirTurret().GetShardCost());
            m_player.AddAntiAirTurretNumber(1);
            m_player.GetPlayerUnitsList().Add(playerBuilding);
            m_player.AddHealth(m_gameItemList.GetAntiAirTurret().GetHealth());
        }

        for (int i = 0; i < m_wallNum; ++i)
        {
            GameItem playerBuilding = m_gameItemList.GetWall().gameObject.GetComponent<GameItem>();
            m_player.ReduceGold(m_gameItemList.GetWall().GetGoldCost());
            m_player.ReduceShards(m_gameItemList.GetWall().GetShardCost());
            m_player.AddWallNumber(1);
            m_player.GetPlayerUnitsList().Add(playerBuilding);
            m_player.AddHealth(m_gameItemList.GetWall().GetHealth());
        }

        for (int i = 0; i < m_minesNum; ++i)
        {
            GameItem playerBuilding = m_gameItemList.GetMine().gameObject.GetComponent<GameItem>();
            m_player.ReduceGold(m_gameItemList.GetMine().GetGoldCost());
            m_player.ReduceShards(m_gameItemList.GetMine().GetShardCost());
            m_player.AddMineNumber(1);
            m_player.GetPlayerUnitsList().Add(playerBuilding);
            m_player.AddHealth(m_gameItemList.GetMine().GetHealth());
        }
    }

    public void AddPlayerUnits()
    {
        for (int i = 0; i < m_minerNum; ++i)
        {
            GameItem playerUnits = m_gameItemList.GetMiner().gameObject.GetComponent<GameItem>();
            m_player.ReduceGold(m_gameItemList.GetMiner().GetGoldCost());
            m_player.ReduceShards(m_gameItemList.GetMiner().GetShardCost());
            m_player.AddMinerNumber(1);
            m_player.GetPlayerUnitsList().Add(playerUnits);
            m_player.AddHealth(m_gameItemList.GetMiner().GetHealth());
        }

        for (int i = 0; i < m_advanceMinerNum; ++i)
        {
            GameItem playerUnits = m_gameItemList.GetAdvanceMiner().gameObject.GetComponent<GameItem>();
            m_player.ReduceGold(m_gameItemList.GetAdvanceMiner().GetGoldCost());
            m_player.ReduceShards(m_gameItemList.GetAdvanceMiner().GetShardCost());
            m_player.AddAdvanceMinerNumber(1);
            m_player.GetPlayerUnitsList().Add(playerUnits);
            m_player.AddHealth(m_gameItemList.GetAdvanceMiner().GetHealth());
        }

        for (int i = 0; i < m_dragonWarriorNum; ++i)
        {
            GameItem playerUnits = m_gameItemList.GetDragonWarrior().gameObject.GetComponent<GameItem>();
            m_player.ReduceGold(m_gameItemList.GetDragonWarrior().GetGoldCost());
            m_player.ReduceShards(m_gameItemList.GetDragonWarrior().GetShardCost());
            m_player.AddDragonWarriorNumber(1);
            m_player.GetPlayerUnitsList().Add(playerUnits);
            m_player.AddHealth(m_gameItemList.GetDragonWarrior().GetHealth());
        }

        for (int i = 0; i < m_dragonTankNum; ++i)
        {
            GameItem playerUnits = m_gameItemList.GetDragonTank().gameObject.GetComponent<GameItem>();
            m_player.ReduceGold(m_gameItemList.GetDragonTank().GetGoldCost());
            m_player.ReduceShards(m_gameItemList.GetDragonTank().GetShardCost());
            m_player.AddDragonTankNumber(1);
            m_player.GetPlayerUnitsList().Add(playerUnits);
            m_player.AddHealth(m_gameItemList.GetDragonTank().GetHealth());
        }

        for (int i = 0; i < m_dragonNum; ++i)
        {
            GameItem playerUnits = m_gameItemList.GetDragon().gameObject.GetComponent<GameItem>();
            m_player.ReduceGold(m_gameItemList.GetDragon().GetGoldCost());
            m_player.ReduceShards(m_gameItemList.GetDragon().GetShardCost());
            m_player.AddDragonNumber(1);
            m_player.GetPlayerUnitsList().Add(playerUnits);
            m_player.AddHealth(m_gameItemList.GetDragon().GetHealth());
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

    public Player GetPlayer()
    {
        return m_player;
    }

    public void SetPreviousImageActive(bool active)
    {
        m_previousImage.SetActive(active);
    }

    public void SetPreviousImage(GameObject image)
    {
        m_previousImage = image;
    }

    public GameItemList GetGameItemList()
    {
        return m_gameItemList;
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

    public int GetBarracksNumber()
    {
        return m_barracksNum;
    }

    public void ReduceBarracksNumber(int amount)
    {
        m_barracksNum -= amount;
    }

    public void AddBarracksNumber(int amount)
    {
        m_barracksNum += amount;
    }

    public int GetDragonPortalsNumber()
    {
        return m_dragonPortalsNum;
    }

    public void ReduceDragonPortalsNumber(int amount)
    {
        m_dragonPortalsNum -= amount;
    }

    public void AddDragonPortalsNumber(int amount)
    {
        m_dragonPortalsNum += amount;
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

    public int GetMinesNumber()
    {
        return m_minesNum;
    }

    public void ReduceMineNumber(int amount)
    {
        m_minesNum -= amount;
    }

    public void AddMineNumber(int amount)
    {
        m_minesNum += amount;
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
}
