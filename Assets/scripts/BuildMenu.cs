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
   
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameItemList gameItemList;
    [SerializeField]
    private GameObject initImage;
    [SerializeField]
    private GameObject previousImage;

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
            GameItem playerBuilding = gameItemList.barracks.gameObject.GetComponent<GameItem>();
            player.m_gold -= gameItemList.barracks.goldCost;
            player.m_shards -= gameItemList.barracks.shardCost;
            player.m_barrackNum ++;
            player.m_playerUnits.Add(playerBuilding);
            player.m_health += gameItemList.barracks.health;
        }

        for (int i = 0; i < m_dragonPortalsNum; ++i)
        {
            GameItem playerBuilding = gameItemList.dragonPortal.gameObject.GetComponent<GameItem>();
            player.m_gold -= gameItemList.dragonPortal.goldCost;
            player.m_shards -= gameItemList.dragonPortal.shardCost;
            player.m_dragonPortalNum ++;
            player.m_playerUnits.Add(playerBuilding);
            player.m_health += gameItemList.dragonPortal.health;
        }

        for (int i = 0; i < m_antiAirTurretNum; ++i)
        {
            GameItem playerBuilding = gameItemList.antiAirTurret.gameObject.GetComponent<GameItem>();
            player.m_gold -= gameItemList.antiAirTurret.goldCost;
            player.m_shards -= gameItemList.antiAirTurret.shardCost;
            player.m_antiAirTurretNum ++;
            player.m_playerUnits.Add(playerBuilding);
            player.m_health += gameItemList.antiAirTurret.health;
        }

        for (int i = 0; i < m_wallNum; ++i)
        {
            GameItem playerBuilding = gameItemList.wall.gameObject.GetComponent<GameItem>();
            player.m_gold -= gameItemList.wall.goldCost;
            player.m_shards -= gameItemList.wall.shardCost;
            player.m_wallNum ++;
            player.m_playerUnits.Add(playerBuilding);
            player.m_health += gameItemList.wall.health;
        }

        for (int i = 0; i < m_minesNum; ++i)
        {
            GameItem playerBuilding = gameItemList.mine.gameObject.GetComponent<GameItem>();
            player.m_gold -= gameItemList.mine.goldCost;
            player.m_shards -= gameItemList.mine.shardCost;
            player.m_mineNum ++;
            player.m_playerUnits.Add(playerBuilding);
            player.m_health += gameItemList.mine.health;
        }
    }

    public void AddPlayerUnits()
    {
        for (int i = 0; i < m_minerNum; ++i)
        {
            GameItem playerUnits = gameItemList.miner.gameObject.GetComponent<GameItem>();
            player.m_gold -= gameItemList.miner.goldCost;
            player.m_shards -= gameItemList.miner.shardCost;
            player.m_minerNum ++;
            player.m_playerUnits.Add(playerUnits);
            player.m_health += gameItemList.miner.health;
        }

        for (int i = 0; i < m_advanceMinerNum; ++i)
        {
            GameItem playerUnits = gameItemList.advanceMiner.gameObject.GetComponent<GameItem>();
            player.m_gold -= gameItemList.advanceMiner.goldCost;
            player.m_shards -= gameItemList.advanceMiner.shardCost;
            player.m_advanceminerNum ++;
            player.m_playerUnits.Add(playerUnits);
            player.m_health += gameItemList.advanceMiner.health;
        }

        for (int i = 0; i < m_dragonWarriorNum; ++i)
        {
            GameItem playerUnits = gameItemList.dragonWarrior.gameObject.GetComponent<GameItem>();
            player.m_gold -= gameItemList.dragonWarrior.goldCost;
            player.m_shards -= gameItemList.dragonWarrior.shardCost;
            player.m_dragonWarriorNum ++;
            player.m_playerUnits.Add(playerUnits);
            player.m_health += gameItemList.dragonWarrior.health;
        }

        for (int i = 0; i < m_dragonTankNum; ++i)
        {
            GameItem playerUnits = gameItemList.dragonTank.gameObject.GetComponent<GameItem>();
            player.m_gold -= gameItemList.dragonTank.goldCost;
            player.m_shards -= gameItemList.dragonTank.shardCost;
            player.m_dragonTankNum ++;
            player.m_playerUnits.Add(playerUnits);
            player.m_health += gameItemList.dragonTank.health;
        }

        for (int i = 0; i < m_dragonNum; ++i)
        {
            GameItem playerUnits = gameItemList.dragon.gameObject.GetComponent<GameItem>();
            player.m_dragonNum ++;
            player.m_gold -= gameItemList.dragon.goldCost;
            player.m_shards -= gameItemList.dragon.shardCost;
            player.m_playerUnits.Add(playerUnits);
            player.m_health += gameItemList.dragon.health;
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
