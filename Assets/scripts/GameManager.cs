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
        m_playerTurn = true;	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(m_playerTurn == true && m_playerIndicatorON == false)
        {
            m_playerAttackPanel.SetActive(true);
            m_enemyTurnIndicator.SetActive(false);
            m_enemyIndicatorOn = false;
            m_playerTurnIndicator.SetActive(true);
            m_playerIndicatorON = true;
        }

        if(m_enemyTurn == true && m_enemyIndicatorOn == false)
        {
            m_playerAttackPanel.SetActive(false);
            m_playerTurnIndicator.SetActive(false);
            m_playerIndicatorON = false;
            m_enemyTurnIndicator.SetActive(true);
            m_enemyIndicatorOn = true;
        }

        if(m_enemy.GetHealth() < 0)
        {
            if((m_player.GetGold() == winGoal.goldNeeded) &&(m_player.m_shards == winGoal.shardsNeeded))
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
        m_playerTurn = isTurn;
    }

    public void SetEnemyTurn(bool isTurn)
    {
        m_enemyTurn = isTurn;
    }
}
