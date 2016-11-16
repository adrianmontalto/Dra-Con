using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyBuildManager : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameItemList gameItemList;
    [SerializeField]
    private EnemyUnitBuilder unitBuilder;

    [SerializeField]
    private int m_maxBuildNumber;
    private bool m_isActive = false;
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
    [SerializeField]
    private Text m_lastMoveText;
 
    //lists to store all the enemies decisions
    private Dictionary<string, UtilityScore> m_utilityScoreMap = new Dictionary<string, UtilityScore>();
    private Dictionary<string, UtilityScore> m_resourceUtilittScoreMap = new Dictionary<string,UtilityScore>();
    private Dictionary<string, UtilityScore> m_defenseUtilityScoreMap = new Dictionary<string, UtilityScore>();
    private Dictionary<string, UtilityScore> m_buildUtilityScoreMap = new Dictionary<string, UtilityScore>();
    private Dictionary<string, UtilityScore> m_unitUtilityScoreMap = new Dictionary<string, UtilityScore>();
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
        m_buildResources = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.GetMaxTotalResourceUnits());
        m_buildResources.SetValue(enemy.GetTotalResourceUnits());

        m_buildMiners = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.GetMaxMinerNum());
        m_buildMiners.SetValue(enemy.GetMinerNumber());
        
        m_buildAdvanceMiners = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.GetMaxAdvanceMinerNum());
        m_buildAdvanceMiners.SetValue(enemy.GetAdvanceMinerNumber());

        m_buildDefenses = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,player.GetMaxUnitNumber());
        m_buildDefenses.SetValue(player.GetUnitNumber());

        m_buildMines = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.GetMaxMineNum());
        m_buildMines.SetValue(enemy.GetMineNumber());

        m_buildWalls = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.GetMaxWallNum());
        m_buildWalls.SetValue(enemy.GetWallNumber());

        m_buildAntiAirTurrets = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.GetMaxAntiAirTurretNum());
        m_buildAntiAirTurrets.SetValue(enemy.GetAntiAirTurretNumber());

        m_buildBuildings = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.GetMaxHealth());
        m_buildBuildings.SetValue(enemy.GetHealth());

        m_buildBarracks = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.GetMaxBarracksNum());
        m_buildBarracks.SetValue(enemy.GetBarracksNumber());

        m_buildPortals = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.GetMaxDragonPortalNum());
        m_buildPortals.SetValue(enemy.GetDragonPortalNumber());

        m_buildUnits = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.GetMaxTotalUnitCount());
        m_buildUnits.SetValue(enemy.GetTotalUnitCount());

        m_buildDragonWarriors = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.GetMaxDragonWarriorNum());
        m_buildDragonWarriors.SetValue(enemy.GetDragonWarriorNumber());

        m_buildDragonTanks = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.GetMaxDragonTankNum());
        m_buildDragonTanks.SetValue(enemy.GetDragonTankNumber());

        m_buildDragon = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,enemy.GetMaxDragonNum());
        m_buildDragon.SetValue(enemy.GetDragonNumber());
    }

    void SetValues()
    {
        m_buildResources.SetMinMaxValue(0, enemy.GetMaxTotalResourceUnits());
        m_buildResources.SetValue(enemy.GetTotalResourceUnits());
        m_buildDefenses.SetMinMaxValue(0, player.GetMaxUnitNumber());
        m_buildDefenses.SetValue(player.GetUnitNumber());
        m_buildBuildings.SetMinMaxValue(0, enemy.GetMaxHealth());
        m_buildBuildings.SetValue(enemy.GetHealth());
        m_buildUnits.SetMinMaxValue(0, enemy.GetMaxTotalUnitCount());
        m_buildUnits.SetValue(enemy.GetTotalUnitCount());
    }

    void SetResourceValues()
    {
        m_buildMiners.SetMinMaxValue(0, enemy.GetMaxMinerNum());
        m_buildMiners.SetValue(enemy.GetMinerNumber());
        m_buildAdvanceMiners.SetMinMaxValue(0, enemy.GetMaxAdvanceMinerNum());
        m_buildAdvanceMiners.SetValue(enemy.GetAdvanceMinerNumber());
    }

    void SetDefenseValues()
    {
        m_buildMines.SetMinMaxValue(0, enemy.GetMaxMineNum());
        m_buildMines.SetValue(enemy.GetMineNumber());
        m_buildWalls.SetMinMaxValue(0, enemy.GetMaxWallNum());
        m_buildWalls.SetValue(enemy.GetWallNumber());
        m_buildAntiAirTurrets.SetMinMaxValue(0, enemy.GetMaxAntiAirTurretNum());
        m_buildAntiAirTurrets.SetValue(enemy.GetAntiAirTurretNumber());
    }

    void SetBuildingsValues()
    {
        m_buildBarracks.SetMinMaxValue(0, enemy.GetMaxBarracksNum()); 
        m_buildBarracks.SetValue(enemy.GetBarracksNumber());

        m_buildPortals.SetMinMaxValue(0, enemy.GetMaxDragonPortalNum());
        m_buildPortals.SetValue(enemy.GetDragonPortalNumber());
    }

    void SetUnitsValues()
    {
        m_buildDragonWarriors.SetMinMaxValue(0, enemy.GetMaxDragonWarriorNum());
        m_buildDragonWarriors.SetValue(enemy.GetDragonWarriorNumber());

        m_buildDragonTanks.SetMinMaxValue(0, enemy.GetMaxDragonTankNum());
        m_buildDragonTanks.SetValue(enemy.GetDragonTankNumber());

        m_buildDragon.SetMinMaxValue(0, enemy.GetMaxDragonNum());
        m_buildDragon.SetValue(enemy.GetDragonNumber());
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
            SelectResourceAction();
            m_lastMoveText.text = "Enemy Built Resources";
        }

        if(strBestAction == "buildUnit")
        {
            SelectUnitAction();
            m_lastMoveText.text = "Enemy Built Units";
        }

        if(strBestAction == "buildDefense")
        {
            SelectDefenseAction();
            m_lastMoveText.text = "Enemy Built Defenses";
        }

        if(strBestAction == "buildBuilding")
        {
            SelectBuildingAction();
            m_lastMoveText.text = "Enemy Built Building";
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
            BuildMiner();            
        }

        if(strBestAction == "buildAdvanceMiner")
        {
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
            BuildDragonWarrior();            
        }

        if(strBestAction == "dragonTank")
        {
            BuildDragonTank();            
        }

        if(strBestAction == "dragon")
        {
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
            BuildMines();            
        }

        if(strBestAction == "wall")
        {
            BuildWalls();            
        }

        if(strBestAction == "turret")
        {
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
            BuildBarracks();            
        }

        if(strBestAction == "portal")
        {
            BuildDragonPortal();            
        }
    }

    void BuildMiner()
    {
        int totalGoldCost = gameItemList.GetMiner().GetGoldCost() * m_maxBuildNumber;
        int totalShardCost = gameItemList.GetMiner().GetShardCost() * m_maxBuildNumber;
        int goldAmount = enemy.GetGold();
        int shardAmount = enemy.GetShards();

        if(totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for(int i = 0;i < m_maxBuildNumber;++i)
            {
                unitBuilder.AddMinerNumber(1);
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
            
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;

            while(canBuild == true)
            {
                if((totalGoldCost + gameItemList.GetMiner().GetGoldCost()) < enemy.GetGold())
                {
                    
                    if((totalShardCost + gameItemList.GetMiner().GetShardCost()) < enemy.GetShards())
                    {
                        totalGoldCost += gameItemList.GetMiner().GetGoldCost();
                        totalShardCost += gameItemList.GetMiner().GetShardCost();
                        unitBuilder.AddMinerNumber(1);
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
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
    }

    void BuildAdvanceMiner()
    {
        int totalGoldCost = gameItemList.GetAdvanceMiner().GetGoldCost() * m_maxBuildNumber;
        int totalShardCost = gameItemList.GetAdvanceMiner().GetShardCost() * m_maxBuildNumber;
        int goldAmount = enemy.GetGold();
        int shardAmount = enemy.GetShards();

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.AddAdvanceMinerNumber(1);
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.GetAdvanceMiner().GetGoldCost()) < enemy.GetGold())
                {

                    if ((totalShardCost + gameItemList.GetAdvanceMiner().GetShardCost()) < enemy.GetShards())
                    {
                        totalGoldCost += gameItemList.GetAdvanceMiner().GetGoldCost();
                        totalShardCost += gameItemList.GetAdvanceMiner().GetShardCost();
                        unitBuilder.AddAdvanceMinerNumber(1);
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
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
    }

    void BuildDragonWarrior()
    {
        int totalGoldCost = gameItemList.GetDragonWarrior().GetGoldCost() * m_maxBuildNumber;
        int totalShardCost = gameItemList.GetDragonWarrior().GetShardCost() * m_maxBuildNumber;
        int goldAmount = enemy.GetGold();
        int shardAmount = enemy.GetShards();

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.AddDragonWarriorNumber(1);
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.GetDragonWarrior().GetGoldCost()) < enemy.GetGold())
                {

                    if ((totalShardCost + gameItemList.GetDragonWarrior().GetShardCost()) < enemy.GetShards())
                    {
                        totalGoldCost += gameItemList.GetDragonWarrior().GetGoldCost();
                        totalShardCost += gameItemList.GetDragonWarrior().GetShardCost();
                        unitBuilder.AddDragonWarriorNumber(1);
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
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
    }

    void BuildDragonTank()
    {
        int totalGoldCost = gameItemList.GetDragonTank().GetGoldCost() * m_maxBuildNumber;
        int totalShardCost = gameItemList.GetDragonTank().GetShardCost() * m_maxBuildNumber;
        int goldAmount = enemy.GetGold();
        int shardAmount = enemy.GetShards();

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.AddDragonTankNumber(1);
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.GetDragonTank().GetGoldCost()) < enemy.GetGold())
                {

                    if ((totalShardCost + gameItemList.GetDragonTank().GetShardCost()) < enemy.GetShards())
                    {
                        totalGoldCost += gameItemList.GetDragonTank().GetGoldCost();
                        totalShardCost += gameItemList.GetDragonTank().GetShardCost();
                        unitBuilder.AddDragonTankNumber(1);
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
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
    }

    void BuildDragon()
    {
        int totalGoldCost = gameItemList.GetDragon().GetGoldCost() * m_maxBuildNumber;
        int totalShardCost = gameItemList.GetDragon().GetShardCost() * m_maxBuildNumber;
        int goldAmount = enemy.GetGold();
        int shardAmount = enemy.GetShards();

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.AddDragonNumber(1);
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.GetDragon().GetGoldCost()) < enemy.GetGold())
                {

                    if ((totalShardCost + gameItemList.GetDragon().GetShardCost()) < enemy.GetShards())
                    {
                        totalGoldCost += gameItemList.GetDragon().GetGoldCost();
                        totalShardCost += gameItemList.GetDragon().GetShardCost();
                        unitBuilder.AddDragonNumber(1);
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
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
    }

    void BuildBarracks()
    {
        int totalGoldCost = gameItemList.GetBarracks().GetGoldCost() * m_maxBuildNumber;
        int totalShardCost = gameItemList.GetBarracks().GetShardCost() * m_maxBuildNumber;
        int goldAmount = enemy.GetGold();
        int shardAmount = enemy.GetShards();

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.AddBarracksNum(1);
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.GetBarracks().GetGoldCost()) < enemy.GetGold())
                {

                    if ((totalShardCost + gameItemList.GetBarracks().GetShardCost()) < enemy.GetShards())
                    {
                        totalGoldCost += gameItemList.GetBarracks().GetGoldCost();
                        totalShardCost += gameItemList.GetBarracks().GetShardCost();
                        unitBuilder.AddBarracksNum(1);
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
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
    }

    void BuildDragonPortal()
    {
        int totalGoldCost = gameItemList.GetDragonPortal().GetGoldCost() * m_maxBuildNumber;
        int totalShardCost = gameItemList.GetDragonPortal().GetShardCost() * m_maxBuildNumber;
        int goldAmount = enemy.GetGold();
        int shardAmount = enemy.GetShards();

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.AddDragonPortalNumber(1);
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.GetDragonPortal().GetGoldCost()) < enemy.GetGold())
                {

                    if ((totalShardCost + gameItemList.GetDragonPortal().GetShardCost()) < enemy.GetShards())
                    {
                        totalGoldCost += gameItemList.GetDragonPortal().GetGoldCost();
                        totalShardCost += gameItemList.GetDragonPortal().GetShardCost();
                        unitBuilder.AddDragonPortalNumber(1);
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
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
    }

    void BuildMines()
    {
        int totalGoldCost = gameItemList.GetMine().GetGoldCost() * m_maxBuildNumber;
        int totalShardCost = gameItemList.GetMine().GetShardCost() * m_maxBuildNumber;
        int goldAmount = enemy.GetGold();
        int shardAmount = enemy.GetShards();

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.AddMineNum(1);
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.GetMine().GetGoldCost()) < enemy.GetGold())
                {
                    if ((totalShardCost + gameItemList.GetMine().GetShardCost()) < enemy.GetShards())
                    {
                        totalGoldCost += gameItemList.GetMine().GetGoldCost();
                        totalShardCost += gameItemList.GetMine().GetShardCost();
                        unitBuilder.AddMineNum(1);
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
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
    }

    void BuildWalls()
    {
        int totalGoldCost = gameItemList.GetWall().GetGoldCost() * m_maxBuildNumber;
        int totalShardCost = gameItemList.GetWall().GetShardCost() * m_maxBuildNumber;
        int goldAmount = enemy.GetGold();
        int shardAmount = enemy.GetShards();

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.AddWallNumber(1);
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.GetWall().GetGoldCost()) < enemy.GetGold())
                {

                    if ((totalShardCost + gameItemList.GetWall().GetShardCost()) < enemy.GetShards())
                    {
                        totalGoldCost += gameItemList.GetWall().GetGoldCost();
                        totalShardCost += gameItemList.GetWall().GetShardCost();
                        unitBuilder.AddWallNumber(1);
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
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
    }

    void BuildTurret()
    {
        int totalGoldCost = gameItemList.GetAntiAirTurret().GetGoldCost() * m_maxBuildNumber;
        int totalShardCost = gameItemList.GetAntiAirTurret().GetShardCost() * m_maxBuildNumber;
        int goldAmount = enemy.GetGold();
        int shardAmount = enemy.GetShards();

        if (totalGoldCost < goldAmount && totalShardCost < shardAmount)
        {
            for (int i = 0; i < m_maxBuildNumber; ++i)
            {
                unitBuilder.AddAntiAirTurretNumber(1);
            }
            unitBuilder.AddEnemyUnits();
            unitBuilder.ResetNumbers();
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            enemy.SetMaxValues();
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
        else
        {
            totalGoldCost = 0;
            totalShardCost = 0;
            bool canBuild = true;
            while (canBuild == true)
            {
                if ((totalGoldCost + gameItemList.GetAntiAirTurret().GetGoldCost()) < enemy.GetGold())
                {

                    if ((totalShardCost + gameItemList.GetAntiAirTurret().GetShardCost()) < enemy.GetShards())
                    {
                        totalGoldCost += gameItemList.GetAntiAirTurret().GetGoldCost();
                        totalShardCost += gameItemList.GetAntiAirTurret().GetShardCost();
                        unitBuilder.AddAntiAirTurretNumber(1);
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
            gameManager.SetEnemyTurn(false);
            gameManager.SetPlayerTurn(true);
        }
    }
}
