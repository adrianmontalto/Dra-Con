using UnityEngine;
using System.Collections;

public class BuildingsBuilderController : MonoBehaviour
{
    public GameObject barracksImage;
    public GameObject dragonPortalImage;
    public GameObject antiAirTurretImage;
    public GameObject minesImage;
    public GameObject wallImage;      
    public BuildMenu buildMenu;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void BarracksButton()
    {
        buildMenu.previousImage.SetActive(false);
        barracksImage.SetActive(true);
        buildMenu.previousImage = barracksImage;
    }

    public void AddBarracks()
    {
        buildMenu.barracksNum ++;
        Debug.Log("barracks::" + buildMenu.barracksNum);
    }

    public void RemoveBarracks()
    {
        if(buildMenu.barracksNum > 0)
        {
            buildMenu.barracksNum--;
            Debug.Log("barracks::" + buildMenu.barracksNum);
        }       
    }

    public void DragonPortalButton()
    {
        buildMenu.previousImage.SetActive(false);
        dragonPortalImage.SetActive(true);
        buildMenu.previousImage = dragonPortalImage;
    }

    public void AddDragonPortal()
    {
        buildMenu.dragonPortalsNum++;
        Debug.Log("DragonPortal::" + buildMenu.dragonPortalsNum);
    }

    public void RemoveDragonPortal()
    {
        if (buildMenu.dragonPortalsNum > 0)
        {
            buildMenu.dragonPortalsNum--;
            Debug.Log("DragonPortal::" + buildMenu.dragonPortalsNum);
        }
    }

    public void AntiAirTurretButton()
    {
        buildMenu.previousImage.SetActive(false);
        antiAirTurretImage.SetActive(true);
        buildMenu.previousImage = antiAirTurretImage;
    }

    public void AddAntiAirTurret()
    {
        buildMenu.antiAirTurretNum++;
        Debug.Log("antiAirTurret::" + buildMenu.antiAirTurretNum);
    }

    public void RemoveAntiAirTurret()
    {
        if (buildMenu.dragonPortalsNum > 0)
        {
            buildMenu.antiAirTurretNum--;
            Debug.Log("antiAirTurret::" + buildMenu.antiAirTurretNum);
        }
    }

    public void MinesButton()
    {
        buildMenu.previousImage.SetActive(false);
        minesImage.SetActive(true);
        buildMenu.previousImage = minesImage;
    }

    public void AddMines()
    {
        buildMenu.minesNum++;
        Debug.Log("mines::" + buildMenu.minesNum);
    }

    public void RemoveMines()
    {
        if (buildMenu.dragonPortalsNum > 0)
        {
            buildMenu.minesNum--;
            Debug.Log("mines::" + buildMenu.minesNum);
        }
    }

    public void WallButton()
    {
        buildMenu.previousImage.SetActive(false);
        wallImage.SetActive(true);
        buildMenu.previousImage = wallImage;
    }

    public void AddWall()
    {
        buildMenu.wallNum++;
        Debug.Log("wall::" + buildMenu.wallNum);
    }

    public void RemoveWall()
    {
        if (buildMenu.dragonPortalsNum > 0)
        {
            buildMenu.wallNum--;
            Debug.Log("wall::" + buildMenu.wallNum);
        }
    }
}
