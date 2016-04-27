using UnityEngine;
using System.Collections;

public class BuilUnitsController : MonoBehaviour
{
    public GameObject minerImage;
    public GameObject advanceMinerImage;
    public GameObject dragonWarriorImage;
    public GameObject dragonTankImage;
    public GameObject dragonImage;
    public BuildMenu buildMenu;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void MinerButtonClick()
    {
        buildMenu.previousImage.SetActive(false);
        minerImage.SetActive(true);
        buildMenu.previousImage = minerImage;
    }

    public void AddMiner()
    {
        buildMenu.minerNum ++;
        Debug.Log("miner" + buildMenu.minerNum);
    }

    public void RemoveMiner()
    {
        if(buildMenu.minerNum > 0)
        {
            buildMenu.minerNum --;
            Debug.Log("miner" + buildMenu.minerNum);
        }
    }

    public void AdvanceMinerButtonClick()
    {
        buildMenu.previousImage.SetActive(false);
        advanceMinerImage.SetActive(true);
        buildMenu.previousImage = advanceMinerImage;
    }


    public void AddAdvanceMiner()
    {
        buildMenu.advanceMinerNum ++;
        Debug.Log("advanceMiner" + buildMenu.advanceMinerNum);
    }

    public void RemoveAdvanceMiner()
    {
        if(buildMenu.advanceMinerNum > 0)
        {
            buildMenu.advanceMinerNum --;
            Debug.Log("advanceMiner" + buildMenu.advanceMinerNum);
        }
    }

    public void  DragonWarriorButtonClick()
    {
        buildMenu.previousImage.SetActive(false);
        dragonWarriorImage.SetActive(true);
        buildMenu.previousImage = dragonWarriorImage;
    }

    public void AddDragonWarrior()
    {
        buildMenu.dragonWarriorNum ++;
        Debug.Log("dragonWarrior" + buildMenu.dragonWarriorNum);
    }

    public void RemoveDragonWarrior()
    {
        if(buildMenu.dragonWarriorNum > 0)
        {
            buildMenu.dragonWarriorNum --;
            Debug.Log("dragonWarrior" + buildMenu.dragonWarriorNum);
        }
    }

    public void  DragonTankButtonClick()
    {
        buildMenu.previousImage.SetActive(false);
        dragonTankImage.SetActive(true);
        buildMenu.previousImage = dragonTankImage;
    }
    
    public void AddDragonTank()
    {
        buildMenu.dragonTankNum ++;
        Debug.Log("dragonTank" + buildMenu.dragonTankNum);
    }

    public void RemoveDragonTank()
    {
        if(buildMenu.dragonTankNum > 0)
        {
            buildMenu.dragonTankNum --;
            Debug.Log("dragonTank" + buildMenu.dragonTankNum);
        }
    }

    public void  DragonButtonClick()
    {
        buildMenu.previousImage.SetActive(false);
        dragonImage.SetActive(true);
        buildMenu.previousImage = dragonImage;
    }

    public void AddDragon()
    {
        buildMenu.dragonNum ++;
        Debug.Log("dragon" + buildMenu.dragonNum);
    }

    public void RemoveDragon()
    {
        if(buildMenu.dragonNum > 0)
        {
            buildMenu.dragonNum --;
            Debug.Log("dragon" + buildMenu.dragonNum);
        }
    }
}
