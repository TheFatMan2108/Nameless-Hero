using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBossRoom : MonoBehaviour
{
    [SerializeField] GameObject cutscene,parrent;
    [SerializeField] string nameBoss;

    private void Update()
    {
        if (GameManager.Instance.GetBossEvent(nameBoss) != null)
        {
            if(GameManager.Instance.GetBossEvent(nameBoss).TryGetComponent(out Enemy enemy))
            {
                if (enemy.entityStats.curentHeatlth < 1)
                {
                  parrent.SetActive(false);
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cutscene.SetActive(true);
        }
    }
}
