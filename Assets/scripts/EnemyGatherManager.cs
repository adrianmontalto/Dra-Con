using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyGatherManager : MonoBehaviour
{
    public Enemy enemy;
    public Player player;
    public GameItemList itemList;
    public GameManager gameManager;
    public int m_maxMiners = 0;
    public int m_maxAdvanceMiners = 0;
    [HideInInspector]
    public bool m_isActive = false;
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
        InitValues();
        SetGatherScores();
        SetScores();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void InitValues()
    {
        m_gatherGoldValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR, 0, enemy.m_maxGold);
        m_gatherGoldValue.SetValue(enemy.m_gold);

        m_gatherShardValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR, 0, enemy.m_maxShard);
        m_gatherShardValue.SetValue(enemy.m_shards);

        m_useMinerValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 0, enemy.m_maxMinerNum);
        m_useMinerValue.SetValue(enemy.m_minerNum);

        m_useAdvanceMinerValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR,0,enemy.m_maxAdvanceMinerNum);
        m_useAdvanceMinerValue.SetValue(enemy.m_advanceminerNum);

        m_useBothMinersValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR,0,enemy.m_maxClosenessToWinGoal);
        m_useBothMinersValue.SetValue(enemy.m_closenessToWinGoal);
    }

    void SetValues()
    {
        m_gatherGoldValue.SetMinMaxValue(0,enemy.m_maxGold);
        m_gatherGoldValue.SetValue(enemy.m_gold);
        m_gatherShardValue.SetMinMaxValue(0,enemy.m_maxShard);
        m_gatherShardValue.SetValue(enemy.m_shards);
    }

    void SetMinerValues()
    {
        m_useMinerValue.SetMinMaxValue( 0,enemy.m_maxMinerNum);
        m_useMinerValue.SetValue(enemy.m_minerNum);
        m_useAdvanceMinerValue.SetMinMaxValue( 0, enemy.m_maxAdvanceMinerNum);
        m_useAdvanceMinerValue.SetValue(enemy.m_advanceminerNum);
        m_useBothMinersValue.SetMinMaxValue( 0, enemy.m_maxClosenessToWinGoal);
        m_useBothMinersValue.SetValue(enemy.m_closenessToWinGoal);
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
        Debug.Log("gather action");
        float bestScore =-100.0f;
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
            Debug.Log("gather: gold");
            SelectGoldAction();            
        }

        if(strBestAction == "gatherShard")
        {
            Debug.Log("gather: shard");
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
            Debug.Log("gather:gold miner");
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
            Debug.Log("gather: gold advance");
        }

        if(strBestAction == "useBothMiners")
        {
            if (enemy.m_minerNum < m_maxMiners)
            {
                m_minerNum = enemy.m_minerNum;
                Debug.Log("gather: gold both");
                GatherGold();
            }
            else
                m_minerNum = 10;

            if (enemy.m_advanceminerNum < m_maxAdvanceMiners)
            {
                m_advanceMinerNum = enemy.m_advanceminerNum;
                Debug.Log("gather: gold both");
                GatherGold();
            }
            else
            {
                m_advanceMinerNum = 10;
                Debug.Log("gather: gold both");
                GatherGold();
            }
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
            Debug.Log("gather: shard miner");
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

            Debug.Log("gather: shard advance");
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

            Debug.Log("gather: shard both");
            GatherShard();            
        }
    }

    void GatherGold()
    {
        enemy.m_gold += (m_minerNum * itemList.miner.attack) + 
                        (m_advanceMinerNum * itemList.advanceMiner.attack);
        m_minerNum = 0;
        m_advanceMinerNum = 0;
        m_isActive = false;
        gameManager.enemyTurn = false;
        gameManager.playerTurn = true;
    }

    void GatherShard()
    {
        enemy.m_shards += (m_minerNum * itemList.miner.attack) +
                          (m_advanceMinerNum * itemList.advanceMiner.attack);
        m_minerNum = 0;
        m_advanceMinerNum = 0;
        m_isActive = false;
        gameManager.enemyTurn = false;
        gameManager.playerTurn = true;
    }
}
