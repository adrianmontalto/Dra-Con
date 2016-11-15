using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyAttackManager : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameItemList itemList;
    private bool m_isActive = false;
    private UtilityValue m_lowAttackValue;
    private UtilityValue m_mediumAttackValue;
    private UtilityValue m_highAttackValue;
    [SerializeField]
    private Dictionary<string, UtilityScore> m_utilityScoreMap = new Dictionary<string, UtilityScore>();
    private int m_mineDamage = 0;
    private int m_dragonWarriorNumber = 0;
    private int m_dragonTankNum = 0;
    private int m_dragonNum = 0;
    private int m_groundUnitHealth = 0;
    private int m_attackDamage = 0;
    [SerializeField]
    private Text m_moveText;

    // Use this for initialization
    void Start()
    {
        InitValues();
        SetScores();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitValues()
    {
        m_lowAttackValue = new UtilityValue(UtilityValue.NormalizationType.INVERSE_LINEAR, 0, enemy.GetMaxClosenessToWinGoal());
        m_lowAttackValue.SetNormaliztionType(UtilityValue.NormalizationType.INVERSE_LINEAR);
        m_lowAttackValue.SetValue(enemy.GetClosenessToWinGoal());

        m_mediumAttackValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 0, player.GetMaxHealth());
        m_mediumAttackValue.SetNormaliztionType(UtilityValue.NormalizationType.LINEAR);
        m_mediumAttackValue.SetValue(player.GetHealth());

        m_highAttackValue = new UtilityValue(UtilityValue.NormalizationType.LINEAR, 0, enemy.GetMaxClosenessToWinGoal());
        m_mediumAttackValue.SetNormaliztionType(UtilityValue.NormalizationType.LINEAR);
        m_highAttackValue.SetValue(enemy.GetClosenessToWinGoal());
    }

    void SetValues()
    {
        m_lowAttackValue.SetMinMaxValue(0, enemy.GetMaxClosenessToWinGoal());
        m_lowAttackValue.SetValue(enemy.GetClosenessToWinGoal());
        m_mediumAttackValue.SetMinMaxValue(0, player.GetMaxHealth());
        m_mediumAttackValue.SetValue(player.GetHealth());
        m_highAttackValue.SetMinMaxValue(0, enemy.GetMaxClosenessToWinGoal());
        m_highAttackValue.SetValue(enemy.GetClosenessToWinGoal());
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
            Debug.Log("atk: low attack");
            LowAttack();            
        }

        if (strBestAction == "mediumAttack")
        {
            Debug.Log("atk: medium attack");
            MediumAttack();            
        }

        if (strBestAction == "highAttack")
        {
            Debug.Log("atk: high attack");
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
        player.ReduceHealth(m_attackDamage);
        if(m_attackDamage > 0)
        {
            AttackPlayer();
        }
        m_isActive = false;
        player.SetMaxHealth();
        player.SetMaxUnitNumber();
        enemy.SetMaxValues();
        gameManager.SetEnemyTurn(false);
        gameManager.SetPlayerTurn(true);
        m_moveText.text = "Enemy Attacked";
    }

    void MediumAttack()
    {
        DragonAttackNumber(40);
        DragonTankAttackNumber(20);
        DragonAttackNumber(10);
        CalculateDefenseDamage();
        CalculateAttackDamage();
        player.ReduceHealth(m_attackDamage);
        if (m_attackDamage > 0)
        {
            AttackPlayer();
        }
        player.SetMaxHealth();
        player.SetMaxUnitNumber();
        enemy.SetMaxValues();
        gameManager.SetEnemyTurn(false);
        gameManager.SetPlayerTurn(true);
        m_moveText.text = "Enemy Attacked";
    }

    void HighAttack()
    {
        DragonAttackNumber(60);
        DragonTankAttackNumber(30);
        DragonAttackNumber(15);
        CalculateDefenseDamage();
        CalculateAttackDamage();
        player.ReduceHealth(m_attackDamage);
        if (m_attackDamage > 0)
        {
            AttackPlayer();
        }
        player.SetMaxHealth();
        player.SetMaxUnitNumber();
        enemy.SetMaxValues();
        gameManager.SetEnemyTurn(false);
        gameManager.SetPlayerTurn(true);
        m_moveText.text = "Enemy Attacked";
    }

    void AttackPlayer()
    {
        //check to see if player has any walls
        if (player.GetWallNumber() > 0)
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
        if(player.GetMineNumber() > 0)
        {
            //calculate health of attacking dragon warriors and dragon tanks
            CalculateGroundUnitHealth();
            //calculate damage done to player ensurinbg that no excess mines are used
            m_mineDamage = player.GetMineNumber() * itemList.GetMine().GetAttack();
            if(m_mineDamage < m_groundUnitHealth)
            {
                //destroy all mines used                
                player.DestroyMines(player.GetMineNumber());
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
                    m_mineDamage += itemList.GetMine().GetAttack();
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
        if(player.GetAntiAirTurretNumber() > 0)
        {
            //calculate damage from air turrets
            int turretDamage = player.GetAntiAirTurretNumber() * itemList.GetAntiAirTurret().GetAttack();
            //calculate dragon health
            int dragonHealth = m_dragonNum * itemList.GetDragon().GetHealth();
            if(turretDamage > dragonHealth)
            {
                turretDamage = dragonHealth;
            }
            enemy.DestroyDragons(turretDamage);
        }
    }

    void CalculateAttackDamage()
    {
        m_dragonWarriorNumber -= enemy.GetDragonWarriorsDestroyed();
        m_dragonTankNum -= enemy.GetDragonTanksDestroyed();
        m_dragonNum -= enemy.GetDragonsDestroyed();
        m_attackDamage = (m_dragonWarriorNumber * itemList.GetDragonWarrior().GetAttack()) + 
                            (m_dragonTankNum * itemList.GetDragonTank().GetAttack()) + 
                            (m_dragonNum * itemList.GetDragon().GetAttack());
    }

    void CalculateWallDamage()
    {
        int lastWall = player.GetPlayerUnitsList().FindLastIndex((GameItem item) => { return item.GetName() == "wall"; });

        if(lastWall > -1)
        {
            if(m_attackDamage < player.GetPlayerUnitsList()[lastWall].GetHealth())
            {
                player.GetPlayerUnitsList()[lastWall].ReduceHealth(m_attackDamage);
            }
            else
            {
                m_attackDamage -= player.GetPlayerUnitsList()[lastWall].GetHealth();
                player.GetPlayerUnitsList().RemoveAt(lastWall);
                player.ReduceWallNumber(1);
                AttackPlayer();
            }
        }
    }

    void CalculateLastBuiltDamage()
    {
        int LastBuilt = player.GetPlayerUnitsList().Count - 1;
        if(m_attackDamage < player.GetPlayerUnitsList()[LastBuilt].GetHealth())
        {
            player.GetPlayerUnitsList()[LastBuilt].ReduceHealth(m_attackDamage);
        }
        else
        {
            m_attackDamage -= player.GetPlayerUnitsList()[LastBuilt].GetHealth();
            player.ReduceUnitNumber(player.GetPlayerUnitsList()[LastBuilt].GetName());
            player.GetPlayerUnitsList().RemoveAt(LastBuilt);
            AttackPlayer();
        }
    }

    void CalculateGroundUnitHealth()
    {
        m_groundUnitHealth = (m_dragonWarriorNumber * itemList.GetDragonWarrior().GetHealth()) + 
                              (m_dragonTankNum * itemList.GetDragonTank().GetHealth());
    }

    void DragonWarriorAttackNumber(int num)
    {
        if(enemy.GetDragonWarriorNumber() < num)
        {
            m_dragonWarriorNumber = enemy.GetDragonWarriorNumber();
        }
        else
        {
            m_dragonWarriorNumber = num;
        }
    }

    void DragonTankAttackNumber(int num)
    {
        if(enemy.GetDragonTankNumber() < num)
        {
            m_dragonTankNum = enemy.GetDragonTankNumber();
        }
        else
        {
            m_dragonTankNum = num;
        }
    }

    void DragonAttackNumber(int num)
    {
        if(enemy.GetDragonNumber() < num)
        {
            m_dragonNum = enemy.GetDragonNumber();
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
        m_dragonWarriorNumber = 0;
        m_dragonTankNum = 0;
        m_dragonNum = 0;
        m_groundUnitHealth = 0;
        m_attackDamage = 0;
    }
}
