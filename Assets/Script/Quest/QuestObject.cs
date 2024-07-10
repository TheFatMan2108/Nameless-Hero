using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestObject
{
    public bool isActive;
    public int id;
    public string questName;
    public string description;
    public int goldReaward;
    public int expReaward;
    public QuestGoal goal;
    public bool complete;
    public bool isError;

    public void Complete()
    {
        isActive = false;
        complete = true;
        //current++;
    }
}

[System.Serializable]
public class QuestGoal
{
    public GoalType type;

    public int requiment;
    public int currentAmount;

    public QuestGoal(GoalType type, int requiment)
    {
        this.type = type;
        this.requiment = requiment;
    }

    public bool checkDone()
    {
        return (currentAmount >= requiment);
    }

    public void SetCurrentAmout()
    {
        currentAmount++;
    }
}

public enum GoalType
{
    Kill,
    Gathering
}