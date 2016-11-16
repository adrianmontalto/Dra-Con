using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatText : MonoBehaviour
{
    [SerializeField]
    private Player player;
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
        healthText.text = player.GetHealth().ToString();
        SetResourceText();
        SetUnitsText();
        SetBuildingsText();
        SetDefenseText();
    }

    void SetResourceText()
    {
        goldText.text = player.GetGold().ToString();
        shardsText.text = player.GetShards().ToString();
    }

    void SetUnitsText()
    {
        dragonWarriorsText.text = player.GetDragonWarriorNumber().ToString();
        dragonTanksText.text = player.GetDragonTankNumber().ToString();
        dragonsText.text = player.GetDragonNumber().ToString();
        minersText.text = player.GetMinerNumber().ToString();
        advanceminersText.text = player.GetAdvanceMinerNumber().ToString();
    }

    void SetBuildingsText()
    {
        barracksText.text = player.GetBarracksNumber().ToString();
        dragonPortalText.text = player.GetDragonPortalNumber().ToString();
    }

    void SetDefenseText()
    {
        wallsText.text = player.GetWallNumber().ToString();
        antiAirTurretsText.text = player.GetAntiAirTurretNumber().ToString();
        minesText.text = player.GetMineNumber().ToString();
    }
}
