using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDecisionManager : MonoBehaviour
{
    public Enemy enemy;
    public Player player;
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
    public Dictionary<string, UtilityScore> m_utilityScoreMap = new Dictionary<string, UtilityScore>();
	// Use this for initialization
	void Start ()
    {
        SetValues();
        SetScores();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void MakeDecision()
    {

    }

    void AttackPlayer()
    {

    }

    void GatherResources()
    {

    }

    void BuildResources()
    {
         
    }

    void SetValues()
    {
        m_attackToLowerDefensesValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 0, 10);
        m_attackToLowerDefensesValue.SetValue(player.m_health);

        m_attackToDestroyPlayerValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 0, 5);
        m_attackToDestroyPlayerValue.SetValue(enemy.m_closenessToWinGoal);

        m_gatherGoldValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 0, 12);
        m_gatherGoldValue.SetValue(enemy.m_gold);

        m_gatherShardValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 0, 12);
        m_gatherShardValue.SetValue(enemy.m_shards);

        m_buildUnitValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR, 0, 8);
        m_buildUnitValue.SetValue(enemy.m_totalUnitCount);

        m_buildBuildingValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR, 0, 10);
        m_buildBuildingValue.SetValue(enemy.m_health);

        m_buildResourceValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR, 0, 9);
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
