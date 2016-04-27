using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameManager gameManager;
    public int health = 0;
    public int gold = 0;
    public int shards = 0;
    public int dragonWarriors = 0;
    public int dragonTanks = 0;
    public int dragons = 0;
    public int miners = 0;
    public int advanceminers = 0;
    public int barracks = 0;
    public int dragonPortals = 0;
    public int walls = 0;
    public int antiAirTurrets = 0;
    public int mines = 0;

    public Text healthText;
    public Text goldText;
    public Text shardsText;
    public Text dragonWarriorsText;
    public Text dragonTanksText;
    public Text dragonsText;
    public Text minersText;
    public Text advanceminersText;
    public Text barracksText;
    public Text dragonPortalText;
    public Text WallsText;
    public Text antiAirTurretsText;
    public Text minesText;

    private float turnTimer = 5.0f;
    private float resetTurnTimer = 5.0f;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthText.text = health.ToString();
        SetResourceText();
        SetUnitText();
        SetBuildingsText();
        SetDefenseText();
        turnTimer -= Time.deltaTime;
        if (turnTimer < 0)
        {
            gameManager.enemyTurn = false;
            gameManager.playerTurn = true;
            turnTimer = resetTurnTimer;
        }
    }

    void SetResourceText()
    {
        goldText.text = gold.ToString();
        shardsText.text = shards.ToString();
    }

    void SetUnitText()
    {
        dragonWarriorsText.text = dragonWarriors.ToString();
        dragonTanksText.text = dragonTanks.ToString();
        dragonsText.text = dragons.ToString();
        minersText.text = miners.ToString();
        advanceminersText.text = advanceminers.ToString();
    }

    void SetBuildingsText()
    {
        barracksText.text = barracks.ToString();
        dragonPortalText.text = dragonPortals.ToString();
    }

    void SetDefenseText()
    {
        WallsText.text = walls.ToString();
        antiAirTurretsText.text = antiAirTurrets.ToString();
        minesText.text = mines.ToString();
    }
}
