using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingsBuilderController : MonoBehaviour
{
    public GameObject barracksImage;//the image for the barracks
    public GameObject dragonPortalImage;// the image for the dragon portal
    public GameObject antiAirTurretImage;//the image for the anti air turret
    public GameObject minesImage;//the image for the mine
    public GameObject wallImage;//the image for the wall      
    public BuildMenu buildMenu;//allows to access the build menu variables
    public BuilMenuController buildController;//allows to access build controller variables
    public Text m_shardsCostText;//text to display the shard cost of the building
    public Text m_goldCostText;//text to display the gold cost of the building
    public Text m_healthText;//text to display the health of the building
    public Text m_attackText;//text to display the attack of the building
    public Text m_barracksNumText;
    public Text m_dragonPortalNumText;
    public Text m_minesNumText;
    public Text m_wallNumText;
    public Text m_antiAirTurretNumText;


	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        buildController.m_goldAmount.text = buildMenu.player.m_gold.ToString();
        buildController.m_totalGoldCostText.text = buildController.m_totalGold.ToString();
        buildController.m_shardAmountText.text = buildMenu.player.m_shards.ToString();
        buildController.m_totalShardCostText.text = buildController.m_totalShard.ToString();
        SetNumbersText();
    }

    public void BarracksButton()
    {
        buildMenu.previousImage.SetActive(false);
        barracksImage.SetActive(true);
        buildMenu.previousImage = barracksImage;
        m_shardsCostText.text = buildMenu.gameItemList.barracks.shardCost.ToString();
        m_goldCostText.text = buildMenu.gameItemList.barracks.goldCost.ToString();
        m_healthText.text = buildMenu.gameItemList.barracks.health.ToString();
        m_attackText.text = buildMenu.gameItemList.barracks.attack.ToString();
    }

    public void AddBarracks()
    {
        buildMenu.m_barracksNum += 1;
        buildController.m_totalGold += buildMenu.gameItemList.barracks.goldCost;
        buildController.m_totalShard += buildMenu.gameItemList.barracks.shardCost;
    }

    public void RemoveBarracks()
    {
        if(buildMenu.m_barracksNum > 0)
        {
            buildMenu.m_barracksNum--;
            buildController.m_totalGold -= buildMenu.gameItemList.barracks.goldCost;
            buildController.m_totalShard -= buildMenu.gameItemList.barracks.shardCost;
        }       
    }

    public void DragonPortalButton()
    {
        buildMenu.previousImage.SetActive(false);
        dragonPortalImage.SetActive(true);
        buildMenu.previousImage = dragonPortalImage;
        m_shardsCostText.text = buildMenu.gameItemList.dragonPortal.shardCost.ToString();
        m_goldCostText.text = buildMenu.gameItemList.dragonPortal.goldCost.ToString();
        m_healthText.text = buildMenu.gameItemList.dragonPortal.health.ToString();
        m_attackText.text = buildMenu.gameItemList.dragonPortal.attack.ToString();
    }

    public void AddDragonPortal()
    {
        buildMenu.m_dragonPortalsNum += 1;
        buildController.m_totalGold += buildMenu.gameItemList.dragonPortal.goldCost;
        buildController.m_totalShard += buildMenu.gameItemList.dragonPortal.shardCost;
    }

    public void RemoveDragonPortal()
    {
        if (buildMenu.m_dragonPortalsNum > 0)
        {
            buildMenu.m_dragonPortalsNum--;
            buildController.m_totalGold -= buildMenu.gameItemList.dragonPortal.goldCost;
            buildController.m_totalShard -= buildMenu.gameItemList.dragonPortal.shardCost;
        }
    }

    public void AntiAirTurretButton()
    {
        buildMenu.previousImage.SetActive(false);
        antiAirTurretImage.SetActive(true);
        buildMenu.previousImage = antiAirTurretImage;
        m_shardsCostText.text = buildMenu.gameItemList.antiAirTurret.shardCost.ToString();
        m_goldCostText.text = buildMenu.gameItemList.antiAirTurret.goldCost.ToString();
        m_healthText.text = buildMenu.gameItemList.antiAirTurret.health.ToString();
        m_attackText.text = buildMenu.gameItemList.antiAirTurret.attack.ToString();
    }

    public void AddAntiAirTurret()
    {
        buildMenu.m_antiAirTurretNum += 1;
        buildController.m_totalGold += buildMenu.gameItemList.antiAirTurret.goldCost;
        buildController.m_totalShard += buildMenu.gameItemList.antiAirTurret.shardCost;
    }

    public void RemoveAntiAirTurret()
    {
        if (buildMenu.m_antiAirTurretNum > 0)
        {
            buildMenu.m_antiAirTurretNum--;
            buildController.m_totalGold -= buildMenu.gameItemList.antiAirTurret.goldCost;
            buildController.m_totalShard -= buildMenu.gameItemList.antiAirTurret.shardCost;
        }
    }

    public void MinesButton()
    {
        buildMenu.previousImage.SetActive(false);
        minesImage.SetActive(true);
        buildMenu.previousImage = minesImage;
        m_shardsCostText.text = buildMenu.gameItemList.mine.shardCost.ToString();
        m_goldCostText.text = buildMenu.gameItemList.mine.goldCost.ToString();
        m_healthText.text = buildMenu.gameItemList.mine.health.ToString();
        m_attackText.text = buildMenu.gameItemList.mine.attack.ToString();
    }

    public void AddMines()
    {
        buildMenu.m_minesNum += 1;
        buildController.m_totalGold += buildMenu.gameItemList.mine.goldCost;
        buildController.m_totalShard += buildMenu.gameItemList.mine.shardCost;
    }

    public void RemoveMines()
    {
        if (buildMenu.m_minesNum > 0)
        {
            buildMenu.m_minesNum--;
            buildController.m_totalGold -= buildMenu.gameItemList.mine.goldCost;
            buildController.m_totalShard -= buildMenu.gameItemList.mine.shardCost;
        }
    }

    public void WallButton()
    {
        buildMenu.previousImage.SetActive(false);
        wallImage.SetActive(true);
        buildMenu.previousImage = wallImage;
        m_shardsCostText.text = buildMenu.gameItemList.wall.shardCost.ToString();
        m_goldCostText.text = buildMenu.gameItemList.wall.goldCost.ToString();
        m_healthText.text = buildMenu.gameItemList.wall.health.ToString();
        m_attackText.text = buildMenu.gameItemList.wall.attack.ToString();
    }

    public void AddWall()
    {
        buildMenu.m_wallNum += 1;
        buildController.m_totalGold += buildMenu.gameItemList.wall.goldCost;
        buildController.m_totalShard += buildMenu.gameItemList.wall.shardCost;
    }

    public void RemoveWall()
    {
        if (buildMenu.m_wallNum > 0)
        {
            buildMenu.m_wallNum--;
            buildController.m_totalGold += buildMenu.gameItemList.barracks.goldCost;
            buildController.m_totalShard += buildMenu.gameItemList.barracks.shardCost;
        }
    }

    void SetNumbersText()
    {
        m_barracksNumText.text = buildMenu.m_barracksNum.ToString();
        m_dragonPortalNumText.text = buildMenu.m_dragonPortalsNum.ToString();
        m_minesNumText.text = buildMenu.m_minesNum.ToString();
        m_wallNumText.text = buildMenu.m_wallNum.ToString();
        m_antiAirTurretNumText.text = buildMenu.m_antiAirTurretNum.ToString();
    }
}
