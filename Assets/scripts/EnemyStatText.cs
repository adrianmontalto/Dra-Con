using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyStatText : MonoBehaviour
{
    public Enemy enemy;
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
        healthText.text = enemy.health.ToString();
        SetResourceText();
        SetUnitsText();
        SetBuildingsText();
        SetDefenseText();
    }

    void SetResourceText()
    {
        goldText.text = enemy.gold.ToString();
        shardsText.text = enemy.shards.ToString();
    }

    void SetUnitsText()
    {
        dragonWarriorsText.text = enemy.dragonWarriorNum.ToString();
        dragonTanksText.text = enemy.dragonTankNum.ToString();
        dragonsText.text = enemy.dragonNum.ToString();
        minersText.text = enemy.minerNum.ToString();
        advanceminersText.text = enemy.advanceminerNum.ToString();
    }

    void SetBuildingsText()
    {
        barracksText.text = enemy.barrackNum.ToString();
        dragonPortalText.text = enemy.dragonPortalNum.ToString();
    }

    void SetDefenseText()
    {
        wallsText.text = enemy.wallNum.ToString();
        antiAirTurretsText.text = enemy.antiAirTurretNum.ToString();
        minesText.text = enemy.mineNum.ToString();
    }
}
