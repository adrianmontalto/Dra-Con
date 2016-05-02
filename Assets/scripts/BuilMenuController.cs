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
    public Text totalShardCostText;
    public Text shardAmountText;
    public Text totalGoldCostText;
    public Text goldAmount;
    [HideInInspector]
    public int totalGold;
    [HideInInspector]
    public int totalShard;

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
        if(totalShard < player.shards && totalGold < player.gold)
        {
            buildMenu.AddPlayerBuildings();
            buildMenu.AddPlayerUnits();
            buildMenu.ResetNumbers();
            buildPanel.SetActive(false);
            gameManager.playerTurn = false;
            gameManager.enemyTurn = true;

        }
    }
}
