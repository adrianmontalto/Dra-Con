using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public WinningGoalsManager winGoal;
    public GameObject playerTurnIndicator;
    public GameObject enemyTurnIndicator;
    public GameObject playerAttackPanel;

    [HideInInspector]
    public bool playerIndicatorON = false;
    [HideInInspector]
    public bool enemyIndicatorOn = false;
    [HideInInspector]
    public bool playerTurn = false;
    [HideInInspector]
    public bool enemyTurn = false;

	// Use this for initialization
	void Start ()
    {
        playerTurn = true;	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(playerTurn == true && playerIndicatorON == false)
        {
            playerAttackPanel.SetActive(true);
            enemyTurnIndicator.SetActive(false);
            enemyIndicatorOn = false;
            playerTurnIndicator.SetActive(true);
            playerIndicatorON = true;
        }

        if(enemyTurn == true && enemyIndicatorOn == false)
        {
            playerAttackPanel.SetActive(false);
            playerTurnIndicator.SetActive(false);
            playerIndicatorON = false;
            enemyTurnIndicator.SetActive(true);
            enemyIndicatorOn = true;
        }

        if(enemy.m_health < 0)
        {
            if((player.m_gold == winGoal.goldNeeded) &&(player.m_shards == winGoal.shardsNeeded))
            {
                SceneManager.LoadScene("PlayerWin");
            }
            else
            {
                SceneManager.LoadScene("EnemyWin");
            }
        }

        if (player.m_health < 0)
        {
            if ((enemy.m_gold == winGoal.goldNeeded) && (enemy.m_shards == winGoal.shardsNeeded))
            {
                SceneManager.LoadScene("EnemyWin");
            }
            else
            {
                SceneManager.LoadScene("PlayerWin");
            }
        }
    }
}
