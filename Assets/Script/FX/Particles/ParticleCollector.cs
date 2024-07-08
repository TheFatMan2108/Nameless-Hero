using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollector : MonoBehaviour
{
    public float totalFireTime = 100;
    private ParticleSystem ps;
    private int particleCount = 0;
    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }


    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out Player player))
        {
            particleCount++;
            if (particleCount > totalFireTime)
            {
                ps.maxParticles = 0;
                ps.Stop();
            }
            else
            {
                player.SetFireTime(1);
            }
        }
    }
}
