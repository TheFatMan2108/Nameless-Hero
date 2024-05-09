using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   public Character character;
   
    private void Awake()
    {
        // sau nay lam id de load dung o save
        string data = PlayerPrefs.GetString("id","");
        if (data.Equals(""))
        {
            character = new Character();
        }
        else
        {
           character =  JsonUtility.FromJson<Character>(data);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
