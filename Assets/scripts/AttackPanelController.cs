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
    private int dragonWarriorsNum = 0;
    private int dragonTanksNum = 0;
    private int dragonsNum = 0;
    private int playerAttackdamage = 0;

    public Text dragonWarriorsAmountText;
    public Text dragonTankAmountText;
    public Text dragonAmountText;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        dragonWarriorsAmountText.text = dragonWarriorsNum.ToString();
        dragonTankAmountText.text = dragonTanksNum.ToString();
        dragonAmountText.text = dragonsNum.ToString();
    }

    public void AddDragonWarrior()
    {
        if(dragonWarriorsNum < player.dragonWarriorNum)
        {
            dragonWarriorsNum++;
        }        
    }

    public void RemoveDragonWarrior()
    {
        if(dragonWarriorsNum > 0)
        {
            dragonWarriorsNum --;
        }
    }

    public void AddDragonTanks()
    {
        if (dragonTanksNum < player.dragonTankNum)
        {
            dragonTanksNum++;
        }        
    }

    public void RemoveDragonTanks()
    {
        if(dragonTanksNum > 0)
        {
            dragonTanksNum --;
        }
    }

    public void AddDragon()
    {
        if (dragonsNum < player.dragonNum)
        {
            dragonsNum++;
        }       
    }

    public void RemoveDragons()
    {
        if(dragonsNum > 0)
        {
            dragonsNum --;
        }
    }

    public void AttackButtonClick()
    {
        CalculatePlayerAttackDamage();
        enemy.health -= playerAttackdamage;
        if (playerAttackdamage > 0)
        {
            AttackEnemy();
        }
        attackPanel.SetActive(false);
        gameManger.playerTurn = false;
        gameManger.enemyTurn = true;
    }

    void AttackEnemy()
    {
        if (enemy.wallNum > 0)
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
        int lastWall = enemy.enemyUnits.FindLastIndex((GameItem item) => { return item.objectName == "wall"; });

        if(lastWall > -1)
        {
           if(playerAttackdamage < enemy.enemyUnits[lastWall].health)
            {
                enemy.enemyUnits[lastWall].health -= playerAttackdamage;
            }
           else
            {
                playerAttackdamage -= enemy.enemyUnits[lastWall].health;
                enemy.enemyUnits.RemoveAt(lastWall);
                enemy.wallNum--;
                AttackEnemy();
            }
        }
    }

    void AttackEnemyLastBuilt()
    {
        int LastEnemy = enemy.enemyUnits.Count - 1;
        if(playerAttackdamage < enemy.enemyUnits[LastEnemy].health)
        {
            enemy.enemyUnits[LastEnemy].health -= playerAttackdamage;           
        }
        else
        {
            playerAttackdamage -= enemy.enemyUnits[LastEnemy].health;
            enemy.ReduceUnitNumber(enemy.enemyUnits[LastEnemy].objectName);
            enemy.enemyUnits.RemoveAt(LastEnemy);
            AttackEnemy();
        }
    }

    void CalculatePlayerAttackDamage()
    {
        for(int i = 0; i < dragonWarriorsNum;++i)
        {
            playerAttackdamage += menu.dragonWarrior.attack;
        }

        for(int i = 0; i < dragonTanksNum; ++i)
        {
            playerAttackdamage += menu.dragonTank.attack;
        }

        for(int i = 0; i < dragonsNum; ++ i)
        {
            playerAttackdamage += menu.dragon.attack;
        }
    }
}
