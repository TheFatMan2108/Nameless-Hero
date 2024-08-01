using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DontDestroyManager : MonoBehaviour
{
   public static DontDestroyManager instance { get; private set; }
   private List<GameObject> dontDestroyList = new List<GameObject>();

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    public void Add(GameObject go)
    {
       var data = dontDestroyList.Find(x=>x.gameObject == go);
        if(data != null)return;
        dontDestroyList.Add(go);
        DontDestroyOnLoad(go);
    }
    public void Remove(GameObject go)
    {
        Destroy(go);
        dontDestroyList.Remove(go);
    }
    public void ClearAll()
    {
        foreach (GameObject go in dontDestroyList)
        {
            Destroy(go);
        }
        dontDestroyList.Clear();
        DataPersistenceManager.instance.SaveGame();
    }
  
}
