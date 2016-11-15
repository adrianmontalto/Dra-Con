using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player m_player;
    [SerializeField]
    private Enemy m_enemy;
    [SerializeField]
    private WinningGoalsManager winGoal;
    [SerializeField]
    private GameObject m_playerTurnIndicator;
    [SerializeField]
    private GameObject m_enemyTurnIndicator;
    [SerializeField]
    private GameObject m_playerAttackPanel;

    private bool m_playerIndicatorON = false;
    private bool m_enemyIndicatorOn = false;
    private bool m_playerTurn = false;
    private bool m_enemyTurn = false;

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

        if(enemy.GetHealth() < 0)
        {
            if((player.GetGold() == winGoal.goldNeeded) &&(player.m_shards == winGoal.shardsNeeded))
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

    public void SetPlayerTurn(bool isTurn)
    {
        m_playerTurn
    }
}
