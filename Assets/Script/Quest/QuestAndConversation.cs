using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestAndConversation:MonoBehaviour
{
   public List<TextAsset> listQuests = new List<TextAsset>();
   public List<TextAsset> listConversation = new List<TextAsset>();
    private ConversationController conversationController;
    private QuestManager questManager;
   int current = 0;

    private void Start()
    {
        conversationController = GetComponent<ConversationController>();
        questManager = GetComponent<QuestManager>();
    }
    public void SetCurrent()
    {
        current++;
        conversationController.LoadTextAsset();
        questManager.LoadQuest();
    }
    public TextAsset GetQuest()
    {
        try
        {
            return listQuests[current]; ;
        }
        catch
        {
            return null;
        };
    }
    public TextAsset GetConversation()
    {
        try
        {
           return listConversation[current];
        }
        catch
        {
            return null;
        };
    }
}
