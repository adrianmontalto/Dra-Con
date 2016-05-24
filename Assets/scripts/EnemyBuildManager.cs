using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBuildManager : MonoBehaviour
{
    public Enemy enemy;
    public Player player;
    public GameManager gameManager;
    public GameItemList gameItemList;
    public EnemyUnitBuilder unitBuilder;

    public int m_maxBuildNumber;
    [HideInInspector]
    public bool m_isActive = false;
    //values for the utility scores
    private UtilityValue m_buildResources;
    private UtilityValue m_buildMiners;
    private UtilityValue m_buildAdvanceMiners;
    private UtilityValue m_buildDefenses;
    private UtilityValue m_buildMines;
    private UtilityValue m_buildWalls;
    private UtilityValue m_buildAntiAirTurrets;
    private UtilityValue m_buildBuildings;
    private UtilityValue m_buildBarracks;
    private UtilityValue m_buildPortals;
    private UtilityValue m_buildUnits;
    private UtilityValue m_buildDragonWarriors;
    private UtilityValue m_buildDragonTanks;
    private UtilityValue m_buildDragon;
    //

    //lists to store all the enemies decisions
    [HideInInspector]
    public Dictionary<string, UtilityScore> m_utilityScoreMap = new Dictionary<string, UtilityScore>();
    [HideInInspector]
    public Dictionary<string, UtilityScore> m_resourceUtilittScoreMap = new Dictionary<string,UtilityScore>();
    [HideInInspector]
    public Dictionary<string, UtilityScore> m_defenseUtilityScoreMap = new Dictionary<string, UtilityScore>();
    [HideInInspector]
    public Dictionary<string, UtilityScore> m_buildUtilityScoreMap = new Dictionary<string, UtilityScore>();
    [HideInInspector]
    public Dictionary<string, UtilityScore> m_unitUtilityScoreMap = new Dictionary<string, UtilityScore>();
    //

    // Use this for initialization
    void Start ()
    {
        InitValues();
        SetUtilityScores();
        SetResourceScores();
        SetBuildScores();
        SetDefenseScores();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void InitValues()
    {
        m_buildResources = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.m_maxTotalResourceUnits);
        m_buildResources.SetValue(enemy.m_totalResourceUnits);

        m_buildMiners = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.m_maxMinerNum);
        m_buildMiners.SetValue(enemy.m_minerNum);
        
        m_buildAdvanceMiners = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.m_maxAdvanceMinerNum);
        m_buildAdvanceMiners.SetValue(enemy.m_advanceminerNum);

        m_buildDefenses = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,player.m_maxUnitNumber);
        m_buildDefenses.SetValue(player.m_unitNumber);

        m_buildMines = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.m_maxMineNum);
        m_buildMines.SetValue(enemy.m_mineNum);

        m_buildWalls = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.m_maxWallNUm);
        m_buildWalls.SetValue(enemy.m_wallNum);

        m_buildAntiAirTurrets = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.m_maxAntiAirTurretNum);
        m_buildAntiAirTurrets.SetValue(enemy.m_antiAirTurretNum);

        m_buildBuildings = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.m_maxHealth);
        m_buildBuildings.SetValue(enemy.m_health);

        m_buildBarracks = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.m_maxBarracksNum);
        m_buildBarracks.SetValue(enemy.m_barrackNum);

        m_buildPortals = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.m_maxDragonPortalNum);
        m_buildPortals.SetValue(enemy.m_dragonPortalNum);

        m_buildUnits = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.m_maxTotalUnitCount);
        m_buildUnits.SetValue(enemy.m_totalUnitCount);

        m_buildDragonWarriors = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.m_maxDragonWarriorNum);
        m_buildDragonWarriors.SetValue(enemy.m_dragonWarriorNum);

        m_buildDragonTanks = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.m_maxDragonTankNum);
        m_buildDragonTanks.SetValue(enemy.m_dragonTankNum);

        m_buildDragon = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.m_maxDragonNum);
        m_buildDragon.SetValue(enemy.m_dragonNum);
    }

    void SetValues()
    {
        m_buildResources.SetMinMaxValue(0, enemy.m_maxTotalResourceUnits);
        m_buildResources.SetValue(enemy.m_totalResourceUnits);
        m_buildDefenses.SetMinMaxValue(0, player.m_maxUnitNumber);
        m_buildDefenses.SetValue(player.m_unitNumber);
        m_buildBuildings.SetMinMaxValue(0, enemy.m_maxHealth);
        m_buildBuildings.SetValue(enemy.m_health);
        m_buildUnits.SetMinMaxValue(0, enemy.m_maxTotalUnitCount);
        m_buildUnits.SetValue(enemy.m_totalUnitCount);
    }

    void SetResourceValues()
    {
        m_buildMiners.SetMinMaxValue(0, enemy.m_maxMinerNum);
        m_buildMiners.SetValue(enemy.m_minerNum);
        m_buildAdvanceMiners.SetMinMaxValue(0, enemy.m_maxAdvanceMinerNum);
        m_buildAdvanceMiners.SetValue(enemy.m_advanceminerNum);
    }

    void SetDefenseValues()
    {
        m_buildMines.SetMinMaxValue(0, enemy.m_maxMineNum);
        m_buildMines.SetValue(enemy.m_mineNum);
        m_buildWalls.SetMinMaxValue(0, enemy.m_maxWallNUm);
        m_buildWalls.SetValue(enemy.m_wallNum);
        m_buildAntiAirTurrets.SetMinMaxValue(0, enemy.m_maxAntiAirTurretNum);
        m_buildAntiAirTurrets.SetValue(enemy.m_antiAirTurretNum);
    }

    void SetBuildingsValues()
    {
        m_buildBarracks.SetMinMaxValue(0, enemy.m_maxBarracksNum); 
        m_buildBarracks.SetValue(enemy.m_barrackNum);

        m_buildPortals.SetMinMaxValue(0, enemy.m_maxDragonPortalNum);
        m_buildPortals.SetValue(enemy.m_dragonPortalNum);
    }

    void SetUnitsValues()
    {
        m_buildDragonWarriors.SetMinMaxValue(0, enemy.m_maxDragonWarriorNum);
        m_buildDragonWarriors.SetValue(enemy.m_dragonWarriorNum);

        m_buildDragonTanks.SetMinMaxValue(0, enemy.m_maxDragonTankNum);
        m_buildDragonTanks.SetValue(enemy.m_dragonTankNum);

        m_buildDragon.SetMinMaxValue(0, enemy.m_maxDragonNum);
        m_buildDragon.SetValue(enemy.m_dragonNum);
    }

    void SetUtilityScores()
    {
        UtilityScore buildResourceScore = new UtilityScore();
        buildResourceScore.AddUtilityValue(m_buildResources, 1.0f);
        m_utilityScoreMap.Add("buildResource", buildResourceScore);

        UtilityScore buildUnitScore = new UtilityScore();
        buildUnitScore.AddUtilityValue(m_buildUnits, 1.0f);
        m_utilityScoreMap.Add("buildUnit",buildUnitScore);

        UtilityScore buildDefenseScore = new UtilityScore();
        buildDefenseScore.AddUtilityValue(m_buildDefenses,1.0f);
        m_utilityScoreMap.Add("buildDefense",buildDefenseScore);

        UtilityScore buildBuildingScore = new UtilityScore();
        buildBuildingScore.AddUtilityValue(m_buildBuildings,1.0f);
        m_utilityScoreMap.Add("buildBuilding", buildBuildingScore);
    }

    void SetResourceScores()
    {
        UtilityScore buildMinerScore = new UtilityScore();
        buildMinerScore.AddUtilityValue(m_buildMiners, 1.0f);
        m_resourceUtilittScoreMap.Add("buildMiner",buildMinerScore);

        UtilityScore buildAdvancedMinerScore = new UtilityScore();
        buildAdvancedMinerScore.AddUtilityValue(m_buildAdvanceMiners, 1.0f);
        m_resourceUtilittScoreMap.Add("buildAdvancedMiner",buildAdvancedMinerScore);
    }

    void SetBuildScores()
    {
        UtilityScore buildBarracksScore = new UtilityScore();
        buildBarracksScore.AddUtilityValue(m_buildBarracks, 1.0f);
        m_buildUtilityScoreMap.Add("barrack",buildBarracksScore);

        UtilityScore buildDragonPortalScore = new UtilityScore();
        buildDragonPortalScore.AddUtilityValue(m_buildPortals,1.0f);
        m_buildUtilityScoreMap.Add("portal",buildDragonPortalScore);
    }

    void SetDefenseScores()
    {
        UtilityScore buildMinesScore = new UtilityScore();
        buildMinesScore.AddUtilityValue(m_buildMines, 1.0f);
        m_defenseUtilityScoreMap.Add("mine", buildMinesScore);

        UtilityScore buildWallScore = new UtilityScore();
        buildWallScore.AddUtilityValue(m_buildWalls, 1.0f);
        m_defenseUtilityScoreMap.Add("wall",buildWallScore);

        UtilityScore buildTurretScore = new UtilityScore();
        buildTurretScore.AddUtilityValue(m_buildAntiAirTurrets,1.0f);
        m_defenseUtilityScoreMap.Add("turret",buildTurretScore);
    }

    void SetUnitScores()
    {
        UtilityScore dragonWarriorScore = new UtilityScore();
        dragonWarriorScore.AddUtilityValue(m_buildDragonWarriors,1.0f);
        m_unitUtilityScoreMap.Add("dragonWarrior", dragonWarriorScore);

        UtilityScore dragonTankScore = new UtilityScore();
        dragonTankScore.AddUtilityValue(m_buildDragonTanks, 1.0f);
        m_unitUtilityScoreMap.Add("dragonTank",dragonTankScore);

        UtilityScore dragonScore = new UtilityScore();
        dragonScore.AddUtilityValue(m_buildDragon,1.0f);
        m_unitUtilityScoreMap.Add("dragon",dragonScore);
    }

    public void SelectAction()
    {
        SetValues();

        float bestScore = -1.0f;
        string strBestAction = "";

        foreach(KeyValuePair<string,UtilityScore> score in m_utilityScoreMap)
        {
            float thisScore = score.Value.GetUtilityScore();
            if(thisScore > bestScore)
            {
                bestScore = thisScore;
                strBestAction = score.Key;
            }
        }

        if(strBestAction == "buildResource")
        {
            Debug.Log("build:build resources");
            SelectResourceAction();            
        }

        if(strBestAction == "buildUnit")
        {
            Debug.Log("build:build unit");
            SelectUnitAction();            
        }

        if(strBestAction == "buildDefense")
        {
            Debug.Log("build: build defense");
            SelectDefenseAction();            
        }

        if(strBestAction == "buildBuilding")
        {
            Debug.Log("build: build building");
            SelectBuildingAction();            
        }
    }

    void SelectResourceAction()
    {
        SetResourceValues();

        float bestScore = -1.0f;
        string strBestAction = "";

        foreach(KeyValuePair<string,UtilityScore> score in m_resourceUtilittScoreMap)
        {
            float thisScore = score.Value.GetUtilityScore();
            if(thisScore > bestScore)
            {
                bestScore = thisScore;
                strBestAction = score.Key;
            }
        }

        if(strBestAction == "buildMiner")
        {
            Debug.Log("build: build miner");
            BuildMiner();            
        }

        if(strBestAction == "buildAdvanceMiner")
        {
            Debug.Log("build: build advance miner");
            BuildAdvanceMiner();            
        }
    }

    void SelectUnitAction()
    {
        SetUnitsValues();

        float bestScore = -1.0f;
        string strBestAction = "";

        foreach (KeyValuePair<string, UtilityScore> score in m_unitUtilityScoreMap)
        {
            float thisScore = score.Value.GetUtilityScore();
            if (thisScore > bestScore)
            {
                bestScore = thisScore;
                strBestAction = score.Key;
            }
        }   

        if(strBestAction == "dragonWarrior")
        {
            Debug.Log("build:build dragon warrior");
            BuildDragonWarrior();            
        }

        if(strBestAction == "dragonTank")
        {
            Debug.Log("build:build dragon Tank");
            BuildDragonTank();            
        }

        if(strBestAction == "dragon")
        {
            Debug.Log("build: build dragon");
            BuildDragon();            
        }
    }

    void SelectDefenseAction()
    {
        SetDefenseValues();

        float bestScore = -1.0f;
        string strBestAction = "";

        foreach (KeyValuePair<string, UtilityScore> score in m_defenseUtilityScoreMap)
        {
            float thisScore = score.Value.GetUtilityScore();
            if (thisScore > bestScore)
            {
                bestScore = thisScore;
                strBestAction = score.Key;
            }
        }

        if(strBestAction == "mine")
        {
            Debug.Log("build: build mine");
            BuildMines();            
        }

        if(strBestAction == "wall")
        {
            Debug.Log("build: build wall");
            BuildWalls();            
        }

        if(strBestAction == "turret")
        {
            Debug.Log("build: build turret");
            BuildTurret();            
        }
    }

    void SelectBuildingAction()
    {
        SetBuildingsValues();

        float bestScore = -1.0f;
        string strBestAction = "";

        foreach (KeyValuePair<string, UtilityScore> score in m_buildUtilityScoreMap)
        {
            float thisScore = score.Value.GetUtilityScore();
            if (thisScore > bestScore)
            {
                bestScore = thisScore;
                strBestAction = score.Key;
            }
        }

        if(strBestAction == "barrack")
        {
            Debug.Log("build: build barrack");
            BuildBarracks();            
        }

        if(strBestAction == "portal")
        {
            Debug.Log("build: build portal");
            BuildDragonPortal();            
        }
    }

    void BuildMiner()
    {
        int totalGoldCost = gameItemList.miner.goldCost * m_maxBuildNumber;
        int totalShardCost = gameItemList.miner.shardCost * m_maxBuildNumber;
        int goldAmount = enemy.m_gold;
        int shardAmount = enemy.m_shards;

        if(totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for(int i = 0;i < m_maxBuildNumber;++i)
            {
                unitBuilder.m_minerNum ++;
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;

            while(canBuild == true)
            {
                if((totalGoldCost + gameItemList.miner.goldCost) < enemy.m_gold)
                {
                    
                    if((totalShardCost + gameItemList.miner.shardCost) < enemy.m_shards)
                    {
                        totalGoldCost += gameItemList.miner.goldCost;
                        totalShardCost += gameItemList.miner.shardCost;
                        unitBuilder.m_minerNum++;
                    }
                    else
                    {
                        canBuild = false;
                    }
                }
                else
                {
                    canBuild = false;
                }                
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
    }

    void BuildAdvanceMiner()
    {
        int totalGoldCost = gameItemList.advanceMiner.goldCost * m_maxBuildNumber;
        int totalShardCost = gameItemList.advanceMiner.shardCost * m_maxBuildNumber;
        int goldAmount = enemy.m_gold;
        int shardAmount = enemy.m_shards;

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.m_advanceMinerNum++;
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.advanceMiner.goldCost) < enemy.m_gold)
                {

                    if ((totalShardCost + gameItemList.advanceMiner.shardCost) < enemy.m_shards)
                    {
                        totalGoldCost += gameItemList.advanceMiner.goldCost;
                        totalShardCost += gameItemList.advanceMiner.shardCost;
                        unitBuilder.m_advanceMinerNum++;
                    }
                    else
                    {
                        canBuild = false;
                    }
                }
                else
                {
                    canBuild = false;
                }
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
    }

    void BuildDragonWarrior()
    {
        int totalGoldCost = gameItemList.dragonWarrior.goldCost * m_maxBuildNumber;
        int totalShardCost = gameItemList.dragonWarrior.shardCost * m_maxBuildNumber;
        int goldAmount = enemy.m_gold;
        int shardAmount = enemy.m_shards;

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.m_dragonWarriorNum++;
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.dragonWarrior.goldCost) < enemy.m_gold)
                {

                    if ((totalShardCost + gameItemList.dragonWarrior.shardCost) < enemy.m_shards)
                    {
                        totalGoldCost += gameItemList.dragonWarrior.goldCost;
                        totalShardCost += gameItemList.dragonWarrior.shardCost;
                        unitBuilder.m_dragonWarriorNum++;
                    }
                    else
                    {
                        canBuild = false;
                    }
                }
                else
                {
                    canBuild = false;
                }
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
    }

    void BuildDragonTank()
    {
        int totalGoldCost = gameItemList.dragonTank.goldCost * m_maxBuildNumber;
        int totalShardCost = gameItemList.dragonTank.shardCost * m_maxBuildNumber;
        int goldAmount = enemy.m_gold;
        int shardAmount = enemy.m_shards;

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.m_dragonTankNum++;
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.dragonTank.goldCost) < enemy.m_gold)
                {

                    if ((totalShardCost + gameItemList.dragonTank.shardCost) < enemy.m_shards)
                    {
                        totalGoldCost += gameItemList.dragonTank.goldCost;
                        totalShardCost += gameItemList.dragonTank.shardCost;
                        unitBuilder.m_dragonTankNum++;
                    }
                    else
                    {
                        canBuild = false;
                    }
                }
                else
                {
                    canBuild = false;
                }
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
    }

    void BuildDragon()
    {
        int totalGoldCost = gameItemList.dragon.goldCost * m_maxBuildNumber;
        int totalShardCost = gameItemList.dragon.shardCost * m_maxBuildNumber;
        int goldAmount = enemy.m_gold;
        int shardAmount = enemy.m_shards;

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.m_dragonNum++;
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.dragon.goldCost) < enemy.m_gold)
                {

                    if ((totalShardCost + gameItemList.dragon.shardCost) < enemy.m_shards)
                    {
                        totalGoldCost += gameItemList.dragon.goldCost;
                        totalShardCost += gameItemList.dragon.shardCost;
                        unitBuilder.m_dragonNum++;
                    }
                    else
                    {
                        canBuild = false;
                    }
                }
                else
                {
                    canBuild = false;
                }
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
    }

    void BuildBarracks()
    {
        int totalGoldCost = gameItemList.barracks.goldCost * m_maxBuildNumber;
        int totalShardCost = gameItemList.barracks.shardCost * m_maxBuildNumber;
        int goldAmount = enemy.m_gold;
        int shardAmount = enemy.m_shards;

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.m_barracksNum++;
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.barracks.goldCost) < enemy.m_gold)
                {

                    if ((totalShardCost + gameItemList.barracks.shardCost) < enemy.m_shards)
                    {
                        totalGoldCost += gameItemList.barracks.goldCost;
                        totalShardCost += gameItemList.barracks.shardCost;
                        unitBuilder.m_barracksNum++;
                    }
                    else
                    {
                        canBuild = false;
                    }
                }
                else
                {
                    canBuild = false;
                }
            }
            unitBuilder.AddEnemyBuildings();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
    }

    void BuildDragonPortal()
    {
        int totalGoldCost = gameItemList.dragonPortal.goldCost * m_maxBuildNumber;
        int totalShardCost = gameItemList.dragonPortal.shardCost * m_maxBuildNumber;
        int goldAmount = enemy.m_gold;
        int shardAmount = enemy.m_shards;

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.m_dragonPortalsNum++;
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.dragonPortal.goldCost) < enemy.m_gold)
                {

                    if ((totalShardCost + gameItemList.dragonPortal.shardCost) < enemy.m_shards)
                    {
                        totalGoldCost += gameItemList.dragonPortal.goldCost;
                        totalShardCost += gameItemList.dragonPortal.shardCost;
                        unitBuilder.m_dragonPortalsNum++;
                    }
                    else
                    {
                        canBuild = false;
                    }
                }
                else
                {
                    canBuild = false;
                }
            }
            unitBuilder.AddEnemyBuildings();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
    }

    void BuildMines()
    {
        int totalGoldCost = gameItemList.mine.goldCost * m_maxBuildNumber;
        int totalShardCost = gameItemList.mine.shardCost * m_maxBuildNumber;
        int goldAmount = enemy.m_gold;
        int shardAmount = enemy.m_shards;

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.m_minesNum++;
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.mine.goldCost) < enemy.m_gold)
                {
                    if ((totalShardCost + gameItemList.mine.shardCost) < enemy.m_shards)
                    {
                        totalGoldCost += gameItemList.mine.goldCost;
                        totalShardCost += gameItemList.mine.shardCost;
                        unitBuilder.m_minesNum++;
                    }
                    else
                    {
                        canBuild = false;
                    }
                }
                else
                {
                    canBuild = false;
                }
            }
            unitBuilder.AddEnemyBuildings();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
    }

    void BuildWalls()
    {
        int totalGoldCost = gameItemList.wall.goldCost * m_maxBuildNumber;
        int totalShardCost = gameItemList.wall.shardCost * m_maxBuildNumber;
        int goldAmount = enemy.m_gold;
        int shardAmount = enemy.m_shards;

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.m_wallNum++;
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.wall.goldCost) < enemy.m_gold)
                {

                    if ((totalShardCost + gameItemList.wall.shardCost) < enemy.m_shards)
                    {
                        totalGoldCost += gameItemList.wall.goldCost;
                        totalShardCost += gameItemList.wall.shardCost;
                        unitBuilder.m_wallNum++;
                    }
                    else
                    {
                        canBuild = false;
                    }
                }
                else
                {
                    canBuild = false;
                }
            }
            unitBuilder.AddEnemyBuildings();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
    }

    void BuildTurret()
    {
        int totalGoldCost = gameItemList.antiAirTurret.goldCost * m_maxBuildNumber;
        int totalShardCost = gameItemList.antiAirTurret.shardCost * m_maxBuildNumber;
        int goldAmount = enemy.m_gold;
        int shardAmount = enemy.m_shards;

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.m_antiAirTurretNum++;
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.antiAirTurret.goldCost) < enemy.m_gold)
                {

                    if ((totalShardCost + gameItemList.antiAirTurret.shardCost) < enemy.m_shards)
                    {
                        totalGoldCost += gameItemList.antiAirTurret.goldCost;
                        totalShardCost += gameItemList.antiAirTurret.shardCost;
                        unitBuilder.m_antiAirTurretNum++;
                    }
                    else
                    {
                        canBuild = false;
                    }
                }
                else
                {
                    canBuild = false;
                }
            }
            unitBuilder.AddEnemyBuildings();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
        }
    }
}
