using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreadCharacter : MonoBehaviour
{
    private GameObject created;
    private TMP_InputField namePlayer;
    private TMP_Dropdown classType;
    private Button ok;
    private Character character;
    private void Awake()
    {
        character = new Character();
        created = GameObject.Find("Created");
        namePlayer = created.transform.GetChild(0).GetComponent<TMP_InputField>();
        classType = created.transform.GetChild(1).GetComponent<TMP_Dropdown>();
        Debug.Log(classType);
        ok = created.transform.GetChild(2).GetComponent<Button>();
        ok.onClick.AddListener(Created);
        string[] typeClass = Enum.GetNames(typeof(Character.ClassType));
        if (classType != null)
        {
            for (int i = 0; i < typeClass.Length; i++)
            {
                Debug.Log(typeClass[i]);
                classType.options.Add(new TMP_Dropdown.OptionData(typeClass[i]));
            }
        }
    }
    private void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Created();
        }
    }

    public void Created()
    {

        character.CreatedCharacter(namePlayer.text,(Character.ClassType) Enum.GetValues(typeof(Character.ClassType)).GetValue(classType.value));
        string data = JsonUtility.ToJson(character);
        Debug.Log(data);
        created.gameObject.SetActive(false);


    }
}
