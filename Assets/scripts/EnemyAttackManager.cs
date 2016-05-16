using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAttackManager : MonoBehaviour
{
    public Enemy enemy;
    public Player player;
    public GameManager gameManager;
    public GameItem dragonWarrior;
    public GameItem dragonTank;
    public GameItem dragon;
    public GameItem mine;
    public GameItem antiAirTurret;
    private UtilityValue m_lowAttackValue;
    private UtilityValue m_mediumAttackValue;
    private UtilityValue m_highAttackValue;
    public Dictionary<string, UtilityScore> m_utilityScoreMap = new Dictionary<string, UtilityScore>();
    private int m_mineDamage = 0;
    private int m_antiAirTurretDamage = 0;
    private int m_dragonWarriorNumber = 0;
    private int m_dragonTankNum = 0;
    private int m_dragonNum = 0;
    private int m_groundUnitHealth = 0;
    private int m_attackDamage = 0;

    // Use this for initialization
    void Start()
    {
        InitValues();
        SetScores();
    }

    // Update is called once per frame
    void Update()
    {
        //checks to see if it is the enemy turn
        if (gameManager.enemyTurn == true)
        {
            SelectAction();
        }
    }
    void InitValues()
    {
        m_lowAttackValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR, 0, 15);
        m_lowAttackValue.SetNormaliztionType(UtilityValue.NormalizationType.INVERSE_LINEAR);
        m_lowAttackValue.SetValue(enemy.m_closenessToWinGoal);

        m_mediumAttackValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 0, 10);
        m_mediumAttackValue.SetNormaliztionType(UtilityValue.NormalizationType.LINEAR);
        m_mediumAttackValue.SetValue(player.m_health);

        m_highAttackValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 0, 10);
        m_mediumAttackValue.SetNormaliztionType(UtilityValue.NormalizationType.LINEAR);
        m_highAttackValue.SetValue(enemy.m_closenessToWinGoal);
    }

    void SetValues()
    {
        m_lowAttackValue.SetValue(enemy.m_closenessToWinGoal);
        m_mediumAttackValue.SetValue(player.m_health);
        m_highAttackValue.SetValue(enemy.m_closenessToWinGoal);
    }

    void SetScores()
    {
        UtilityScore lowAttackScore = new UtilityScore();
        lowAttackScore.AddUtilityValue(m_lowAttackValue, 1.0f);
        m_utilityScoreMap.Add("lowAttack", lowAttackScore);

        UtilityScore mediumAttackScore = new UtilityScore();
        mediumAttackScore.AddUtilityValue(m_mediumAttackValue, 1.0f);
        m_utilityScoreMap.Add("mediumAttack", mediumAttackScore);

        UtilityScore highAttackScore = new UtilityScore();
        highAttackScore.AddUtilityValue(m_highAttackValue, 1.0f);
        m_utilityScoreMap.Add("highAttack", highAttackScore);
    }

    public void SelectAction()
    {
        SetValues();

        float bestScore = 0.0f;
        string strBestAction = "";

        foreach (KeyValuePair<string, UtilityScore> score in m_utilityScoreMap)
        {
            float thisScore = score.Value.GetUtilityScore();
            if (thisScore > bestScore)
            {
                bestScore = thisScore;
                strBestAction = score.Key;
            }
        }

        if (strBestAction == "lowAttack")
        {
            LowAttack();
        }

        if (strBestAction == "mediumAttack")
        {
            MediumAttack();
        }

        if (strBestAction == "highAttack")
        {
            HighAttack();
        }
    }

    void LowAttack()
    {
        DragonAttackNumber(20);
        DragonTankAttackNumber(10);
        DragonAttackNumber(5);
        CalculateDefenseDamage();
        CalculateAttackDamage();
        player.m_health -= m_attackDamage;
        if(m_attackDamage > 0)
        {
            AttackPlayer();
        }
        gameManager.enemyTurn = false;
        gameManager.playerTurn = true;
    }

    void MediumAttack()
    {
        DragonAttackNumber(40);
        DragonTankAttackNumber(20);
        DragonAttackNumber(10);
        CalculateDefenseDamage();
        CalculateAttackDamage();
        player.m_health -= m_attackDamage;
        if (m_attackDamage > 0)
        {
            AttackPlayer();
        }
        gameManager.enemyTurn = false;
        gameManager.playerTurn = true;
    }

    void HighAttack()
    {
        DragonAttackNumber(60);
        DragonTankAttackNumber(30);
        DragonAttackNumber(15);
        CalculateDefenseDamage();
        CalculateAttackDamage();
        player.m_health -= m_attackDamage;
        if (m_attackDamage > 0)
        {
            AttackPlayer();
        }
        gameManager.enemyTurn = false;
        gameManager.playerTurn = true;
    }

    void AttackPlayer()
    {
        //check to see if player has any walls
        if (player.m_wallNum > 0)
        {
            CalculateWallDamage();
        }
        else
        {
            CalculateLastBuiltDamage();
        }
    }

    void CalculateMineDamage()
    {
        //check to see if player has any mines
        if(player.m_mineNum > 0)
        {
            //calculate health of attacking dragon warriors and dragon tanks
            CalculateGroundUnitHealth();
            //calculate damage done to player ensurinbg that no excess mines are used
            m_mineDamage = player.m_mineNum * mine.attack;
            if(m_mineDamage < m_groundUnitHealth)
            {
                //destroy all mines used                
                player.DestroyMines(player.m_mineNum);
                //destroy any warriors and tanks killed from mines
                enemy.DestroyGroundUnit(m_mineDamage);
            }
            else
            {
                m_mineDamage = 0;
                int mineNum = 0;
                while(m_mineDamage < m_groundUnitHealth)
                {
                    mineNum++;
                    m_mineDamage += mine.attack;
                }
                //destroy all mines used                
                player.DestroyMines(mineNum);
                //destroy any warriors and tanks killed from mines
                enemy.DestroyGroundUnit(m_mineDamage);
            }          
        }
    }

    void CalculateAntiAirTurretDamage()
    {
        //check to see if player has any anti air turret
        if(player.m_antiAirTurretNum > 0)
        {
            //calculate damage from air turrets
            int turretDamage = player.m_antiAirTurretNum * antiAirTurret.attack;
            //calculate dragon health
            int dragonHealth = m_dragonNum * dragon.health;
            if(turretDamage > dragonHealth)
            {
                turretDamage = dragonHealth;
            }
            enemy.DestroyDragons(turretDamage);
        }
    }

    void CalculateAttackDamage()
    {
        m_dragonWarriorNumber -= enemy.m_dragonWarriorsDestroyed;
        m_dragonTankNum -= enemy.m_dragonTanksDestroyed;
        m_dragonNum -= enemy.m_dragonsDestroyed;
        m_attackDamage = (m_dragonWarriorNumber * dragonWarrior.attack) + 
                            (m_dragonTankNum * dragonTank.attack) + 
                            (m_dragonNum * dragon.attack);
    }

    void CalculateWallDamage()
    {
        int lastWall = player.m_playerUnits.FindLastIndex((GameItem item) => { return item.objectName == "wall"; });

        if(lastWall > -1)
        {
            if(m_attackDamage < player.m_playerUnits[lastWall].health)
            {
                player.m_playerUnits[lastWall].health -= m_attackDamage;
            }
            else
            {
                m_attackDamage -= player.m_playerUnits[lastWall].health;
                player.m_playerUnits.RemoveAt(lastWall);
                player.m_wallNum--;
                AttackPlayer();
            }
        }
    }

    void CalculateLastBuiltDamage()
    {
        int LastBuilt = player.m_playerUnits.Count - 1;
        if(m_attackDamage < player.m_playerUnits[LastBuilt].health)
        {
            player.m_playerUnits[LastBuilt].health -= m_attackDamage;
        }
        else
        {
            m_attackDamage -= player.m_playerUnits[LastBuilt].health;
            player.ReduceUnitNumber(player.m_playerUnits[LastBuilt].objectName);
            player.m_playerUnits.RemoveAt(LastBuilt);
            AttackPlayer();
        }
    }

    void CalculateGroundUnitHealth()
    {
        m_groundUnitHealth = (m_dragonWarriorNumber * dragonWarrior.health) + 
                              (m_dragonTankNum * dragonTank.health);
    }

    void DragonWarriorAttackNumber(int num)
    {
        if(enemy.m_dragonWarriorNum < num)
        {
            m_dragonWarriorNumber = enemy.m_dragonWarriorNum;
        }
        else
        {
            m_dragonWarriorNumber = num;
        }
    }

    void DragonTankAttackNumber(int num)
    {
        if(enemy.m_dragonTankNum < num)
        {
            m_dragonTankNum = enemy.m_dragonTankNum;
        }
        else
        {
            m_dragonTankNum = num;
        }
    }

    void DragonAttackNumber(int num)
    {
        if(enemy.m_dragonNum < num)
        {
            m_dragonNum = enemy.m_dragonNum;
        }
        else
        {
            m_dragonNum = num;
        }
    }

    void CalculateDefenseDamage()
    {
        //calculate mine damage
        CalculateMineDamage();
        //calculate anti air turret damage
        CalculateAntiAirTurretDamage();
    }

    void ResetUnitNumbers()
    {
        m_mineDamage = 0;
        m_antiAirTurretDamage = 0;
        m_dragonWarriorNumber = 0;
        m_dragonTankNum = 0;
        m_dragonNum = 0;
        m_groundUnitHealth = 0;
        m_attackDamage = 0;
    }
}
