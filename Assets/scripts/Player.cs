﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public int m_health = 0;//players health
    public int m_gold = 0;//players gold
    public int m_shards = 0;//players shards
    public int m_dragonWarriorNum = 0;//the number of dragon warriors the player has
    public int m_dragonTankNum = 0;//the number of dragon tanks the player has
    public int m_dragonNum = 0;//the number of dragons the player has
    public int m_minerNum = 0;//the number of miners the player has
    public int m_advanceminerNum = 0;//the number of advance miners the player has
    public int m_barrackNum = 0;//the number of barracks the player has
    public int m_dragonPortalNum = 0;//the number or dragon portals the player has
    public int m_wallNum = 0;//the number of walls the player has
    public int m_antiAirTurretNum = 0;//the number of anti air turrets the player has
    public int m_mineNum = 0;//the number of mines the player has
    [HideInInspector]
    public List<GameItem> m_playerUnits = new List<GameItem>();//a list of all the players units and buildings
    [HideInInspector]
    public int m_unitNumber = 0;//the number of units the player has
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //calculate the number of units the player has
        m_unitNumber = m_dragonWarriorNum + m_dragonTankNum + m_dragonNum + m_minerNum + m_advanceminerNum;
    }
}
