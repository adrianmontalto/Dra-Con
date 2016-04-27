using UnityEngine;
using System.Collections;

public class GatherMenuController : MonoBehaviour
{
    public Player player;
    public GameObject gatherMenuPanel;
    public GameManager gameManager;

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
        availableMiners = player.miners;
        availableAdvanceMiners = player.advanceminers;
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
        gatherMenuPanel.SetActive(false);
        gameManager.playerTurn = false;
        gameManager.enemyTurn = true;
    }
}
