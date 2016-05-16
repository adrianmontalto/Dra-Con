using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDecisionManager : MonoBehaviour
{
    public Enemy enemy;
    public Player player;
    public GameManager gameManager;

    public EnemyAttackManager m_enemyAttacker;
    public EnemyBuildManager m_enemyBuilder;
    public EnemyGatherManager m_enemyGather;
    private UtilityValue m_attackToLowerDefensesValue;
    private UtilityValue m_attackToDestroyPlayerValue;
    private UtilityValue m_gatherGoldValue;
    private UtilityValue m_gatherShardValue;
    private UtilityValue m_buildUnitValue;
    private UtilityValue m_buildResourceValue;
    private UtilityValue m_buildBuildingValue;
    [HideInInspector]
    public Dictionary<string, UtilityScore> m_utilityScoreMap = new Dictionary<string, UtilityScore>();//map to store all the player decisions
	// Use this for initialization
	void Start ()
    {
        InitValues();
        SetScores();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(gameManager.enemyTurn == true)
        {
            SelectAction();
        }        
	}

    public void SelectAction()
    {
        SetValues();

        float bestScore = 0.0f;
        string strBestAction = "";

        foreach(KeyValuePair<string,UtilityScore> m_utilityScore in m_utilityScoreMap)
        {

            float thisScore = m_utilityScore.Value.GetUtilityScore();
            if(thisScore > bestScore)
            {
                bestScore = thisScore;
                strBestAction = m_utilityScore.Key;
            }
        }

        if(strBestAction == "lowerDefense")
        {
            AttackPlayer();
        }

        if(strBestAction == "destroyPlayer")
        {
            AttackPlayer();
        }

        if(strBestAction == "gatherGold")
        {
            GatherResources();
        }

        if(strBestAction == "gatherShard")
        {
            GatherResources();
        }

        if(strBestAction == "buildUnit")
        {
            BuildResources();
        }

        if(strBestAction == "buildBuilding")
        {
            BuildResources();
        }

        if(strBestAction == "buildResource")
        {
            BuildResources();
        }
    }

    void AttackPlayer()
    {
        m_enemyAttacker.SelectAction();
        Debug.Log("Enemy Attacked Player");
    }

    void GatherResources()
    {
        m_enemyGather.SelectAction();
        Debug.Log("Enemy Gathered Resources");
    }

    void BuildResources()
    {
        m_enemyBuilder.SelectAction();
        Debug.Log("Enemy Built Resources");
    }

    void InitValues()
    {
        m_attackToLowerDefensesValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 0, 10);
        m_attackToLowerDefensesValue.SetNormaliztionType(UtilityValue.NormalizationType.LINEAR);
        m_attackToLowerDefensesValue.SetValue(player.m_health);

        m_attackToDestroyPlayerValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 0, 10);
        m_attackToDestroyPlayerValue.SetNormaliztionType(UtilityValue.NormalizationType.LINEAR);
        m_attackToDestroyPlayerValue.SetValue(enemy.m_closenessToWinGoal);

        m_gatherGoldValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 5, 15);
        m_gatherGoldValue.SetNormaliztionType(UtilityValue.NormalizationType.LINEAR);
        m_gatherGoldValue.SetValue(enemy.m_gold);

        m_gatherShardValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 5, 15);
        m_gatherShardValue.SetNormaliztionType(UtilityValue.NormalizationType.LINEAR);
        m_gatherShardValue.SetValue(enemy.m_shards);

        m_buildUnitValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR, 2, 10);
        m_buildUnitValue.SetNormaliztionType(UtilityValue.NormalizationType.INVERSE_LINEAR);
        m_buildUnitValue.SetValue(enemy.m_totalUnitCount);

        m_buildBuildingValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR, 2, 10);
        m_buildBuildingValue.SetNormaliztionType(UtilityValue.NormalizationType.INVERSE_LINEAR);
        m_buildBuildingValue.SetValue(enemy.m_health);

        m_buildResourceValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR, 2, 10);
        m_buildResourceValue.SetNormaliztionType(UtilityValue.NormalizationType.INVERSE_LINEAR);
        m_buildResourceValue.SetValue(enemy.m_totalResourceUnits);
    }

    void SetValues()
    {
        m_attackToLowerDefensesValue.SetValue(player.m_health);
        m_attackToDestroyPlayerValue.SetValue(enemy.m_closenessToWinGoal);
        m_gatherGoldValue.SetValue(enemy.m_gold);
        m_gatherShardValue.SetValue(enemy.m_shards);
        m_buildUnitValue.SetValue(enemy.m_totalUnitCount);
        m_buildBuildingValue.SetValue(enemy.m_health);
        m_buildResourceValue.SetValue(enemy.m_totalResourceUnits);
    }

    void SetScores()
    {
        UtilityScore lowerDefenseScore = new UtilityScore();
        lowerDefenseScore.AddUtilityValue(m_attackToLowerDefensesValue, 1.0f);
        m_utilityScoreMap.Add("lowerDefense", lowerDefenseScore);

        UtilityScore DestroyPlayerScore = new UtilityScore();
        DestroyPlayerScore.AddUtilityValue(m_attackToDestroyPlayerValue, 1.0f);
        m_utilityScoreMap.Add("destroyPlayer", DestroyPlayerScore);

        UtilityScore gatherGoldScore = new UtilityScore();
        gatherGoldScore.AddUtilityValue(m_gatherGoldValue, 1.0f);
        m_utilityScoreMap.Add("gatherGold", gatherGoldScore);

        UtilityScore gatherShard = new UtilityScore();
        gatherShard.AddUtilityValue(m_gatherShardValue, 1.0f);
        m_utilityScoreMap.Add("gatherShard", gatherShard);

        UtilityScore buildUnits = new UtilityScore();
        buildUnits.AddUtilityValue(m_buildUnitValue,1.0f);
        m_utilityScoreMap.Add("buildUnit",buildUnits);

        UtilityScore buildBuildings = new UtilityScore();
        buildBuildings.AddUtilityValue(m_buildBuildingValue, 1.0f);
        m_utilityScoreMap.Add("buildBuilding", buildBuildings);

        UtilityScore buildResource = new UtilityScore();
        buildResource.AddUtilityValue(m_buildResourceValue, 1.0f);
        m_utilityScoreMap.Add("buildResource", buildResource);
    }
}
