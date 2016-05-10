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
        healthText.text = enemy.m_health.ToString();
        SetResourceText();
        SetUnitsText();
        SetBuildingsText();
        SetDefenseText();
    }

    void SetResourceText()
    {
        goldText.text = enemy.m_gold.ToString();
        shardsText.text = enemy.m_shards.ToString();
    }

    void SetUnitsText()
    {
        dragonWarriorsText.text = enemy.m_dragonWarriorNum.ToString();
        dragonTanksText.text = enemy.m_dragonTankNum.ToString();
        dragonsText.text = enemy.m_dragonNum.ToString();
        minersText.text = enemy.m_minerNum.ToString();
        advanceminersText.text = enemy.m_advanceminerNum.ToString();
    }

    void SetBuildingsText()
    {
        barracksText.text = enemy.m_barrackNum.ToString();
        dragonPortalText.text = enemy.m_dragonPortalNum.ToString();
    }

    void SetDefenseText()
    {
        wallsText.text = enemy.m_wallNum.ToString();
        antiAirTurretsText.text = enemy.m_antiAirTurretNum.ToString();
        minesText.text = enemy.m_mineNum.ToString();
    }
}
