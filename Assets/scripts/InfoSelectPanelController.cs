using UnityEngine;
using System.Collections;

public class InfoSelectPanelController : MonoBehaviour
{
    public GameObject playerUnitPanel;//the unit info panel
    public GameObject playerDefensePanel;//the defense info panel
    public GameObject playerBuildingsPanel;//the buildings info panel
    public GameObject enemyUnitPanel;//the unit info panel
    public GameObject enemyDefensePanel;//the defense info panel
    public GameObject enemyBuildingsPanel;//the buildings info panel
    public GameObject startPanel;//the initial panel
    private GameObject previousPanel;//the previous panel

	// Use this for initialization
	void Start ()
    {
        previousPanel = startPanel;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //controls the player unit button press
    public void PlayerUnitButtonOn()
    {
        previousPanel.SetActive(false);
        playerUnitPanel.SetActive(true);
        previousPanel = playerUnitPanel;
    }

    //controls the player defenses button
    public void PlayerDefensesButtonOn()
    {
        previousPanel.SetActive(false);
        playerDefensePanel.SetActive(true);
        previousPanel = playerDefensePanel;
    }
    
    //controls the player buildings button
    public void PlayerBuildingsButton()
    {
        previousPanel.SetActive(false);
        playerBuildingsPanel.SetActive(true);
        previousPanel = playerBuildingsPanel;
    }

    //controls the player unit button press
    public void EnemyUnitButtonOn()
    {
        previousPanel.SetActive(false);
        enemyUnitPanel.SetActive(true);
        previousPanel = enemyUnitPanel;
    }

    //controls the player defenses button
    public void EnemyDefensesButtonOn()
    {
        previousPanel.SetActive(false);
        enemyDefensePanel.SetActive(true);
        previousPanel = enemyDefensePanel;
    }

    //controls the player buildings button
    public void EnemyBuildingsButton()
    {
        previousPanel.SetActive(false);
        enemyBuildingsPanel.SetActive(true);
        previousPanel = enemyBuildingsPanel;
    }
}
