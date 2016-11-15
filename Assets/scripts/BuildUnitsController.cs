using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildUnitsController : MonoBehaviour
{
    [SerializeField]
    private BuildMenu buildMenu;
    [SerializeField]
    private BuildMenuController buildController;
    [SerializeField]
    private GameObject minerImage;
    [SerializeField]
    private GameObject advanceMinerImage;
    [SerializeField]
    private GameObject dragonWarriorImage;
    [SerializeField]
    private GameObject dragonTankImage;
    [SerializeField]
    private GameObject dragonImage;
    [SerializeField]
    private Text m_shardsCostText;
    [SerializeField]
    private Text m_goldCostText;
    [SerializeField]
    private Text m_healthText;
    [SerializeField]
    private Text m_attackText;
    [SerializeField]
    private Text m_minerNumText;
    [SerializeField]
    private Text m_advanceMinerNumText;
    [SerializeField]
    private Text m_dragonWarriorNumText;
    [SerializeField]
    private Text m_dragonTankNumText;
    [SerializeField]
    private Text m_dragonNumText;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        buildController.GetGoldAmountText().text = buildMenu.GetPlayer().GetGold().ToString();
        buildController.GetTotalGoldCostText().text = buildController.GetTotalGold().ToString();
        buildController.GetShardAmountText().text = buildMenu.GetPlayer().GetShards().ToString();
        buildController.GetTotalShardCostText().text = buildController.GetTotalShard().ToString();
        SetUnitNumbersText();
    }

    public void MinerButtonClick()
    {
        buildMenu.SetPreviousImageActive(false);
        minerImage.SetActive(true);
        buildMenu.SetPreviousImage(minerImage);
        m_shardsCostText.text = buildMenu.GetGameItemList().GetMiner().GetShardCost().ToString();
        m_goldCostText.text = buildMenu.GetGameItemList().GetMiner().GetGoldCost().ToString();
        m_healthText.text = buildMenu.GetGameItemList().GetMiner().GetHealth().ToString();
        m_attackText.text = buildMenu.GetGameItemList().GetMiner().GetAttack().ToString();
    }

    public void AddMiner()
    {
        buildMenu.AddMinerNumber(1);
        buildController.AddTotalGold(buildMenu.GetGameItemList().GetMiner().GetGoldCost());
        buildController.AddTotalShard(buildMenu.GetGameItemList().GetMiner().GetShardCost());        
    }

    public void RemoveMiner()
    {
        if(buildMenu.GetMinerNumber() > 0)
        {
            buildMenu.ReduceMinerNumber(1);
            buildController.ReduceTotalGold(buildMenu.GetGameItemList().GetMiner().GetGoldCost());
            buildController.ReduceTotalShard(buildMenu.GetGameItemList().GetMiner().GetShardCost());
        }
    }

    public void AdvanceMinerButtonClick()
    {
        buildMenu.SetPreviousImageActive(false);
        advanceMinerImage.SetActive(true);
        buildMenu.SetPreviousImage(advanceMinerImage);
        m_shardsCostText.text = buildMenu.GetGameItemList().GetAdvanceMiner().GetShardCost().ToString();
        m_goldCostText.text = buildMenu.GetGameItemList().GetAdvanceMiner().GetGoldCost().ToString();
        m_healthText.text = buildMenu.GetGameItemList().GetAdvanceMiner().GetHealth().ToString();
        m_attackText.text = buildMenu.GetGameItemList().GetAdvanceMiner().GetAttack().ToString();
    }


    public void AddAdvanceMiner()
    {
        buildMenu.AddAdvanceMinerNumber(1);
        buildController.AddTotalGold(buildMenu.GetGameItemList().GetAdvanceMiner().GetGoldCost());
        buildController.AddTotalShard(buildMenu.GetGameItemList().GetAdvanceMiner().GetShardCost());
    }

    public void RemoveAdvanceMiner()
    {
        if(buildMenu.GetAdvanceMinerNumber() > 0)
        {
            buildMenu.ReduceAdvanceMinerNumber(1);
            buildController.ReduceTotalGold(buildMenu.GetGameItemList().GetAdvanceMiner().GetGoldCost());
            buildController.ReduceTotalShard(buildMenu.GetGameItemList().GetAdvanceMiner().GetShardCost());
        }
    }

    public void  DragonWarriorButtonClick()
    {
        buildMenu.SetPreviousImageActive(false);
        dragonWarriorImage.SetActive(true);
        buildMenu.SetPreviousImage(dragonWarriorImage);
        m_shardsCostText.text = buildMenu.GetGameItemList().GetDragonWarrior().GetShardCost().ToString();
        m_goldCostText.text = buildMenu.GetGameItemList().GetDragonWarrior().GetGoldCost().ToString();
        m_healthText.text = buildMenu.GetGameItemList().GetDragonWarrior().GetHealth().ToString();
        m_attackText.text = buildMenu.GetGameItemList().GetDragonWarrior().GetAttack().ToString();
    }

    public void AddDragonWarrior()
    {
        buildMenu.AddDragonWarriorNumber(1);
        buildController.AddTotalGold(buildMenu.GetGameItemList().GetDragonWarrior().GetGoldCost());
        buildController.AddTotalShard(buildMenu.GetGameItemList().GetDragonWarrior().GetShardCost());
    }

    public void RemoveDragonWarrior()
    {
        if(buildMenu.GetDragonWarriorNumber() > 0)
        {
            buildMenu.ReduceDragonWarriorNumber(1);
            buildController.ReduceTotalGold(buildMenu.GetGameItemList().GetDragonWarrior().GetGoldCost());
            buildController.ReduceTotalShard(buildMenu.GetGameItemList().GetDragonWarrior().GetShardCost());
        }
    }

    public void  DragonTankButtonClick()
    {
        buildMenu.SetPreviousImageActive(false);
        dragonTankImage.SetActive(true);
        buildMenu.SetPreviousImage(dragonTankImage);
        m_shardsCostText.text = buildMenu.GetGameItemList().GetDragonTank().GetShardCost().ToString();
        m_goldCostText.text = buildMenu.GetGameItemList().GetDragonTank().GetGoldCost().ToString();
        m_healthText.text = buildMenu.GetGameItemList().GetDragonTank().GetHealth().ToString();
        m_attackText.text = buildMenu.GetGameItemList().GetDragonTank().GetAttack().ToString();
    }
    
    public void AddDragonTank()
    {
        buildMenu.AddDragonTankNumber(1);
        buildController.AddTotalGold(buildMenu.GetGameItemList().GetDragonTank().GetGoldCost());
        buildController.AddTotalShard(buildMenu.GetGameItemList().GetDragonTank().GetShardCost());
    }

    public void RemoveDragonTank()
    {
        if(buildMenu.GetDragonTankNumber() > 0)
        {
            buildMenu.ReduceDragonTankNumber(1);
            buildController.ReduceTotalGold(buildMenu.GetGameItemList().GetDragonTank().GetGoldCost());
            buildController.ReduceTotalShard(buildMenu.GetGameItemList().GetDragonTank().GetShardCost());
        }
    }

    public void  DragonButtonClick()
    {
        buildMenu.SetPreviousImageActive(false);
        dragonImage.SetActive(true);
        buildMenu.SetPreviousImage(dragonImage);
        m_shardsCostText.text = buildMenu.GetGameItemList().GetDragon().GetShardCost().ToString();
        m_goldCostText.text = buildMenu.GetGameItemList().GetDragon().GetGoldCost().ToString();
        m_healthText.text = buildMenu.GetGameItemList().GetDragon().GetHealth().ToString();
        m_attackText.text = buildMenu.GetGameItemList().GetDragon().GetAttack().ToString();
    }

    public void AddDragon()
    {
        buildMenu.AddDragonNumber(1);
        buildController.AddTotalGold(buildMenu.GetGameItemList().GetDragon().GetGoldCost());
        buildController.AddTotalShard(buildMenu.GetGameItemList().GetDragon().GetShardCost());
    }

    public void RemoveDragon()
    {
        if(buildMenu.GetDragonNumber() > 0)
        {
            buildMenu.ReduceDragonNumber(1);
            buildController.ReduceTotalGold(buildMenu.GetGameItemList().GetDragon().GetGoldCost());
            buildController.ReduceTotalShard(buildMenu.GetGameItemList().GetDragon().GetShardCost());
        }
    }

    void SetUnitNumbersText()
    {
        m_minerNumText.text = buildMenu.GetMinerNumber().ToString();
        m_advanceMinerNumText.text = buildMenu.GetAdvanceMinerNumber().ToString();
        m_dragonWarriorNumText.text = buildMenu.GetDragonWarriorNumber().ToString();
        m_dragonTankNumText.text = buildMenu.GetDragonTankNumber().ToString();
        m_dragonNumText.text = buildMenu.GetDragonNumber().ToString();
    }
}
