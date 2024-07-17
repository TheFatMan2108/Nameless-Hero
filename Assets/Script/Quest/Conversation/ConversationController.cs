using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour, IPointerClickHandler
{
    public string nameNPC;
    public GameObject conversationParent;
    public Image playerAvatar;
    public Image otherAvatar;
    public Sprite playerSprite;
    public Sprite otherSprite;
    public TextMeshProUGUI contentUI,nameUI;
    public List<Conversation> conversationList = new List<Conversation>();
    private List<Conversation> conversationDefault = new List<Conversation>();
    private List<Conversation> conversationComplete = new List<Conversation>();
    private QuestAndConversation data;
    private QuestManager questManager;
    public int current = 0;
    private bool isNear = false;
    private bool isStartMission = false;
   

    // Start is called before the first frame update
    private void Start()
    {
        data = GetComponent<QuestAndConversation>();
        questManager = GetComponent<QuestManager>();
        playerSprite = PlayerManager.Instance.player.GetComponent<SpriteRenderer>().sprite;
        otherSprite = GetComponent<SpriteRenderer>().sprite;
        LoadTextAsset();
        LoadConversationDefault();
    }

    private void LoadConversationDefault()
    {
       Conversation defaultConversation = new Conversation();
        Conversation completeConversation = new Conversation();

        defaultConversation.id = 1;
        defaultConversation.name = "Villiger";
        defaultConversation.content = "Nguoi con cho gi nua mau di lam viec di !!";


        completeConversation.id = 1;
        completeConversation.name = "Villiger";
        completeConversation.content = "Lam tot lam day la phan thuong danh cho nguoi";

        conversationDefault.Add(defaultConversation);
        conversationComplete.Add(completeConversation);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayConversation(conversationList);
    }
    private void Update()
    {
         if (Input.GetKeyDown(KeyCode.E)&&isNear)
        {
            if (questManager.quest.isError)
            {
                // viet gi do o day
                PlayConversation(conversationList);
                return;
            }
            if (!isStartMission&&!questManager.quest.complete)
            {
                PlayConversation(conversationList);
            }else if(isStartMission&&!questManager.quest.complete)
            {
                // cho loi thoai bao nhan vat chinh la di lam nhiem vu di
                PlayConversation(conversationDefault);
            }else if (questManager.quest.complete)
            {
                // thanh cong viet o day
                // sau do reset lai nhiem vu
                PlayConversation(conversationComplete);
                isStartMission = false;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isNear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isNear = false;
            current = 0;
            conversationParent.SetActive(false);
        }
    }
    public void PlayConversation(List<Conversation> conversationList)
    {
        Debug.Log("Current " + conversationList.Count);
        if (current < conversationList.Count)
        {
            if (conversationList[current].name == "Player")
            {
                playerAvatar.sprite = playerSprite;
            }
            else
            {
                otherAvatar.sprite = otherSprite;
                conversationList[current].name = nameNPC;
            }
            
            otherAvatar.gameObject.SetActive(true);
            nameUI.SetText(conversationList[current].name);
            contentUI.text = conversationList[current].content;
            conversationParent.SetActive(true);
            current++;
        }
        else
        {
            conversationParent.SetActive(false);
            if (questManager.quest!=null&&!questManager.quest.isActive&&!questManager.quest.complete && !questManager.quest.isError)
            {
                questManager.ShowQuest();
                isStartMission = true;
            }
            if (questManager.quest.complete)
            {
                // thanh cong viet o day
                // sau do reset lai nhiem vu
                PlayerManager.Instance.player.SetFireTime(questManager.quest.goldReaward);
                PlayerManager.Instance.player.levelSystem.AddExp(questManager.quest.expReaward);
                GameManager.Instance.listCurrentQuest.Remove(questManager.quest);
                PlayerManager.Instance.SetQuest("");
                questManager.data.SetCurrent();
            }
            current = 0;
        }
    }

    public void LoadTextAsset()
    {
        conversationList.Clear();
        TextAsset loadText = data.GetConversation();
        #region Not Null
        if (loadText == null) { conversationList.Clear();conversationList.Add(new Conversation(1, "", "...")); return; };
        #endregion
        string[] lines = loadText.text.Split("\n");

        for (int i = 0; i < lines.Length; i++)
        {
            string[] fields = lines[i].Split("\t");

            Conversation conversation = new Conversation();
            conversation.id = Int32.Parse(fields[0]);
            conversation.name = fields[1];
            conversation.content = fields[2];

            conversationList.Add(conversation);
        }
    }
}

[Serializable]
public class Conversation
{
    public int id;
    public string name;
    public string content ;

    public Conversation()
    {
    }
    public Conversation(int id, string name, string content)
    {
        this.id = id;
        this.name = name;
        this.content = content;
    }

}