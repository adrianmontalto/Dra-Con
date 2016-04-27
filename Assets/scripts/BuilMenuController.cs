using UnityEngine;
using System.Collections;

public class BuilMenuController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject buildPanel;
    public GameObject unitPanel;
    public GameObject buildingPanel;
    public GameObject initPanel;
    private GameObject previousPanel;

	// Use this for initialization
	void Start ()
    {
        previousPanel = initPanel;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void UnitButtonClick()
    {
        previousPanel.SetActive(false);
        unitPanel.SetActive(true);
        previousPanel = unitPanel;
    }

    public void BuildingButtonClick()
    {
        previousPanel.SetActive(false);
        buildingPanel.SetActive(true);
        previousPanel = buildingPanel;
    }

    public void BuildButtonClick()
    {
        buildPanel.SetActive(false);
        gameManager.playerTurn = false;
        gameManager.enemyTurn = true;
    }
}
