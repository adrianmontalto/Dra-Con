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
        dragonWarriorsText.text = player.dragonWarriorNum.ToString();
        dragonTanksText.text = player.dragonTankNum.ToString();
        dragonsText.text = player.dragonNum.ToString();
        minersText.text = player.minerNum.ToString();
        advanceminersText.text = player.advanceminerNum.ToString();
    }

    void SetBuildingsText()
    {
        barracksText.text = player.barrackNum.ToString();
        dragonPortalText.text = player.dragonPortalNum.ToString();
    }

    void SetDefenseText()
    {
        wallsText.text = player.wallNum.ToString();
        antiAirTurretsText.text = player.antiAirTurretNum.ToString();
        minesText.text = player.mineNum.ToString();
    }
}
