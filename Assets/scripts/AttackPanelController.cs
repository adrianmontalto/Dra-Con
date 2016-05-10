using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttackPanelController : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public AttackMenu menu;
    public GameManager gameManger;
    public GameObject attackPanel;
    private int m_dragonWarriorsNum = 0;
    private int m_dragonTanksNum = 0;
    private int m_dragonsNum = 0;
    private int m_playerAttackdamage = 0;

    public Text m_dragonWarriorsAmountText;
    public Text m_dragonTankAmountText;
    public Text m_dragonAmountText;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_dragonWarriorsAmountText.text = m_dragonWarriorsNum.ToString();
        m_dragonTankAmountText.text = m_dragonTanksNum.ToString();
        m_dragonAmountText.text = m_dragonsNum.ToString();
    }

    public void AddDragonWarrior()
    {
        if(m_dragonWarriorsNum < player.m_dragonWarriorNum)
        {
            m_dragonWarriorsNum++;
        }        
    }

    public void RemoveDragonWarrior()
    {
        if(m_dragonWarriorsNum > 0)
        {
            m_dragonWarriorsNum --;
        }
    }

    public void AddDragonTanks()
    {
        if (m_dragonTanksNum < player.m_dragonTankNum)
        {
            m_dragonTanksNum++;
        }        
    }

    public void RemoveDragonTanks()
    {
        if(m_dragonTanksNum > 0)
        {
            m_dragonTanksNum --;
        }
    }

    public void AddDragon()
    {
        if (m_dragonsNum < player.m_dragonNum)
        {
            m_dragonsNum++;
        }       
    }

    public void RemoveDragons()
    {
        if(m_dragonsNum > 0)
        {
            m_dragonsNum --;
        }
    }

    public void AttackButtonClick()
    {
        CalculatePlayerAttackDamage();
        enemy.m_health -= m_playerAttackdamage;
        if (m_playerAttackdamage > 0)
        {
            AttackEnemy();
        }
        attackPanel.SetActive(false);
        gameManger.playerTurn = false;
        gameManger.enemyTurn = true;
    }

    void AttackEnemy()
    {
        if (enemy.m_wallNum > 0)
        {
            AttackEnemyWall();
        }
        else
        {
            AttackEnemyLastBuilt();
        }
    }

    void AttackEnemyWall()
    {
        int lastWall = enemy.m_enemyUnits.FindLastIndex((GameItem item) => { return item.objectName == "wall"; });

        if(lastWall > -1)
        {
           if(m_playerAttackdamage < enemy.m_enemyUnits[lastWall].health)
            {
                enemy.m_enemyUnits[lastWall].health -= m_playerAttackdamage;
            }
           else
            {
                m_playerAttackdamage -= enemy.m_enemyUnits[lastWall].health;
                enemy.m_enemyUnits.RemoveAt(lastWall);
                enemy.m_wallNum--;
                AttackEnemy();
            }
        }
    }

    void AttackEnemyLastBuilt()
    {
        int LastEnemy = enemy.m_enemyUnits.Count - 1;
        if(m_playerAttackdamage < enemy.m_enemyUnits[LastEnemy].health)
        {
            enemy.m_enemyUnits[LastEnemy].health -= m_playerAttackdamage;           
        }
        else
        {
            m_playerAttackdamage -= enemy.m_enemyUnits[LastEnemy].health;
            enemy.ReduceUnitNumber(enemy.m_enemyUnits[LastEnemy].objectName);
            enemy.m_enemyUnits.RemoveAt(LastEnemy);
            AttackEnemy();
        }
    }

    void CalculatePlayerAttackDamage()
    {
        for(int i = 0; i < m_dragonWarriorsNum;++i)
        {
            m_playerAttackdamage += menu.dragonWarrior.attack;
        }

        for(int i = 0; i < m_dragonTanksNum; ++i)
        {
            m_playerAttackdamage += menu.dragonTank.attack;
        }

        for(int i = 0; i < m_dragonsNum; ++ i)
        {
            m_playerAttackdamage += menu.dragon.attack;
        }
    }
}
