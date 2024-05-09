using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetData : MonoBehaviour
{
  public WeaponDataSO weaponDataSO;
    void Start()
    {
        weaponDataSO = (WeaponDataSO)Resources.Load("Weapons/sword") ;
        string data = JsonUtility.ToJson(weaponDataSO);
        Debug.Log(data);
        Debug.Log(weaponDataSO.weaponInfo.GetDamage()+" Damage");
        GetComponent<SpriteRenderer>().sprite = weaponDataSO.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
