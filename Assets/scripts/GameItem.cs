using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameItem : MonoBehaviour
{
    public string objectName;
    public int shardCost;
    public int goldCost;
    public int health;
    public int attack;

    public GameItem(string name,int gold, int shard, int a_health,int a_attack)
    {
        objectName = name;
        shardCost = shard;
        goldCost = gold;
        health = a_health;
        attack = a_attack;
    }
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
