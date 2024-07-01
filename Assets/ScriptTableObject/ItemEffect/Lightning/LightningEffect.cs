using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Effect", menuName = "Data/Lightning Effect")]
public class LightningEffect : ItemEffect
{
    [SerializeField] private GameObject objectPrefab;
    public override void ExecuteEffect(Transform positonEnemy)
    {
       GameObject newObj = Instantiate(objectPrefab, positonEnemy.position,Quaternion.identity);
       Destroy(newObj,10f);
    }
}
