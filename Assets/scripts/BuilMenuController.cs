using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuilMenuController : MonoBehaviour
{
    public Player player;
    public BuildMenu buildMenu;
    public GameManager gameManager;
    public GameObject buildPanel;
    public GameObject unitPanel;
    public GameObject buildingPanel;
    public GameObject initPanel;
    private GameObject previousPanel;
    public Text m_totalShardCostText;
    public Text m_shardAmountText;
    public Text m_totalGoldCostText;
    public Text m_goldAmount;
    [HideInInspector]
    public int m_totalGold;
    [HideInInspector]
    public int m_totalShard;

    // Use this for initialization
    void Start ()
    {
        previousPanel = initPanel;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void UnitButtonClick()
    {
        previousPanel.SetActive(false);
        unitPanel.SetActive(true);
        previousPanel = unitPanel;
    }

    public void BuildingButtonClick()
    {
        previousPanel.SetActive(false);
        buildingPanel.SetActive(true);
        previousPanel = buildingPanel;
    }

    public void BuildButtonClick()
    {
        Debug.Log("");
        Debug.Log("player build");
        Debug.Log("");
        if (m_totalShard < player.m_shards && m_totalGold < player.m_gold)
        {
            buildMenu.AddPlayerBuildings();
            buildMenu.AddPlayerUnits();
            buildMenu.ResetNumbers();
            buildPanel.SetActive(false);
            m_totalGold = 0;
            m_totalShard = 0;
            gameManager.playerTurn = false;
            gameManager.enemyTurn = true;

        }
    }
}
