using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyGatherManager : MonoBehaviour
{
    public Enemy enemy;
    public Player player;
    public GameItem miner;
    public GameItem advanceMiner;
    public GameManager gameManager;
    public int m_maxMiners = 0;
    public int m_maxAdvanceMiners = 0;
    private UtilityValue m_gatherGoldValue;
    private UtilityValue m_gatherShardValue;
    private UtilityValue m_useMinerValue;
    private UtilityValue m_useAdvanceMinerValue;
    private UtilityValue m_useBothMinersValue;

    private int m_minerNum = 0;
    private int m_advanceMinerNum = 0;
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
        m_gatherGoldValue.SetNormaliztionType(UtilityValue.NormalizationType.INVERSE_LINEAR);
        m_gatherGoldValue.SetValue(enemy.m_gold);

        m_gatherShardValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR, 0, 10);
        m_gatherShardValue.SetNormaliztionType(UtilityValue.NormalizationType.INVERSE_LINEAR);
        m_gatherShardValue.SetValue(enemy.m_shards);

        m_useMinerValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 0, 10);
        m_useMinerValue.SetNormaliztionType(UtilityValue.NormalizationType.LINEAR);
        m_useMinerValue.SetValue(enemy.m_closenessToWinGoal);

        m_useAdvanceMinerValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR,0,12);
        m_useAdvanceMinerValue.SetNormaliztionType(UtilityValue.NormalizationType.INVERSE_LINEAR);
        m_useAdvanceMinerValue.SetValue(enemy.m_closenessToWinGoal);

        m_useBothMinersValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR,0,14);
        m_useBothMinersValue.SetNormaliztionType(UtilityValue.NormalizationType.LINEAR);
        m_useBothMinersValue.SetValue(enemy.m_closenessToWinGoal);
    }

    void SetValues()
    {
        m_gatherGoldValue.SetValue(enemy.m_gold);
        m_gatherShardValue.SetValue(enemy.m_shards);
    }

    void SetMinerValues()
    {
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

        UtilityScore useBothMiners = new UtilityScore();
        useBothMiners.AddUtilityValue(m_useBothMinersValue, 1.0f);
        m_gatherUtilityMap.Add("useBothMiners",useBothMiners);
    }

    public void SelectAction()
    {
        SetValues();

        float bestScore = 0.0f;
        string strBestAction = "";

        foreach(KeyValuePair<string,UtilityScore> score in m_UtilityScoreMap)
        {
            float thisScore = score.Value.GetUtilityScore();
            if(thisScore > bestScore)
            {
                bestScore = thisScore;
                strBestAction = score.Key;
            }
        }

        if(strBestAction == "gatherGold")
        {
            SelectGoldAction();
        }

        if(strBestAction == "gatherShard")
        {
            SelectShardAction();
        }
    }

    public void SelectGoldAction()
    {
        SetMinerValues();

        float bestScore = 0.0f;
        string strBestAction = "";

        foreach (KeyValuePair<string, UtilityScore> score in m_gatherUtilityMap)
        {
            float thisScore = score.Value.GetUtilityScore();
            if (thisScore > bestScore)
            {
                bestScore = thisScore;
                strBestAction = score.Key;
            }
        }

        if(strBestAction == "useMiner")
        {
            if(enemy.m_minerNum < m_maxMiners)
            {
                m_minerNum = enemy.m_minerNum;
            }
            else
            {
                m_minerNum = 10;
            }
            GatherGold();
        }

        if(strBestAction == "useAdvanceMiner")
        {
            if(enemy.m_advanceminerNum < m_maxAdvanceMiners)
            {
                m_advanceMinerNum = enemy.m_advanceminerNum;
            }
            else
            {
                m_advanceMinerNum = 10;
            }
            GatherGold();
        }

        if(strBestAction == "useBothMiners")
        {
            if (enemy.m_minerNum < m_maxMiners)
            {
                m_minerNum = enemy.m_minerNum;
            }
            else
                m_minerNum = 10;

            if (enemy.m_advanceminerNum < m_maxAdvanceMiners)
            {
                m_advanceMinerNum = enemy.m_advanceminerNum;
            }
            else
                m_advanceMinerNum = 10;

            GatherGold();
        }
    }

    public void SelectShardAction()
    {
        SetMinerValues();

        float bestScore = 0.0f;
        string strBestAction = "";

        foreach (KeyValuePair<string, UtilityScore> score in m_gatherUtilityMap)
        {
            float thisScore = score.Value.GetUtilityScore();
            if (thisScore > bestScore)
            {
                bestScore = thisScore;
                strBestAction = score.Key;
            }
        }

        if (strBestAction == "useMiner")
        {
            if (enemy.m_minerNum < m_maxMiners)
            {
                m_minerNum = enemy.m_minerNum;
            }
            else
            {
                m_minerNum = m_maxMiners;
            }
            GatherShard();
        }

        if (strBestAction == "useAdvanceMiner")
        {
            if (enemy.m_advanceminerNum < m_maxAdvanceMiners)
            {
                m_advanceMinerNum = enemy.m_advanceminerNum;
            }
            else
            {
                m_advanceMinerNum = m_maxAdvanceMiners;
            }

            GatherShard();
        }

        if (strBestAction == "useBothMiners")
        {
            if (enemy.m_minerNum < m_maxMiners)
            {
                m_minerNum = enemy.m_minerNum;
            }
            else
            {
                m_minerNum = m_maxMiners;
            }

            if (enemy.m_advanceminerNum < m_maxAdvanceMiners)
            {
                m_advanceMinerNum = enemy.m_advanceminerNum;
            }
            else
            {
                m_advanceMinerNum = m_maxAdvanceMiners;
            }

            GatherShard();
        }
    }

    void GatherGold()
    {
        enemy.m_gold += (m_minerNum * miner.attack) + 
                        (m_advanceMinerNum * advanceMiner.attack);
        m_minerNum = 0;
        m_advanceMinerNum = 0;
        gameManager.enemyTurn = false;
        gameManager.playerTurn = true;
    }

    void GatherShard()
    {
        enemy.m_shards += (m_minerNum * miner.attack) +
                          (m_advanceMinerNum * advanceMiner.attack);
        m_minerNum = 0;
        m_advanceMinerNum = 0;
        gameManager.enemyTurn = false;
        gameManager.playerTurn = true;
    }
}
