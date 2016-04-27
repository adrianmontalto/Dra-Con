using UnityEngine;
using System.Collections;

public class AttackPanelController : MonoBehaviour
{
    public GameManager gameManger;
    public GameObject attackPanel;
    private int dragonWarriorsNum = 0;
    private int dragonTanksNum = 0;
    private int dragonsNum = 0;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void AddDragonWarrior()
    {
        dragonWarriorsNum ++;
        Debug.Log(dragonWarriorsNum);
    }

    public void RemoveDragonWarrior()
    {
        if(dragonWarriorsNum > 0)
        {
            dragonWarriorsNum --;
            Debug.Log(dragonWarriorsNum);
        }
    }

    public void AddDragonTanks()
    {
        dragonTanksNum ++;
        Debug.Log(dragonTanksNum);
    }

    public void RemoveDragonTanks()
    {
        if(dragonTanksNum > 0)
        {
            dragonTanksNum --;
            Debug.Log(dragonTanksNum);
        }
    }

    public void AddDragon()
    {
        dragonsNum ++;
        Debug.Log(dragonsNum);
    }

    public void RemoveDragons()
    {
        if(dragonsNum > 0)
        {
            dragonsNum --;
            Debug.Log(dragonsNum);
        }
    }

    public void AttackButtonClick()
    {
        attackPanel.SetActive(false);
        gameManger.playerTurn = false;
        gameManger.enemyTurn = true;
    }
}
