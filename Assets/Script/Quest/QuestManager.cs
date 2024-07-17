using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{ 
    public GameObject questBoard;
    public TextMeshProUGUI textTitle;
    public TextMeshProUGUI textContent;
    public TextMeshProUGUI textXP;
    public TextMeshProUGUI textCoin;
    public QuestObject quest { get; private set; }
    public QuestAndConversation data { get; private set; }

    private void Start()
    {
        data = GetComponent<QuestAndConversation>();
        LoadQuest();
    }

    public void LoadQuest()
    {
        quest = new QuestObject();
        TextAsset loadText = data.GetQuest();
        if (loadText == null) {  quest.isError = true; return; };
        string[] fields = loadText.text.Split("\t");
            quest = new QuestObject();
            quest.id = Int32.Parse(fields[0]);
            quest.isActive = fields[1].ToLower().Equals("true");
            quest.questName = fields[2];
            quest.description = fields[3];
            quest.goldReaward = Int32.Parse(fields[4]);
            quest.expReaward = Int32.Parse(fields[5]);
            string[] questGoal = fields[6].Split(",");
            quest.goal = new QuestGoal(questGoal[0].ToLower().Equals("kill") ? GoalType.Kill : GoalType.Gathering, Int32.Parse(questGoal[1]));
            quest.complete = false;
            quest.isError = false;
            quest.isActive = false;
    }

    public void ShowQuest()
    {

        questBoard.SetActive(true);
        textTitle.SetText(quest.questName);
        textContent.SetText(quest.description);
        textXP.text = quest.expReaward.ToString("n0"); //nó sẽ có dấu . hàng nghìn. Ví dụ: 1.000.000.000
        textCoin.text = quest.goldReaward.ToString("n0");
    }

    public void okButton()
    {
        quest.isActive = true;
        GameManager.Instance.AddQuest(quest);
        questBoard.SetActive(false);
        Debug.Log("Đã nhận nhiệm vụ tân thủ");
    }

    public void cancelButton()
    {
        questBoard.SetActive(false);
    }
}
