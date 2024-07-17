using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMousePosition : MonoBehaviour
{
   Player player;
    void Start()
    {
        player = PlayerManager.Instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        transform.transform.localPosition = player.GetMouseDirection();
    }
}
