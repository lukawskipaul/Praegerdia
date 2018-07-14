﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : Goal {

  

    public int EnemyID { get; set; }

    public KillGoal(Quest quest, int enemyID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.EnemyID = enemyID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        CombatEvent.OnEnemyDeath += EnemyDies;
    }


    void EnemyDies(IEnemy enemy)
    {
        if(enemy.ID == this.EnemyID)
        {
            Debug.Log("Enemy Died");
            this.CurrentAmount++;
            Evaluate();
            //this.Completed = true;
        }
    }

}
