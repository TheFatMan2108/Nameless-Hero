using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXEntity : MonoBehaviour
{
    private SpriteRenderer sp;
    [SerializeField] Material fxHit;
    [SerializeField] List<GameObject> particles;
    private Material fxOgirin;
    [Header("Effect ")]
    public Color[] iceEffect;
    public Color[] fireEffect;
    public Color[] linghningEffect;
    public Color[] bleedEffect;
    public Color[] toxicEffect;
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
    private async void Reset()
    {
        fxHit = await AddressLoader.LoaderAddress<Material>("Assets/Masterial/FXHit.mat");

            for (int i = 0; i< transform.GetChild(0).transform.childCount; i++)
        {
            particles.Add(transform.GetChild(0).transform.GetChild(i).gameObject);
        }
        
        iceEffect = new Color[2];
        fireEffect = new Color[2];
        linghningEffect = new Color[2];
        bleedEffect = new Color[2];
        toxicEffect = new Color[2];
        iceEffect[0] = ColorFromHex.FromHex("0077FF");
        iceEffect[1] = ColorFromHex.FromHex("52D4FF");
        fireEffect[0] = ColorFromHex.FromHex("FF5A00");
        fireEffect[1] = ColorFromHex.FromHex("FFB654");
        linghningEffect[0] = ColorFromHex.FromHex("D8FF00");
        linghningEffect[1] = ColorFromHex.FromHex("DEFF66");
        bleedEffect[0] = ColorFromHex.FromHex("FF0000");
        bleedEffect[1] = ColorFromHex.FromHex("FF6F6F");
        toxicEffect[0] = ColorFromHex.FromHex("44FF00");
        toxicEffect[1] = ColorFromHex.FromHex("68FF4E");

    }
    private void RebBlink()
    {
        if (sp.color != Color.white)
            sp.color = Color.white;
        else sp.color = Color.red;
    }
    private void CancelColorChange()
    {
        CancelInvoke();
        sp.color = Color.white;
    }

    public void FireFXFor(float seccond)
    {
        InvokeRepeating("FireColorFX", 0, 0.3f);
        Invoke("CancelColorChange", seccond);
        StartCoroutine(FireFXShow(seccond));
    }
    private void FireColorFX()
    {
        if (sp.color == fireEffect[0])
            sp.color = fireEffect[1];
        else sp.color = fireEffect[0];
    }
    IEnumerator FireFXShow(float sec)
    {
        particles[0].gameObject.SetActive(true);
        yield return new WaitForSeconds(sec);
        particles[0].gameObject.SetActive(false);
    }
    public void IceFXFor(float seccond)
    {
        InvokeRepeating("IceColorFX", 0, 0.3f);
        Invoke("CancelColorChange", seccond);
        StartCoroutine(IceFXShow(seccond));
    }
    private void IceColorFX()
    {
        if (sp.color == iceEffect[0])
            sp.color = iceEffect[1];
        else sp.color = iceEffect[0];
    }
    IEnumerator IceFXShow(float sec)
    {
        particles[1].gameObject.SetActive(true);
        yield return new WaitForSeconds(sec);
        particles[1].gameObject.SetActive(false);
    }
    public void LightFXFor(float seccond)
    {
        InvokeRepeating("LightColorFX", 0, 0.3f);
        Invoke("CancelColorChange", seccond);
        StartCoroutine(LightFXShow(seccond));
    }
    private void LightColorFX()
    {
        if (sp.color == linghningEffect[0])
            sp.color = linghningEffect[1];
        else sp.color = linghningEffect[0];
    }
    IEnumerator LightFXShow(float sec)
    {
        particles[2].gameObject.SetActive(true);
        yield return new WaitForSeconds(sec);
        particles[2].gameObject.SetActive(false);
    }
    public void BleedtFXFor(float seccond)
    {
        InvokeRepeating("BleedColorFX", 0, 0.3f);
        Invoke("CancelColorChange", seccond);
        StartCoroutine(BleedFXShow(seccond));
    }
    private void BleedColorFX()
    {
        if (sp.color == bleedEffect[0])
            sp.color = bleedEffect[1];
        else sp.color = bleedEffect[0];
    }
    IEnumerator BleedFXShow(float sec)
    {
        particles[3].gameObject.SetActive(true);
        yield return new WaitForSeconds(sec);
        particles[3].gameObject.SetActive(false);
    }
    public void ToxictFXFor(float seccond)
    {
        InvokeRepeating("ToxicColorFX", 0, 0.3f);
        Invoke("CancelColorChange", seccond);
        StartCoroutine(ToxicFXShow(seccond));
    }
    private void ToxicColorFX()
    {
        if (sp.color == toxicEffect[0])
            sp.color = toxicEffect[1];
        else sp.color = toxicEffect[0];
    }
    IEnumerator ToxicFXShow(float sec)
    {
        particles[4].gameObject.SetActive(true);
        yield return new WaitForSeconds(sec);
        particles[4].gameObject.SetActive(false);
    }
}
