using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private float timeDestroy = 3f;
    void Start()
    {
        Destroy(gameObject,timeDestroy);
    }

   
}
