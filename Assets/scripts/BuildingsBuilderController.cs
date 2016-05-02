using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingsBuilderController : MonoBehaviour
{
    public GameObject barracksImage;
    public GameObject dragonPortalImage;
    public GameObject antiAirTurretImage;
    public GameObject minesImage;
    public GameObject wallImage;      
    public BuildMenu buildMenu;
    public BuilMenuController buildController;
    public Text shardsCostText;
    public Text goldCostText;
    public Text healthText;
    public Text attackText;
    public Text barracksNumText;
    public Text dragonPortalNumText;
    public Text minesNumText;
    public Text wallNumText;
    public Text antiAirTurretNumText;


	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        buildController.goldAmount.text = buildMenu.player.gold.ToString();
        buildController.totalGoldCostText.text = buildController.totalGold.ToString();
        buildController.shardAmountText.text = buildMenu.player.shards.ToString();
        buildController.totalShardCostText.text = buildController.totalShard.ToString();
        SetNumbersText();
    }

    public void BarracksButton()
    {
        buildMenu.previousImage.SetActive(false);
        barracksImage.SetActive(true);
        buildMenu.previousImage = barracksImage;
        shardsCostText.text = buildMenu.barracks.shardCost.ToString();
        goldCostText.text = buildMenu.barracks.goldCost.ToString();
        healthText.text = buildMenu.barracks.health.ToString();
        attackText.text = buildMenu.barracks.attack.ToString();
    }

    public void AddBarracks()
    {
        buildMenu.barracksNum ++;
        buildController.totalGold += buildMenu.barracks.goldCost;
        buildController.totalShard += buildMenu.barracks.shardCost;
    }

    public void RemoveBarracks()
    {
        if(buildMenu.barracksNum > 0)
        {
            buildMenu.barracksNum--;
            buildController.totalGold -= buildMenu.barracks.goldCost;
            buildController.totalShard -= buildMenu.barracks.shardCost;
        }       
    }

    public void DragonPortalButton()
    {
        buildMenu.previousImage.SetActive(false);
        dragonPortalImage.SetActive(true);
        buildMenu.previousImage = dragonPortalImage;
        shardsCostText.text = buildMenu.dragonPortal.shardCost.ToString();
        goldCostText.text = buildMenu.dragonPortal.goldCost.ToString();
        healthText.text = buildMenu.dragonPortal.health.ToString();
        attackText.text = buildMenu.dragonPortal.attack.ToString();
    }

    public void AddDragonPortal()
    {
        buildMenu.dragonPortalsNum++;
        buildController.totalGold += buildMenu.dragonPortal.goldCost;
        buildController.totalShard += buildMenu.dragonPortal.shardCost;
    }

    public void RemoveDragonPortal()
    {
        if (buildMenu.dragonPortalsNum > 0)
        {
            buildMenu.dragonPortalsNum--;
            buildController.totalGold -= buildMenu.dragonPortal.goldCost;
            buildController.totalShard -= buildMenu.dragonPortal.shardCost;
        }
    }

    public void AntiAirTurretButton()
    {
        buildMenu.previousImage.SetActive(false);
        antiAirTurretImage.SetActive(true);
        buildMenu.previousImage = antiAirTurretImage;
        shardsCostText.text = buildMenu.antiAirTurret.shardCost.ToString();
        goldCostText.text = buildMenu.antiAirTurret.goldCost.ToString();
        healthText.text = buildMenu.antiAirTurret.health.ToString();
        attackText.text = buildMenu.antiAirTurret.attack.ToString();
    }

    public void AddAntiAirTurret()
    {
        buildMenu.antiAirTurretNum++;
        buildController.totalGold += buildMenu.antiAirTurret.goldCost;
        buildController.totalShard += buildMenu.antiAirTurret.shardCost;
    }

    public void RemoveAntiAirTurret()
    {
        if (buildMenu.dragonPortalsNum > 0)
        {
            buildMenu.antiAirTurretNum--;
            buildController.totalGold -= buildMenu.antiAirTurret.goldCost;
            buildController.totalShard -= buildMenu.antiAirTurret.shardCost;
        }
    }

    public void MinesButton()
    {
        buildMenu.previousImage.SetActive(false);
        minesImage.SetActive(true);
        buildMenu.previousImage = minesImage;
        shardsCostText.text = buildMenu.mines.shardCost.ToString();
        goldCostText.text = buildMenu.mines.goldCost.ToString();
        healthText.text = buildMenu.mines.health.ToString();
        attackText.text = buildMenu.mines.attack.ToString();
    }

    public void AddMines()
    {
        buildMenu.minesNum++;
        buildController.totalGold += buildMenu.mines.goldCost;
        buildController.totalShard += buildMenu.mines.shardCost;
    }

    public void RemoveMines()
    {
        if (buildMenu.dragonPortalsNum > 0)
        {
            buildMenu.minesNum--;
            buildController.totalGold -= buildMenu.mines.goldCost;
            buildController.totalShard -= buildMenu.mines.shardCost;
        }
    }

    public void WallButton()
    {
        buildMenu.previousImage.SetActive(false);
        wallImage.SetActive(true);
        buildMenu.previousImage = wallImage;
        shardsCostText.text = buildMenu.wall.shardCost.ToString();
        goldCostText.text = buildMenu.wall.goldCost.ToString();
        healthText.text = buildMenu.wall.health.ToString();
        attackText.text = buildMenu.wall.attack.ToString();
    }

    public void AddWall()
    {
        buildMenu.wallNum++;
        buildController.totalGold += buildMenu.wall.goldCost;
        buildController.totalShard += buildMenu.wall.shardCost;
    }

    public void RemoveWall()
    {
        if (buildMenu.dragonPortalsNum > 0)
        {
            buildMenu.wallNum--;
            buildController.totalGold += buildMenu.barracks.goldCost;
            buildController.totalShard += buildMenu.barracks.shardCost;
        }
    }

    void SetNumbersText()
    {
        barracksNumText.text = buildMenu.barracksNum.ToString();
        dragonPortalNumText.text = buildMenu.dragonPortalsNum.ToString();
        minesNumText.text = buildMenu.minesNum.ToString();
        wallNumText.text = buildMenu.wallNum.ToString();
        antiAirTurretNumText.text = buildMenu.antiAirTurretNum.ToString();
    }
}
