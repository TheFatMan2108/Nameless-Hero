using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXEntity : MonoBehaviour
{
    private SpriteRenderer sp;
    [SerializeField] Material fxHit;
    private Material fxOgirin;
    void Start()
    {
        sp = GetComponentInChildren<SpriteRenderer>();
        fxOgirin = sp.material;
    }

    private IEnumerator HitFX()
    {
        sp.material = fxHit;
        yield return new WaitForSeconds(0.2f);
        sp.material = fxOgirin;
    }

    private void RebBlink()
    {
        if(sp.color != Color.white) 
            sp.color = Color.white;
        else sp.color = Color.red;
    }
    private void StopRedBlink()
    {
        CancelInvoke();
        sp.color = Color.white ;
    }
}
