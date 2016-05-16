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
    public Text m_shardsCostText;
    public Text m_goldCostText;
    public Text m_healthText;
    public Text m_attackText;
    public Text m_minerNumText;
    public Text m_advanceMinerNumText;
    public Text m_dragonWarriorNumText;
    public Text m_dragonTankNumText;
    public Text m_dragonNumText;

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
        SetUnitNumbersText();
    }

    public void MinerButtonClick()
    {
        buildMenu.previousImage.SetActive(false);
        minerImage.SetActive(true);
        buildMenu.previousImage = minerImage;
        m_shardsCostText.text = buildMenu.gameItemList.miner.shardCost.ToString();
        m_goldCostText.text = buildMenu.gameItemList.miner.goldCost.ToString();
        m_healthText.text = buildMenu.gameItemList.miner.health.ToString();
        m_attackText.text = buildMenu.gameItemList.miner.attack.ToString();
    }

    public void AddMiner()
    {
        buildMenu.m_minerNum ++;
        buildController.m_totalGold += buildMenu.gameItemList.miner.goldCost;
        buildController.m_totalShard += buildMenu.gameItemList.miner.shardCost;        
    }

    public void RemoveMiner()
    {
        if(buildMenu.m_minerNum > 0)
        {
            buildMenu.m_minerNum --;
            buildController.m_totalGold -= buildMenu.gameItemList.miner.goldCost;
            buildController.m_totalShard -= buildMenu.gameItemList.miner.shardCost;
        }
    }

    public void AdvanceMinerButtonClick()
    {
        buildMenu.previousImage.SetActive(false);
        advanceMinerImage.SetActive(true);
        buildMenu.previousImage = advanceMinerImage;
        m_shardsCostText.text = buildMenu.gameItemList.advanceMiner.shardCost.ToString();
        m_goldCostText.text = buildMenu.gameItemList.advanceMiner.goldCost.ToString();
        m_healthText.text = buildMenu.gameItemList.advanceMiner.health.ToString();
        m_attackText.text = buildMenu.gameItemList.advanceMiner.attack.ToString();
    }


    public void AddAdvanceMiner()
    {
        buildMenu.m_advanceMinerNum ++;
        buildController.m_totalGold += buildMenu.gameItemList.advanceMiner.goldCost;
        buildController.m_totalShard += buildMenu.gameItemList.advanceMiner.shardCost;
    }

    public void RemoveAdvanceMiner()
    {
        if(buildMenu.m_advanceMinerNum > 0)
        {
            buildMenu.m_advanceMinerNum --;
            buildController.m_totalGold -= buildMenu.gameItemList.advanceMiner.goldCost;
            buildController.m_totalShard -= buildMenu.gameItemList.advanceMiner.shardCost;
        }
    }

    public void  DragonWarriorButtonClick()
    {
        buildMenu.previousImage.SetActive(false);
        dragonWarriorImage.SetActive(true);
        buildMenu.previousImage = dragonWarriorImage;
        m_shardsCostText.text = buildMenu.gameItemList.dragonWarrior.shardCost.ToString();
        m_goldCostText.text = buildMenu.gameItemList.dragonWarrior.goldCost.ToString();
        m_healthText.text = buildMenu.gameItemList.dragonWarrior.health.ToString();
        m_attackText.text = buildMenu.gameItemList.dragonWarrior.attack.ToString();
    }

    public void AddDragonWarrior()
    {
        buildMenu.m_dragonWarriorNum ++;
        buildController.m_totalGold += buildMenu.gameItemList.dragonWarrior.goldCost;
        buildController.m_totalShard += buildMenu.gameItemList.dragonWarrior.shardCost;
    }

    public void RemoveDragonWarrior()
    {
        if(buildMenu.m_dragonWarriorNum > 0)
        {
            buildMenu.m_dragonWarriorNum --;
            buildController.m_totalGold -= buildMenu.gameItemList.dragonWarrior.goldCost;
            buildController.m_totalShard -= buildMenu.gameItemList.dragonWarrior.shardCost;
        }
    }

    public void  DragonTankButtonClick()
    {
        buildMenu.previousImage.SetActive(false);
        dragonTankImage.SetActive(true);
        buildMenu.previousImage = dragonTankImage;
        m_shardsCostText.text = buildMenu.gameItemList.dragonTank.shardCost.ToString();
        m_goldCostText.text = buildMenu.gameItemList.dragonTank.goldCost.ToString();
        m_healthText.text = buildMenu.gameItemList.dragonTank.health.ToString();
        m_attackText.text = buildMenu.gameItemList.dragonTank.attack.ToString();
    }
    
    public void AddDragonTank()
    {
        buildMenu.m_dragonTankNum ++;
        buildController.m_totalGold += buildMenu.gameItemList.dragonTank.goldCost;
        buildController.m_totalShard += buildMenu.gameItemList.dragonTank.shardCost;
    }

    public void RemoveDragonTank()
    {
        if(buildMenu.m_dragonTankNum > 0)
        {
            buildMenu.m_dragonTankNum --;
            buildController.m_totalGold -= buildMenu.gameItemList.dragonTank.goldCost;
            buildController.m_totalShard -= buildMenu.gameItemList.dragonTank.shardCost;
        }
    }

    public void  DragonButtonClick()
    {
        buildMenu.previousImage.SetActive(false);
        dragonImage.SetActive(true);
        buildMenu.previousImage = dragonImage;
        m_shardsCostText.text = buildMenu.gameItemList.dragon.shardCost.ToString();
        m_goldCostText.text = buildMenu.gameItemList.dragon.goldCost.ToString();
        m_healthText.text = buildMenu.gameItemList.dragon.health.ToString();
        m_attackText.text = buildMenu.gameItemList.dragon.attack.ToString();
    }

    public void AddDragon()
    {
        buildMenu.m_dragonNum ++;
        buildController.m_totalGold += buildMenu.gameItemList.dragon.goldCost;
        buildController.m_totalShard += buildMenu.gameItemList.dragon.shardCost;
    }

    public void RemoveDragon()
    {
        if(buildMenu.m_dragonNum > 0)
        {
            buildMenu.m_dragonNum --;
            buildController.m_totalGold -= buildMenu.gameItemList.dragon.goldCost;
            buildController.m_totalShard -= buildMenu.gameItemList.dragon.shardCost;
        }
    }

    void SetUnitNumbersText()
    {
        m_minerNumText.text = buildMenu.m_minerNum.ToString();
        m_advanceMinerNumText.text = buildMenu.m_advanceMinerNum.ToString();
        m_dragonWarriorNumText.text = buildMenu.m_dragonWarriorNum.ToString();
        m_dragonTankNumText.text = buildMenu.m_dragonTankNum.ToString();
        m_dragonNumText.text = buildMenu.m_dragonNum.ToString();
    }
}
