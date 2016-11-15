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
