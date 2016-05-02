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

    private int availableMiners = 0;
    private int availableAdvanceMiners = 0;
    private int minersNum = 0;
    private int advanceMinersNum = 0;
    private bool gatherGold = false;
    private bool gatherShards = false;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        availableMiners = player.minerNum;
        availableAdvanceMiners = player.advanceminerNum;
        minersAmountText.text = minersNum.ToString();
        advanceMinersAmountText.text = advanceMinersNum.ToString();
        if(gatherGold == true)
        {
            gatherMaterial.text = "Gold";
        }

        if (gatherShards == true)
        {
            gatherMaterial.text = "Shard";
        }
    }

    public void GoldButton()
    {
        gatherShards = false;
        gatherGold = true;
    }

    public void ShardButton()
    {
        gatherGold = false;
        gatherShards = true;
    }

    public void AddMinerButton()
    {
        if(minersNum < availableMiners)
        {
            minersNum ++;
        }
    }

    public void RemoveMinerButton()
    {
        if(minersNum > 0)
        {
            minersNum--;
        }
    }

    public void AddAdvanceMinerButton()
    {
        if (advanceMinersNum < availableAdvanceMiners)
        {
            advanceMinersNum++;
        }
    }

    public void RemoveAdvanceMinerButton()
    {
        if (advanceMinersNum > 0)
        {
            advanceMinersNum--;
        }
    }

    public void GatherButton()
    {
        if(gatherGold == true)
        {
            int gold = (minersNum * miner.attack) + (advanceMinersNum * advanceMiner.attack);
            player.gold += gold;
            minersNum = 0;
            advanceMinersNum = 0;
        }

        if (gatherShards == true)
        {
            int shard = (minersNum * miner.attack) + (advanceMinersNum * advanceMiner.attack);
            player.shards += shard;
            minersNum = 0;
            advanceMinersNum = 0;
        }

        gatherMenuPanel.SetActive(false);
        gameManager.playerTurn = false;
        gameManager.enemyTurn = true;
    }
}
