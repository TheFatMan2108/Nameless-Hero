using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEffectSystem : MonoBehaviour
{
    [SerializeField] private GameObject ghostEffect;
    [SerializeField] private Transform parentSpawn;
    private float timer;
    private Sprite sprite;
    private bool flip;

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        if(timer < 0)
        {
            timer = 0.02f;
            GameObject ghost = Instantiate(ghostEffect,transform.position,Quaternion.identity,parentSpawn);
            ghost.GetComponent<SpriteRenderer>().sprite = sprite;
            ghost.GetComponent<SpriteRenderer>().flipX = flip;
            Destroy(ghost,1f);
        }
    }

    public void SetOnGhostAnimation(bool action,SpriteRenderer sprite)
    {
        this.sprite = sprite.sprite;
        flip = sprite.flipX;
        gameObject.SetActive(action);
    }
    public void SetOnGhostAnimation(bool action)
    {
        gameObject.SetActive(action);
    }
}
