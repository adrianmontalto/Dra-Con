using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GatherMenuController : MonoBehaviour
{
    public Player player;
    public GameItem miner;
    public GameItem advanceMiner;
    public GameObject gatherMenuPanel;
    public GameManager gameManager;
    public Text minersAmountText;
    public Text advanceMinersAmountText;
    public Text gatherMaterial;
    public int m_maxMiners = 0;
    public int m_maxAdvanceMiners = 0;

    private int m_availableMiners = 0;
    private int m_availableAdvanceMiners = 0;
    private int m_minersNum = 0;
    private int m_advanceMinersNum = 0;
    private bool m_gatherGold = false;
    private bool m_gatherShards = false;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_availableMiners = player.m_minerNum;
        m_availableAdvanceMiners = player.m_advanceminerNum;
        minersAmountText.text = m_minersNum.ToString();
        advanceMinersAmountText.text = m_advanceMinersNum.ToString();
        if(m_gatherGold == true)
        {
            gatherMaterial.text = "Gold";
        }

        if (m_gatherShards == true)
        {
            gatherMaterial.text = "Shard";
        }
    }

    public void GoldButton()
    {
        m_gatherShards = false;
        m_gatherGold = true;
    }

    public void ShardButton()
    {
        m_gatherGold = false;
        m_gatherShards = true;
    }

    public void AddMinerButton()
    {
        if(m_minersNum < m_availableMiners)
        {
            if(m_minersNum < m_maxMiners)
            {
                m_minersNum++;
            }            
        }
    }

    public void RemoveMinerButton()
    {
        if(m_minersNum > 0)
        {
            m_minersNum--;
        }
    }

    public void AddAdvanceMinerButton()
    {
        if (m_advanceMinersNum < m_availableAdvanceMiners)
        {
            if(m_advanceMinersNum < m_maxAdvanceMiners)
            {
                m_advanceMinersNum++;
            }            
        }
    }

    public void RemoveAdvanceMinerButton()
    {
        if (m_advanceMinersNum > 0)
        {
            m_advanceMinersNum--;
        }
    }

    public void GatherButton()
    {
        Debug.Log("");
        Debug.Log("player Gather");
        Debug.Log("");
        if (m_gatherGold == true)
        {
            int gold = (m_minersNum * miner.attack) + (m_advanceMinersNum * advanceMiner.attack);
            player.m_gold += gold;
            m_minersNum = 0;
            m_advanceMinersNum = 0;
        }

        if (m_gatherShards == true)
        {
            int shard = (m_minersNum * miner.attack) + (m_advanceMinersNum * advanceMiner.attack);
            player.m_shards += shard;
            m_minersNum = 0;
            m_advanceMinersNum = 0;
        }

        m_gatherGold = false;
        m_gatherShards = false;
        gatherMaterial.text = "";
        gatherMenuPanel.SetActive(false);
        gameManager.playerTurn = false;
        gameManager.enemyTurn = true;
    }
}
