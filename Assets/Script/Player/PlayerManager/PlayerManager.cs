using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public Player player;
    public TMP_Text questText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }
    private void Start()
    {
        DontDestroyManager.instance.Add(gameObject);
    }
    // Update is called once per frame
    public void SetQuest(string content)=>questText.text = content;
}
