using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameItem : MonoBehaviour
{
    [SerializeField]
    private string m_objectName;
    [SerializeField]
    private int m_shardCost;
    [SerializeField]
    private int m_goldCost;
    [SerializeField]
    private int m_health;
    [SerializeField]
    private int m_attack;

    public GameItem(string name,int gold, int shard, int a_health,int a_attack)
    {
        m_objectName = name;
        m_shardCost = shard;
        m_goldCost = gold;
        m_health = a_health;
        m_attack = a_attack;
    }
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public string GetName()
    {
        return m_objectName;
    }

    public int GetHealth()
    {
        return m_health;
    }

    public void AddHealth(int health)
    {
        m_health += health;
    }

    public void ReduceHealth(int health)
    {
        m_health -= health;
    }

    public int GetAttack()
    {
        return m_attack;
    }

    public int GetGoldCost()
    {
        return m_goldCost;
    }

    public int GetShardCost()
    {
        return m_shardCost;
    }
}
