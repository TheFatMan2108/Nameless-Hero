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
        Vector3 newPositon = enemy.FindPlayer().transform.GetComponent<Player>().GetMouseDirection();
        Debug.Log(newPositon);
        for (int i = 1; i <= 5; i++)
        {
            // chua sua duoc loi chem ra duong thang dung huong
        GameObject newObj = Instantiate(objectPrefab,new Vector2(positonEnemy.position.x*newPositon.x,positonEnemy.position.y*newPositon.y), Quaternion.identity);
        Destroy(newObj, 10f);
        }
    }

}
