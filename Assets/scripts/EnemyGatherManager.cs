using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyGatherManager : MonoBehaviour
{
    public Enemy enemy;
    public Player player;
    private UtilityValue m_gatherGoldValue;
    private UtilityValue m_gatherShardValue;
    private UtilityValue m_useMinerValue;
    private UtilityValue m_useAdvanceMinerValue;
    [HideInInspector]
    public Dictionary<string, UtilityScore> m_UtilityScoreMap = new Dictionary<string, UtilityScore>();
    [HideInInspector]
    public Dictionary<string, UtilityScore> m_gatherUtilityMap = new Dictionary<string, UtilityScore>();
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void InitValues()
    {
        m_gatherGoldValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR, 0, 10);
        m_gatherGoldValue.SetValue(enemy.m_gold);

        m_gatherShardValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR, 0, 10);
        m_gatherShardValue.SetValue(enemy.m_shards);

        m_useMinerValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 0, 10);
        m_useMinerValue.SetValue(enemy.m_closenessToWinGoal);

        m_useAdvanceMinerValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,12);
        m_useAdvanceMinerValue.SetValue(enemy.m_closenessToWinGoal);
    }

    void SetValues()
    {
        m_gatherGoldValue.SetValue(enemy.m_gold);
        m_gatherShardValue.SetValue(enemy.m_shards);
        m_useMinerValue.SetValue(enemy.m_closenessToWinGoal);
        m_useAdvanceMinerValue.SetValue(enemy.m_closenessToWinGoal);
    }

    void SetScores()
    {
        UtilityScore gatherGoldScore = new UtilityScore();
        gatherGoldScore.AddUtilityValue(m_gatherGoldValue,1.0f);
        m_UtilityScoreMap.Add("gatherGold",gatherGoldScore);

        UtilityScore gatherShardScore = new UtilityScore();
        gatherShardScore.AddUtilityValue(m_gatherShardValue,1.0f);
        m_UtilityScoreMap.Add("gatherShard", gatherShardScore);
    }

    void SetGatherScores()
    {
        UtilityScore useMinerScore = new UtilityScore();
        useMinerScore.AddUtilityValue(m_useMinerValue,1.0f);
        m_gatherUtilityMap.Add("useMiner",useMinerScore);

        UtilityScore useAdvanceMinerScore = new UtilityScore();
        useAdvanceMinerScore.AddUtilityValue(m_useAdvanceMinerValue,1.0f);
        m_gatherUtilityMap.Add("useAdvanceMiner",useAdvanceMinerScore);
    }

    public void SelectAction()
    {

    }
}
