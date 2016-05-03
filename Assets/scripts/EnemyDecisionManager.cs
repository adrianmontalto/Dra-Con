using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDecisionManager : MonoBehaviour
{
    public Enemy enemy;
    public EnemyAttackManager enemyAttacker;
    public EnemyBuildManager enemyBuilder;
    public EnemyGatherManager enemyGather;
    private int attackValue = 0;
    private int gatherValue = 0;
    private int buildValue = 0;
    public Dictionary<string, UtilityScore> utilityScoreMap = new Dictionary<string, UtilityScore>();
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void MakeDecision()
    {

    }

    void AttackPlayer()
    {

    }

    void GatherResources()
    {

    }

    void BuildResources()
    {
         
    }
}
