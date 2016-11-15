using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildMenuController : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private BuildMenu buildMenu;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameObject buildPanel;
    [SerializeField]
    private GameObject unitPanel;
    [SerializeField]
    private GameObject buildingPanel;
    [SerializeField]
    private GameObject initPanel;
    [SerializeField]
    private GameObject previousPanel;
    [SerializeField]
    private Text m_totalShardCostText;
    [SerializeField]
    private Text m_shardAmountText;
    [SerializeField]
    private Text m_totalGoldCostText;
    [SerializeField]
    private Text m_goldAmountText;
    [HideInInspector]
    private int m_totalGold;
    [HideInInspector]
    private int m_totalShard;

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
        if (m_totalShard < player.GetShards() && m_totalGold < player.GetGold())
        {
            buildMenu.AddPlayerBuildings();
            buildMenu.AddPlayerUnits();
            buildMenu.ResetNumbers();
            buildPanel.SetActive(false);
            m_totalGold = 0;
            m_totalShard = 0;
            player.SetMaxHealth();
            player.SetMaxUnitNumber();
            gameManager.SetPlayerTurn(false);
            gameManager.SetEnemyTurn(true);

        }
    }

    public Text GetGoldAmountText()
    {
        return m_goldAmountText;
    }

    public Text GetTotalGoldCostText()
    {
        return m_totalGoldCostText;
    }

    public Text GetShardAmountText()
    {
        return m_shardAmountText;
    }

    public Text GetTotalShardCostText()
    {
        return m_totalShardCostText;
    }

    public int GetTotalGold()
    {
        return m_totalGold;
    }

    public void ReduceTotalGold(int amount)
    {
        m_totalGold -= amount;
    }

    public void AddTotalGold(int amount)
    {
        m_totalGold += amount;
    }

    public int GetTotalShard()
    {
        return m_totalShard;
    }

    public void ReduceTotalShard(int amount)
    {
        m_totalShard -= amount;
    }

    public void AddTotalShard(int amount)
    {
        m_totalShard += amount;
    }
}
