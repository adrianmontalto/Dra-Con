using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyStatText : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text goldText;
    [SerializeField]
    private Text shardsText;
    [SerializeField]
    private Text dragonWarriorsText;
    [SerializeField]
    private Text dragonTanksText;
    [SerializeField]
    private Text dragonsText;
    [SerializeField]
    private Text minersText;
    [SerializeField]
    private Text advanceminersText;
    [SerializeField]
    private Text barracksText;
    [SerializeField]
    private Text dragonPortalText;
    [SerializeField]
    private Text wallsText;
    [SerializeField]
    private Text antiAirTurretsText;
    [SerializeField]
    private Text minesText;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthText.text = enemy.GetHealth().ToString();
        SetResourceText();
        SetUnitsText();
        SetBuildingsText();
        SetDefenseText();
    }

    void SetResourceText()
    {
        goldText.text = enemy.GetGold().ToString();
        shardsText.text = enemy.GetShards().ToString();
    }

    void SetUnitsText()
    {
        dragonWarriorsText.text = enemy.GetDragonWarriorNumber().ToString();
        dragonTanksText.text = enemy.GetDragonTankNumber().ToString();
        dragonsText.text = enemy.GetDragonNumber().ToString();
        minersText.text = enemy.GetMinerNumber().ToString();
        advanceminersText.text = enemy.GetAdvanceMinerNumber().ToString();
    }

    void SetBuildingsText()
    {
        barracksText.text = enemy.GetBarracksNumber().ToString();
        dragonPortalText.text = enemy.GetDragonPortalNumber().ToString();
    }

    void SetDefenseText()
    {
        wallsText.text = enemy.GetWallNumber().ToString();
        antiAirTurretsText.text = enemy.GetAntiAirTurretNumber().ToString();
        minesText.text = enemy.GetMineNumber().ToString();
    }
}
