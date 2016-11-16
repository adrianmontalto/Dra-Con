using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyGatherManager : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameItemList itemList;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private int m_maxMiners = 0;
    [SerializeField]
    private int m_maxAdvanceMiners = 0;
    [HideInInspector]
    private bool m_isActive = false;
    private UtilityValue m_gatherGoldValue;
    private UtilityValue m_gatherShardValue;
    private UtilityValue m_useMinerValue;
    private UtilityValue m_useAdvanceMinerValue;
    private UtilityValue m_useBothMinersValue;

    private int m_minerNum = 0;
    private int m_advanceMinerNum = 0;
    
    private Dictionary<string, UtilityScore> m_UtilityScoreMap = new Dictionary<string, UtilityScore>();
    private Dictionary<string, UtilityScore> m_gatherUtilityMap = new Dictionary<string, UtilityScore>();
    [SerializeField]
    private Text m_lastMoveText;
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
        m_gatherGoldValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR, 0, enemy.GetMaxGold());
        m_gatherGoldValue.SetValue(enemy.GetGold());

        m_gatherShardValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR, 0, enemy.GetMaxShard());
        m_gatherShardValue.SetValue(enemy.GetShards());

        m_useMinerValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 0, enemy.GetMaxMinerNum());
        m_useMinerValue.SetValue(enemy.GetMinerNumber());

        m_useAdvanceMinerValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR,0,enemy.GetAdvanceMinerNumber());
        m_useAdvanceMinerValue.SetValue(enemy.GetAdvanceMinerNumber());

        m_useBothMinersValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR,0,enemy.GetMaxClosenessToWinGoal());
        m_useBothMinersValue.SetValue(enemy.GetClosenessToWinGoal());
    }

    void SetValues()
    {
        m_gatherGoldValue.SetMinMaxValue(0,enemy.GetMaxGold());
        m_gatherGoldValue.SetValue(enemy.GetGold());
        m_gatherShardValue.SetMinMaxValue(0,enemy.GetMaxShard());
        m_gatherShardValue.SetValue(enemy.GetShards());
    }

    void SetMinerValues()
    {
        m_useMinerValue.SetMinMaxValue( 0,enemy.GetMaxMinerNum());
        m_useMinerValue.SetValue(enemy.GetMinerNumber());
        m_useAdvanceMinerValue.SetMinMaxValue( 0, enemy.GetMaxAdvanceMinerNum());
        m_useAdvanceMinerValue.SetValue(enemy.GetAdvanceMinerNumber());
        m_useBothMinersValue.SetMinMaxValue( 0, enemy.GetMaxClosenessToWinGoal());
        m_useBothMinersValue.SetValue(enemy.GetClosenessToWinGoal());
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
            SelectGoldAction();
            m_lastMoveText.text = "Enemy Gathered Gold";       
        }

        if(strBestAction == "gatherShard")
        {
            SelectShardAction();
            m_lastMoveText.text = "Enemy Gathered Shards";            
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
            if(enemy.GetMinerNumber() < m_maxMiners)
            {
                m_minerNum = enemy.GetMinerNumber();
            }
            else
            {
                m_minerNum = 10;
            }
            GatherGold();
        }

        if(strBestAction == "useAdvanceMiner")
        {
            if(enemy.GetAdvanceMinerNumber() < m_maxAdvanceMiners)
            {
                m_advanceMinerNum = enemy.GetAdvanceMinerNumber();
            }
            else
            {
                m_advanceMinerNum = 10;
            }
            GatherGold();
        }

        if(strBestAction == "useBothMiners")
        {
            if (enemy.GetMinerNumber() < m_maxMiners)
            {
                m_minerNum = enemy.GetMinerNumber();
                GatherGold();
            }
            else
                m_minerNum = 10;

            if (enemy.GetAdvanceMinerNumber() < m_maxAdvanceMiners)
            {
                m_advanceMinerNum = enemy.GetAdvanceMinerNumber();
                GatherGold();
            }
            else
            {
                m_advanceMinerNum = 10;
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
            if (enemy.GetMinerNumber() < m_maxMiners)
            {
                m_minerNum = enemy.GetMinerNumber();
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
            if (enemy.GetAdvanceMinerNumber() < m_maxAdvanceMiners)
            {
                m_advanceMinerNum = enemy.GetAdvanceMinerNumber();
            }
            else
            {
                m_advanceMinerNum = m_maxAdvanceMiners;
            }

            GatherShard();            
        }

        if (strBestAction == "useBothMiners")
        {
            if (enemy.GetMinerNumber() < m_maxMiners)
            {
                m_minerNum = enemy.GetMinerNumber();
            }
            else
            {
                m_minerNum = m_maxMiners;
            }

            if (enemy.GetAdvanceMinerNumber() < m_maxAdvanceMiners)
            {
                m_advanceMinerNum = enemy.GetAdvanceMinerNumber();
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
        enemy.AddGold((m_minerNum * itemList.GetMiner().GetAttack()) + (m_advanceMinerNum * itemList.GetAdvanceMiner().GetAttack()));
        m_minerNum = 0;
        m_advanceMinerNum = 0;
        m_isActive = false;
        gameManager.SetEnemyTurn(false);
        gameManager.SetPlayerTurn(true);
    }

    void GatherShard()
    {
        enemy.AddShards((m_minerNum * itemList.GetMiner().GetAttack()) + (m_advanceMinerNum * itemList.GetAdvanceMiner().GetAttack()));
        m_minerNum = 0;
        m_advanceMinerNum = 0;
        m_isActive = false;
        gameManager.SetEnemyTurn(false);
        gameManager.SetPlayerTurn(true);
    }
}
