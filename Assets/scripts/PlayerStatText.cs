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
        healthText.text = player.m_health.ToString();
        SetResourceText();
        SetUnitsText();
        SetBuildingsText();
        SetDefenseText();
    }

    void SetResourceText()
    {
        goldText.text = player.m_gold.ToString();
        shardsText.text = player.m_shards.ToString();
    }

    void SetUnitsText()
    {
        dragonWarriorsText.text = player.m_dragonWarriorNum.ToString();
        dragonTanksText.text = player.m_dragonTankNum.ToString();
        dragonsText.text = player.m_dragonNum.ToString();
        minersText.text = player.m_minerNum.ToString();
        advanceminersText.text = player.m_advanceminerNum.ToString();
    }

    void SetBuildingsText()
    {
        barracksText.text = player.m_barrackNum.ToString();
        dragonPortalText.text = player.m_dragonPortalNum.ToString();
    }

    void SetDefenseText()
    {
        wallsText.text = player.m_wallNum.ToString();
        antiAirTurretsText.text = player.m_antiAirTurretNum.ToString();
        minesText.text = player.m_mineNum.ToString();
    }
}
