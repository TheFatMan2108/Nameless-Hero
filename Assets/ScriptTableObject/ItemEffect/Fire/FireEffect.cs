using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Effect", menuName = "Data/Fire Effect")]
public class FireEffect : ItemEffect
{
    [SerializeField] private GameObject objectPrefab;
    public override void ExecuteEffect(Transform positonEnemy)
    {
        Enemy enemy = positonEnemy.GetComponent<Enemy>();
        Vector2 dir = (Vector2)positonEnemy.position - (Vector2)enemy.FindPlayer().position;
        dir.Normalize();
        for (int i = 1; i <= 5; i++)
        {
            //cong thuc hay vl 
            Vector3 spawnPosition = positonEnemy.position + (Vector3)(dir * i);
            GameObject newObj = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            Destroy(newObj, 1f);
        }
    }
}
