using UnityEngine;
using System.Collections;

public class PlayerDecisioncontroller : MonoBehaviour
{
    [SerializeField]
    private GameObject attackPanel;
    [SerializeField]
    private GameObject buildPanel;
    [SerializeField]
    private GameObject gatherPanel;
    [SerializeField]
    private GameObject initpanel;
    private GameObject previousPanel;

	// Use this for initialization
	void Start ()
    {
        previousPanel = initpanel;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void AttackButtonClick()
    {
        previousPanel.SetActive(false);
        attackPanel.SetActive(true);
        previousPanel = attackPanel;
    }

    public void BuildButtonClick()
    {
        previousPanel.SetActive(false);
        buildPanel.SetActive(true);
        previousPanel = buildPanel;
    }

    public void GatherButtonClick()
    {
        previousPanel.SetActive(false);
        gatherPanel.SetActive(true);
        previousPanel = gatherPanel;
    }
}
