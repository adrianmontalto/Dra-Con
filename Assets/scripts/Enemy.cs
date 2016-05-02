using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Enemy : MonoBehaviour
{
    
    public GameManager gameManager;
    public int health = 0;
    public int gold = 0;
    public int shards = 0;
    public int dragonWarriorNum = 0;
    public int dragonTankNum = 0;
    public int dragonNum = 0;
    public int minerNum = 0;
    public int advanceminerNum = 0;
    public int barrackNum = 0;
    public int dragonPortalNum = 0;
    public int wallNum = 0;
    public int antiAirTurretNum = 0;
    public int mineNum = 0;
    public List<GameItem> enemyUnits = new List<GameItem>();
    private float turnTimer = 5.0f;
    private float resetTurnTimer = 5.0f;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        turnTimer -= Time.deltaTime;
        if (turnTimer < 0)
        {
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
            turnTimer = resetTurnTimer;
        }
    }

    public void ReduceUnitNumber(string unitName)
    {
        if(unitName == "barracks")
        {
            barrackNum --;
        }
        
        if(unitName == "dragonPortal")
        {
            dragonPortalNum --;
        }

        if(unitName == "antiAirTurret")
        {
            antiAirTurretNum --;
        }

        if(unitName == "mine")
        {
            mineNum --;
        }

        if (unitName == "miner")
        {
            minerNum --;
        }

        if (unitName == "advanceMiner")
        {
            advanceminerNum --;
        }

        if (unitName == "dragonWarrior")
        {
            dragonWarriorNum --;
        }

        if (unitName == "dragonTank")
        {
            dragonTankNum --;
        }

        if (unitName == "dragon")
        {
            dragonNum --;
        }
    }
}
