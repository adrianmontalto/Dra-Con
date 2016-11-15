using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttackPanelController : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private GameItemList itemList;
    [SerializeField]
    private GameManager gameManger;
    [SerializeField]
    private GameObject attackPanel;
    [SerializeField]
    private int m_maxDragonWarriors;
    [SerializeField]
    private int m_maxDragonTanks;
    [SerializeField]
    private int m_maxDragons;

    private int m_dragonWarriorsNum = 0;
    private int m_dragonTanksNum = 0;
    private int m_dragonsNum = 0;
    private int m_groundUnitHealth = 0;
    private int m_playerAttackdamage = 0;

    [SerializeField]
    private Text m_dragonWarriorsAmountText;
    [SerializeField]
    private Text m_dragonTankAmountText;
    [SerializeField]
    private Text m_dragonAmountText;
    [SerializeField]
    private Text m_moveText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_dragonWarriorsAmountText.text = m_dragonWarriorsNum.ToString();
        m_dragonTankAmountText.text = m_dragonTanksNum.ToString();
        m_dragonAmountText.text = m_dragonsNum.ToString();
    }

    public void AddDragonWarrior()
    {
        if (m_dragonWarriorsNum < m_maxDragonWarriors)
        {
            if (m_dragonWarriorsNum < player.GetDragonWarriorNumber())
            {
                m_dragonWarriorsNum++;
            }
        }
    }

    public void RemoveDragonWarrior()
    {
        if (m_dragonWarriorsNum > 0)
        {
            m_dragonWarriorsNum--;
        }
    }

    public void AddDragonTanks()
    {
        if (m_dragonTanksNum < m_maxDragonTanks)
        {
            if (m_dragonTanksNum < player.GetDragonTankNumber())
            {
                m_dragonTanksNum++;
            }
        }
    }

    public void RemoveDragonTanks()
    {
        if (m_dragonTanksNum > 0)
        {
            m_dragonTanksNum--;
        }
    }

    public void AddDragon()
    {
        if (m_dragonsNum < m_maxDragons)
        {
            if (m_dragonsNum < player.GetDragonNumber())
            {
                m_dragonsNum++;
            }
        }
    }

    public void RemoveDragons()
    {
        if (m_dragonsNum > 0)
        {
            m_dragonsNum--;
        }
    }

    public void AttackButtonClick()
    {
        Debug.Log("");
        Debug.Log("player attack");
        Debug.Log("");
        CalculateDefenseDamage();
        CalculatePlayerAttackDamage();
       
        if (m_playerAttackdamage > 0)
        {
            AttackEnemy();
        }
        ResetUnitNumbers();
        enemy.ReduceHealth(m_playerAttackdamage);
        attackPanel.SetActive(false);
        player.SetMaxUnitNumber();
        enemy.SetMaxValues();
        gameManger.playerTurn = false;
        gameManger.enemyTurn = true;
        m_moveText.text = "Player Attacked";
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

        if (lastWall > -1)
        {
            if (m_playerAttackdamage < enemy.m_enemyUnits[lastWall].health)
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
        if (m_playerAttackdamage < enemy.m_enemyUnits[LastEnemy].health)
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
        for (int i = 0; i < m_dragonWarriorsNum; ++i)
        {
            m_playerAttackdamage += itemList.dragonWarrior.attack;
        }

        for (int i = 0; i < m_dragonTanksNum; ++i)
        {
            m_playerAttackdamage += itemList.dragonTank.attack;
        }

        for (int i = 0; i < m_dragonsNum; ++i)
        {
            m_playerAttackdamage += itemList.dragon.attack;
        }
    }

    void CalculateMineDamage()
    {
        //check to see if enemy has any mines
        if (enemy.m_mineNum > 0)
        {
            CalculateGrounUnitHealth();
            //calculate damage done to player ensuring that no excess mines are used
            int mineDamage = enemy.m_mineNum * itemList.mine.attack;
            if (mineDamage < m_groundUnitHealth)
            {
                //destroy all mines used
                enemy.DestroyMines(enemy.m_mineNum);
                //destroy any warriors and tanks killed by mines
                player.DestroyGroundUnit(mineDamage);
            }
            else
            {
                mineDamage = 0;
                int mineNum = 0;
                while (mineDamage < m_groundUnitHealth)
                {
                    mineNum++;
                    mineDamage += itemList.mine.attack;
                }
                //destroy all mines used
                player.DestroyMines(mineNum);
                //destroy any warriors and tanks killed from mines
                enemy.DestroyGroundUnit(mineDamage);
            }
        }
    }

    void CalculateAntiAirTurretDamage()
    {
        //check to see if the enemy has any anti air turrets
        if (enemy.m_antiAirTurretNum > 0)
        {
            //calculate damage from air turrets
            int turretDamage = player.m_antiAirTurretNum * itemList.antiAirTurret.attack;
            //claculate dragon health
            int dragonHealth = m_dragonsNum * itemList.dragon.health;
            if (turretDamage > dragonHealth)
            {
                turretDamage = dragonHealth;
            }
            player.DestroyDragons(turretDamage);
        }
    }

    void CalculateDefenseDamage()
    {
        //caluclate mine damage
        CalculateMineDamage();
        //calculate anti air turret damage
        CalculateAntiAirTurretDamage();
    }
    void CalculateGrounUnitHealth()
    {
        m_groundUnitHealth = ((m_dragonWarriorsNum * itemList.dragonWarrior.health) + 
                                (m_dragonTanksNum * itemList.dragonTank.health));
    }

    void ResetUnitNumbers()
    {
        m_dragonWarriorsNum = 0;
        m_dragonTanksNum = 0;
        m_dragonsNum = 0;
        m_groundUnitHealth = 0;
        m_playerAttackdamage = 0;
    }
}
