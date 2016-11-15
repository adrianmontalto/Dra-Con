using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingsBuilderController : MonoBehaviour
{
    [SerializeField]
    private GameObject barracksImage;//the image for the barracks
    [SerializeField]
    private GameObject dragonPortalImage;// the image for the dragon portal
    [SerializeField]
    private GameObject antiAirTurretImage;//the image for the anti air turret
    [SerializeField]
    private GameObject minesImage;//the image for the mine
    [SerializeField]
    private GameObject wallImage;//the image for the wall
    [SerializeField]
    private BuildMenu buildMenu;//allows to access the build menu variables
    [SerializeField]
    private BuildMenuController buildController;//allows to access build controller variables
    [SerializeField]
    private Text m_shardsCostText;//text to display the shard cost of the building
    [SerializeField]
    private Text m_goldCostText;//text to display the gold cost of the building
    [SerializeField]
    private Text m_healthText;//text to display the health of the building
    [SerializeField]
    private Text m_attackText;//text to display the attack of the building
    [SerializeField]
    private Text m_barracksNumText;
    [SerializeField]
    private Text m_dragonPortalNumText;
    [SerializeField]
    private Text m_minesNumText;
    [SerializeField]
    private Text m_wallNumText;
    [SerializeField]
    private Text m_antiAirTurretNumText;


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
        SetNumbersText();
    }

    public void BarracksButton()
    {
        buildMenu.SetPreviousImageActive(false);
        barracksImage.SetActive(true);
        buildMenu.SetPreviousImage(barracksImage);
        m_shardsCostText.text = buildMenu.GetGameItemList().GetBarracks().GetShardCost().ToString();
        m_goldCostText.text = buildMenu.GetGameItemList().GetBarracks().GetGoldCost().ToString();
        m_healthText.text = buildMenu.GetGameItemList().GetBarracks().GetHealth().ToString();
        m_attackText.text = buildMenu.GetGameItemList().GetBarracks().GetAttack().ToString();
    }

    public void AddBarracks()
    {
        buildMenu.AddBarracksNumber(1);
        buildController.AddTotalGold(buildMenu.GetGameItemList().GetBarracks().GetGoldCost());
        buildController.AddTotalShard(buildMenu.GetGameItemList().GetBarracks().GetShardCost());
    }

    public void RemoveBarracks()
    {
        if(buildMenu.GetBarracksNumber() > 0)
        {
            buildMenu.ReduceBarracksNumber(1);
            buildController.ReduceTotalGold(buildMenu.GetGameItemList().GetBarracks().GetGoldCost());
            buildController.ReduceTotalShard(buildMenu.GetGameItemList().GetBarracks().GetShardCost());
        }       
    }

    public void DragonPortalButton()
    {
        buildMenu.SetPreviousImageActive(false);
        dragonPortalImage.SetActive(true);
        buildMenu.SetPreviousImage(dragonPortalImage);
        m_shardsCostText.text = buildMenu.GetGameItemList().GetDragonPortal().GetShardCost().ToString();
        m_goldCostText.text = buildMenu.GetGameItemList().GetDragonPortal().GetGoldCost().ToString();
        m_healthText.text = buildMenu.GetGameItemList().GetDragonPortal().GetHealth().ToString();
        m_attackText.text = buildMenu.GetGameItemList().GetDragonPortal().GetAttack().ToString();
    }

    public void AddDragonPortal()
    {
        buildMenu.AddDragonPortalsNumber(1);
        buildController.AddTotalGold(buildMenu.GetGameItemList().GetDragonPortal().GetGoldCost());
        buildController.AddTotalShard(buildMenu.GetGameItemList().GetDragonPortal().GetShardCost());
    }

    public void RemoveDragonPortal()
    {
        if (buildMenu.GetDragonPortalsNumber() > 0)
        {
            buildMenu.ReduceDragonPortalsNumber(1);
            buildController.ReduceTotalGold(buildMenu.GetGameItemList().GetDragonPortal().GetGoldCost());
            buildController.ReduceTotalShard(buildMenu.GetGameItemList().GetDragonPortal().GetShardCost());
        }
    }

    public void AntiAirTurretButton()
    {
        buildMenu.SetPreviousImageActive(false);
        antiAirTurretImage.SetActive(true);
        buildMenu.SetPreviousImageActive(antiAirTurretImage);
        m_shardsCostText.text = buildMenu.GetGameItemList().GetAntiAirTurret().GetShardCost().ToString();
        m_goldCostText.text = buildMenu.GetGameItemList().GetAntiAirTurret().GetGoldCost().ToString();
        m_healthText.text = buildMenu.GetGameItemList().GetAntiAirTurret().GetHealth().ToString();
        m_attackText.text = buildMenu.GetGameItemList().GetAntiAirTurret().GetAttack().ToString();
    }

    public void AddAntiAirTurret()
    {
        buildMenu.AddAntiAirTurretNumber(1);
        buildController.AddTotalGold(buildMenu.GetGameItemList().GetAntiAirTurret().GetGoldCost());
        buildController.AddTotalShard(buildMenu.GetGameItemList().GetAntiAirTurret().GetShardCost());
    }

    public void RemoveAntiAirTurret()
    {
        if (buildMenu.GetAntiAirTurretNumber() > 0)
        {
            buildMenu.ReduceAntiAirTurretNumber(1);
            buildController.ReduceTotalGold(buildMenu.GetGameItemList().GetAntiAirTurret().GetGoldCost());
            buildController.ReduceTotalShard(buildMenu.GetGameItemList().GetAntiAirTurret().GetShardCost());
        }
    }

    public void MinesButton()
    {
        buildMenu.SetPreviousImageActive(false);
        minesImage.SetActive(true);
        buildMenu.SetPreviousImage(minesImage);
        m_shardsCostText.text = buildMenu.GetGameItemList().GetMine().GetShardCost().ToString();
        m_goldCostText.text = buildMenu.GetGameItemList().GetMine().GetGoldCost().ToString();
        m_healthText.text = buildMenu.GetGameItemList().GetMine().GetHealth().ToString();
        m_attackText.text = buildMenu.GetGameItemList().GetMine().GetAttack().ToString();
    }

    public void AddMines()
    {
        buildMenu.AddMineNumber(1);
        buildController.AddTotalGold(buildMenu.GetGameItemList().GetMine().GetGoldCost());
        buildController.AddTotalShard(buildMenu.GetGameItemList().GetMine().GetShardCost());
    }

    public void RemoveMines()
    {
        if (buildMenu.GetMinesNumber() > 0)
        {
            buildMenu.ReduceMineNumber(1);
            buildController.ReduceTotalGold(buildMenu.GetGameItemList().GetMine().GetGoldCost());
            buildController.ReduceTotalShard(buildMenu.GetGameItemList().GetMine().GetShardCost());
        }
    }

    public void WallButton()
    {
        buildMenu.SetPreviousImageActive(false);
        wallImage.SetActive(true);
        buildMenu.SetPreviousImage(wallImage);
        m_shardsCostText.text = buildMenu.GetGameItemList().GetWall().GetShardCost().ToString();
        m_goldCostText.text = buildMenu.GetGameItemList().GetWall().GetGoldCost().ToString();
        m_healthText.text = buildMenu.GetGameItemList().GetWall().GetHealth().ToString();
        m_attackText.text = buildMenu.GetGameItemList().GetWall().GetAttack().ToString();
    }

    public void AddWall()
    {
        buildMenu.AddWallNumber(1);
        buildController.AddTotalGold(buildMenu.GetGameItemList().GetWall().GetGoldCost());
        buildController.AddTotalShard(buildMenu.GetGameItemList().GetWall().GetShardCost());
    }

    public void RemoveWall()
    {
        if (buildMenu.GetWallNumber() > 0)
        {
            buildMenu.ReduceWallNumber(1);
            buildController.AddTotalGold(buildMenu.GetGameItemList().GetWall().GetGoldCost());
            buildController.AddTotalShard(buildMenu.GetGameItemList().GetWall().GetShardCost());
        }
    }

    void SetNumbersText()
    {
        m_barracksNumText.text = buildMenu.GetBarracksNumber().ToString();
        m_dragonPortalNumText.text = buildMenu.GetDragonPortalsNumber().ToString();
        m_minesNumText.text = buildMenu.GetMinesNumber().ToString();
        m_wallNumText.text = buildMenu.GetWallNumber().ToString();
        m_antiAirTurretNumText.text = buildMenu.GetAntiAirTurretNumber().ToString();
    }
}
