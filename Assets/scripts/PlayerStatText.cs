using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatText : MonoBehaviour
{
    public Player player;
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
    public Text wallsText;
    public Text antiAirTurretsText;
    public Text minesText;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthText.text = player.health.ToString();
        SetResourceText();
        SetUnitsText();
        SetBuildingsText();
        SetDefenseText();
    }

    void SetResourceText()
    {
        goldText.text = player.gold.ToString();
        shardsText.text = player.shards.ToString();
    }

    void SetUnitsText()
    {
        dragonWarriorsText.text = player.dragonWarriors.ToString();
        dragonTanksText.text = player.dragonTanks.ToString();
        dragonsText.text = player.dragons.ToString();
        minersText.text = player.miners.ToString();
        advanceminersText.text = player.advanceminers.ToString();
    }

    void SetBuildingsText()
    {
        barracksText.text = player.barracks.ToString();
        dragonPortalText.text = player.dragonPortals.ToString();
    }

    void SetDefenseText()
    {
        wallsText.text = player.walls.ToString();
        antiAirTurretsText.text = player.antiAirTurrets.ToString();
        minesText.text = player.mines.ToString();
    }
}
