using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    private Character character ;
    private TMP_Text level;
    private Slider expBar;
    private GameObject buttons;
    private GameObject parrent;
    private void OnEnable()
    {
        character = GameObject.Find("Player").GetComponent<Player>().character;
        parrent = GameObject.Find("UpLevel");
        level = parrent.transform.GetChild(0).GetComponent<TMP_Text>();
        Debug.Log(level.gameObject.name);
        expBar = parrent.transform.GetChild(1).GetComponent<Slider>();
        buttons = parrent.transform.GetChild(2).gameObject;
    }
    void Start()
    {
        string a = JsonUtility.ToJson(character);
        Debug.Log(a);
        buttons.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
        {
            character.levelSystem.AddExp(50f);
        });
        buttons.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() =>
        {
            character.levelSystem.AddExp(100f);
        });
        buttons.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() =>
        {
            character.levelSystem.AddExp(500f);
            character.SavePlayer("id");
            
        });
    }

    // Update is called once per frame
    void Update()
    {
        if(level==null||expBar==null) return;
        level.SetText("Level: "+character.levelSystem.level);
        expBar.maxValue = character.levelSystem.expNextLevel;
        expBar.value = character.levelSystem.exp;
    }
}
