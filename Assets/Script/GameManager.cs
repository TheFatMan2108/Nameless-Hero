using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<QuestObject> listCurrentQuest = new List<QuestObject>();

    public int mainQuest { get; private set; } //theo dõi tiến độ làm nhiệm vụ của nhân vật. Ban đầu: mainQuest = 0;
    public int shadowQuest { get; private set; } //quest riêng lẻ

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public bool Check(int getid)
    {
        var getQ = listCurrentQuest.Where(x => x.id == getid).ToList();
        if (getQ.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetCurrentForQuest(int getid)
    {
        var getQ = listCurrentQuest.Where(x => x.id == getid).ToList();
        if (getQ.Count > 0)
        {
            foreach (var x in getQ)
            {
            x.goal.SetCurrentAmout();
            PlayerManager.Instance.SetQuest(x.description + " " + x.goal.currentAmount + "/" + x.goal.requiment+"\n");
                if (x.goal.checkDone())
                {
                    PlayerManager.Instance.SetQuest("Mission Complete");
                    x.Complete();
                }
            }
        }
    }
    public void AddQuest(QuestObject obj)
    {
        listCurrentQuest.Add(obj);
        PlayerManager.Instance.SetQuest(obj.description + " " + obj.goal.currentAmount + "/" + obj.goal.requiment);
    }
    public void SetMainQuest()
    {
        mainQuest++;
    }

    public void SetFrogQuest()
    {
        shadowQuest++;
    }
}
