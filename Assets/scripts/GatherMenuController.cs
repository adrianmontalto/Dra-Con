using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GatherMenuController : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameItem miner;
    [SerializeField]
    private GameItem advanceMiner;
    [SerializeField]
    private GameObject gatherMenuPanel;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private Text minersAmountText;
    [SerializeField]
    private Text advanceMinersAmountText;
    [SerializeField]
    private Text gatherMaterial;
    [SerializeField]
    private int m_maxMiners = 0;
    [SerializeField]
    private int m_maxAdvanceMiners = 0;

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
        m_availableMiners = player.GetMinerNumber();
        m_availableAdvanceMiners = player.GetAdvanceMinerNumber();
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
        if (m_gatherGold == true)
        {
            int gold = (m_minersNum * miner.GetAttack()) + (m_advanceMinersNum * advanceMiner.GetAttack());
            player.AddGold(gold);
            m_minersNum = 0;
            m_advanceMinersNum = 0;
        }

        if (m_gatherShards == true)
        {
            int shard = (m_minersNum * miner.GetAttack()) + (m_advanceMinersNum * advanceMiner.GetAttack());
            player.AddShards(shard);
            m_minersNum = 0;
            m_advanceMinersNum = 0;
        }

        m_gatherGold = false;
        m_gatherShards = false;
        gatherMaterial.text = "";
        gatherMenuPanel.SetActive(false);
        gameManager.SetPlayerTurn(false);
        gameManager.SetEnemyTurn(true);
    }
}
