using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBuildManager : MonoBehaviour
{
    public Enemy enemy;
    public Player player;
    public GameManager gameManager;
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
    public Dictionary<string, UtilityScore> m_unitUtilityScore = new Dictionary<string, UtilityScore>();
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
	    if(gameManager.enemyTurn == true)
        {
            SelectAction();
        }
	}

    void InitValues()
    {
        m_buildResources = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,12);
        m_buildResources.SetValue(enemy.m_totalResourceUnits);

        m_buildMiners = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,10);
        m_buildMiners.SetValue(enemy.m_minerNum);
        
        m_buildAdvanceMiners = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,10);
        m_buildAdvanceMiners.SetValue(enemy.m_advanceminerNum);

        m_buildDefenses = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,12);
        m_buildDefenses.SetValue(player.m_unitNumber);

        m_buildMines = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,10);
        m_buildMines.SetValue(enemy.m_mineNum);

        m_buildWalls = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,10);
        m_buildWalls.SetValue(enemy.m_wallNum);

        m_buildAntiAirTurrets = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,10);
        m_buildAntiAirTurrets.SetValue(enemy.m_antiAirTurretNum);

        m_buildBuildings = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,12);
        m_buildBuildings.SetValue(enemy.m_health);

        m_buildBarracks = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,10);
        m_buildBarracks.SetValue(enemy.m_barrackNum);

        m_buildPortals = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,10);
        m_buildPortals.SetValue(enemy.m_dragonPortalNum);

        m_buildUnits = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,12);
        m_buildUnits.SetValue(enemy.m_totalUnitCount);

        m_buildDragonWarriors = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,10);
        m_buildDragonWarriors.SetValue(enemy.m_dragonWarriorNum);

        m_buildDragonTanks = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,10);
        m_buildDragonTanks.SetValue(enemy.m_dragonTankNum);

        m_buildDragon = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,10);
        m_buildDragon.SetValue(enemy.m_dragonNum);
    }

    void SetValues()
    {
        m_buildResources.SetValue(enemy.m_totalResourceUnits);
        m_buildMiners.SetValue(enemy.m_minerNum);
        m_buildAdvanceMiners.SetValue(enemy.m_advanceminerNum);
        m_buildDefenses.SetValue(player.m_unitNumber);
        m_buildMines.SetValue(enemy.m_mineNum);
        m_buildWalls.SetValue(enemy.m_wallNum);
        m_buildAntiAirTurrets.SetValue(enemy.m_antiAirTurretNum);
        m_buildBuildings.SetValue(enemy.m_health);
        m_buildBarracks.SetValue(enemy.m_barrackNum);
        m_buildPortals.SetValue(enemy.m_dragonPortalNum);
        m_buildUnits.SetValue(enemy.m_totalUnitCount);
        m_buildDragonWarriors.SetValue(enemy.m_dragonWarriorNum);
        m_buildDragonTanks.SetValue(enemy.m_dragonTankNum);
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
        m_unitUtilityScore.Add("dragonWarrior", dragonWarriorScore);

        UtilityScore dragonTankScore = new UtilityScore();
        dragonTankScore.AddUtilityValue(m_buildDragonTanks, 1.0f);
        m_unitUtilityScore.Add("dragonTank",dragonTankScore);

        UtilityScore dragonScore = new UtilityScore();
        dragonScore.AddUtilityValue(m_buildDragon,1.0f);
        m_unitUtilityScore.Add("dragon",dragonScore);
    }

    public void SelectAction()
    {
        SetValues();

        float bestScore = 0.0f;
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
        }

        if(strBestAction == "buildUnit")
        {
            SelectUnitAction();
        }

        if(strBestAction == "buildDefense")
        {
            SelectDefenseAction();
        }

        if(strBestAction == "buildBuilding")
        {
            SelectBuildingAction();
        }
    }

    void SelectResourceAction()
    {
        SetValues();

        float bestScore = 0.0f;
        string strBestAction = "";

        foreach(KeyValuePair<string,UtilityScore> score in)
        {
            float thisScore = score.Value.GetUtilityScore();
            if(thisScore > bestScore)
            {
                bestScore = thisScore;
                strBestAction = score.Key;
            }
        }
    }

    void SelectUnitAction()
    {
        SetValues();

        float bestScore = 0.0f;
        string strBestAction = "";

        foreach (KeyValuePair<string, UtilityScore> score in)
        {
            float thisScore = score.Value.GetUtilityScore();
            if (thisScore > bestScore)
            {
                bestScore = thisScore;
                strBestAction = score.Key;
            }
        }
    }

    void SelectDefenseAction()
    {
        SetValues();

        float bestScore = 0.0f;
        string strBestAction = "";

        foreach (KeyValuePair<string, UtilityScore> score in)
        {
            float thisScore = score.Value.GetUtilityScore();
            if (thisScore > bestScore)
            {
                bestScore = thisScore;
                strBestAction = score.Key;
            }
        }
    }

    void SelectBuildingAction()
    {
        SetValues();

        float bestScore = 0.0f;
        string strBestAction = "";

        foreach (KeyValuePair<string, UtilityScore> score in)
        {
            float thisScore = score.Value.GetUtilityScore();
            if (thisScore > bestScore)
            {
                bestScore = thisScore;
                strBestAction = score.Key;
            }
        }
    }

    void BuildMiner()
    {

    }

    void BuildAdvanceMiner()
    {

    }

    void BuildDragonWarrior()
    {

    }

    void BuildDragonTank()
    {

    }

    void BuildDragon()
    {

    }

    void BuildBarracks()
    {

    }

    void BuildDragonPortal()
    {

    }

    void BuildMines()
    {

    }

    void BuildWalls()
    {

    }

    void BuildTurret()
    {

    }
}
