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
    private GameObject previousPanel = null;//the previous panel

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //controls the player unit button press
    public void PlayerUnitButtonOn()
    {
        if(previousPanel == null)
        {
            playerUnitPanel.SetActive(true);
            previousPanel = playerUnitPanel;            
        }

        if(previousPanel != null)
        {
            playerUnitPanel.SetActive(true);
            previousPanel.SetActive(false);
            previousPanel = playerUnitPanel;
        }
    }

    //controls the player defenses button
    public void PlayerDefensesButtonOn()
    {
        if (previousPanel == null)
        {
            playerDefensePanel.SetActive(true);
            previousPanel = playerDefensePanel;           
        }

        if (previousPanel != null)
        {
            playerDefensePanel.SetActive(true);
            previousPanel.SetActive(false);
            previousPanel = playerDefensePanel;
        }
    }
    
    //controls the player buildings button
    public void PlayerBuildingsButton()
    {
        if (previousPanel == null)
        {
            playerBuildingsPanel.SetActive(true);
            previousPanel = playerBuildingsPanel;            
        }

        if (previousPanel != null)
        {
            playerBuildingsPanel.SetActive(true);
            previousPanel.SetActive(false);
            previousPanel = playerBuildingsPanel;
        }
    }

    //controls the player unit button press
    public void EnemyUnitButtonOn()
    {
        if (previousPanel == null)
        {
            enemyUnitPanel.SetActive(true);
            previousPanel = enemyUnitPanel;            
        }

        if (previousPanel != null)
        {
            enemyUnitPanel.SetActive(true);
            previousPanel.SetActive(false);
            previousPanel = enemyUnitPanel;
        }
    }

    //controls the player defenses button
    public void EnemyDefensesButtonOn()
    {
        if (previousPanel == null)
        {
            enemyDefensePanel.SetActive(true);
            previousPanel = enemyDefensePanel;           
        }

        if (previousPanel != null)
        {
            enemyDefensePanel.SetActive(true);
            previousPanel.SetActive(false);
            previousPanel = enemyDefensePanel;
        }
    }

    //controls the player buildings button
    public void EnemyBuildingsButton()
    {
        if (previousPanel == null)
        {
            enemyBuildingsPanel.SetActive(true);
            previousPanel = enemyBuildingsPanel;           
        }

        if (previousPanel != null)
        {
            enemyBuildingsPanel.SetActive(true);
            previousPanel.SetActive(false);
            previousPanel = enemyBuildingsPanel;
        }
    }
}
