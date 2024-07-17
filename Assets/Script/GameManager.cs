using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<QuestObject> listCurrentQuest = new List<QuestObject>();
    public List<Enemy> enemies = new List<Enemy>();

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

    public void CheckAlive(Enemy enemy)
    {
        // eo hieu viet cai nay ra lam db gi :))
        var getQ = enemies.Find(e => e == enemy);
        if (getQ!=null&&getQ.entityStats.curentHeatlth < 1) 
        {
            enemies.Remove(enemy);
            Debug.Log(enemy.gameObject.name+" Dang chet");
        }
    }
    public Enemy GetBossEvent(string name)=> enemies.Find(e => e.name.ToLower().Equals(name.ToLower()));
    public void AddBattle(Enemy enemy)
    {
        var getQ = enemies.Find(e => e == enemy);
        if(getQ==null)
            enemies.Add(enemy);
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
