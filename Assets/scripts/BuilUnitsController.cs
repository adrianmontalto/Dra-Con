using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuilUnitsController : MonoBehaviour
{
    public BuildMenu buildMenu;
    public BuilMenuController buildController;
    public GameObject minerImage;
    public GameObject advanceMinerImage;
    public GameObject dragonWarriorImage;
    public GameObject dragonTankImage;
    public GameObject dragonImage;
    public Text shardsCostText;
    public Text goldCostText;
    public Text healthText;
    public Text attackText;
    public Text minerNumText;
    public Text advanceMinerNumText;
    public Text dragonWarriorNumText;
    public Text dragonTankNumText;
    public Text dragonNumText;

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
        SetUnitNumbersText();
    }

    public void MinerButtonClick()
    {
        buildMenu.previousImage.SetActive(false);
        minerImage.SetActive(true);
        buildMenu.previousImage = minerImage;
        shardsCostText.text = buildMenu.miner.shardCost.ToString();
        goldCostText.text = buildMenu.miner.goldCost.ToString();
        healthText.text = buildMenu.miner.health.ToString();
        attackText.text = buildMenu.miner.attack.ToString();
    }

    public void AddMiner()
    {
        buildMenu.minerNum ++;
        buildController.totalGold += buildMenu.miner.goldCost;
        buildController.totalShard += buildMenu.miner.shardCost;        
    }

    public void RemoveMiner()
    {
        if(buildMenu.minerNum > 0)
        {
            buildMenu.minerNum --;
            buildController.totalGold -= buildMenu.miner.goldCost;
            buildController.totalShard -= buildMenu.miner.shardCost;
        }
    }

    public void AdvanceMinerButtonClick()
    {
        buildMenu.previousImage.SetActive(false);
        advanceMinerImage.SetActive(true);
        buildMenu.previousImage = advanceMinerImage;
        shardsCostText.text = buildMenu.advanceMiner.shardCost.ToString();
        goldCostText.text = buildMenu.advanceMiner.goldCost.ToString();
        healthText.text = buildMenu.advanceMiner.health.ToString();
        attackText.text = buildMenu.advanceMiner.attack.ToString();
    }


    public void AddAdvanceMiner()
    {
        buildMenu.advanceMinerNum ++;
        buildController.totalGold += buildMenu.advanceMiner.goldCost;
        buildController.totalShard += buildMenu.advanceMiner.shardCost;
    }

    public void RemoveAdvanceMiner()
    {
        if(buildMenu.advanceMinerNum > 0)
        {
            buildMenu.advanceMinerNum --;
            buildController.totalGold -= buildMenu.advanceMiner.goldCost;
            buildController.totalShard -= buildMenu.advanceMiner.shardCost;
        }
    }

    public void  DragonWarriorButtonClick()
    {
        buildMenu.previousImage.SetActive(false);
        dragonWarriorImage.SetActive(true);
        buildMenu.previousImage = dragonWarriorImage;
        shardsCostText.text = buildMenu.dragonWarrior.shardCost.ToString();
        goldCostText.text = buildMenu.dragonWarrior.goldCost.ToString();
        healthText.text = buildMenu.dragonWarrior.health.ToString();
        attackText.text = buildMenu.dragonWarrior.attack.ToString();
    }

    public void AddDragonWarrior()
    {
        buildMenu.dragonWarriorNum ++;
        buildController.totalGold += buildMenu.dragonWarrior.goldCost;
        buildController.totalShard += buildMenu.dragonWarrior.shardCost;
    }

    public void RemoveDragonWarrior()
    {
        if(buildMenu.dragonWarriorNum > 0)
        {
            buildMenu.dragonWarriorNum --;
            buildController.totalGold -= buildMenu.dragonWarrior.goldCost;
            buildController.totalShard -= buildMenu.dragonWarrior.shardCost;
        }
    }

    public void  DragonTankButtonClick()
    {
        buildMenu.previousImage.SetActive(false);
        dragonTankImage.SetActive(true);
        buildMenu.previousImage = dragonTankImage;
        shardsCostText.text = buildMenu.dragonTank.shardCost.ToString();
        goldCostText.text = buildMenu.dragonTank.goldCost.ToString();
        healthText.text = buildMenu.dragonTank.health.ToString();
        attackText.text = buildMenu.dragonTank.attack.ToString();
    }
    
    public void AddDragonTank()
    {
        buildMenu.dragonTankNum ++;
        buildController.totalGold += buildMenu.dragonTank.goldCost;
        buildController.totalShard += buildMenu.dragonTank.shardCost;
    }

    public void RemoveDragonTank()
    {
        if(buildMenu.dragonTankNum > 0)
        {
            buildMenu.dragonTankNum --;
            buildController.totalGold -= buildMenu.dragonTank.goldCost;
            buildController.totalShard -= buildMenu.dragonTank.shardCost;
        }
    }

    public void  DragonButtonClick()
    {
        buildMenu.previousImage.SetActive(false);
        dragonImage.SetActive(true);
        buildMenu.previousImage = dragonImage;
        shardsCostText.text = buildMenu.dragon.shardCost.ToString();
        goldCostText.text = buildMenu.dragon.goldCost.ToString();
        healthText.text = buildMenu.dragon.health.ToString();
        attackText.text = buildMenu.dragon.attack.ToString();
    }

    public void AddDragon()
    {
        buildMenu.dragonNum ++;
        buildController.totalGold += buildMenu.dragon.goldCost;
        buildController.totalShard += buildMenu.dragon.shardCost;
    }

    public void RemoveDragon()
    {
        if(buildMenu.dragonNum > 0)
        {
            buildMenu.dragonNum --;
            buildController.totalGold -= buildMenu.dragon.goldCost;
            buildController.totalShard -= buildMenu.dragon.shardCost;
        }
    }

    void SetUnitNumbersText()
    {
        minerNumText.text = buildMenu.minerNum.ToString();
        advanceMinerNumText.text = buildMenu.advanceMinerNum.ToString();
        dragonWarriorNumText.text = buildMenu.dragonWarriorNum.ToString();
        dragonTankNumText.text = buildMenu.dragonTankNum.ToString();
        dragonNumText.text = buildMenu.dragonNum.ToString();
    }
}
