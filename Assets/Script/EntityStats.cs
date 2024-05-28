using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    [Header("Stats")]
    public Stats Vitality;
    public Stats Mind;
    public Stats Endurance;
    public Stats Strength;
    public Stats Dexterity;
    public Stats Intelligence;
    [Header("Offensive")]
    public Stats damage;
    public Stats critChance;
    public Stats critPower;
    [Header("Defaul Stats")]
    public Stats maxHealth;
    public Stats armor;
    public Stats magicResistance;
    [Header("Macgic stats")]
    public Stats fireDamage;
    public Stats iceDamage;
    public Stats lightDamage;
    public Stats bloodDamage;
    public Stats toxicDamage;
    protected int currentHealth;

    public bool isIgnited;
    public bool isChilled;
    public bool isLight;
    public bool isBloodThorns;
    public bool isToxic;

    #region Timer
    private float fireTimer;
    private float fireDamageCoolDown = 0.3f;
    private float fireDamageTimer;

    private float iceTimer;
    private float iceDamageCooldown = 0.3f;
    private float iceDamageTimer;

    private float lightTimer;
    private float lightDamageCooldown = 0.3f;
    private float lightDamageTimer;

    private float bloodTimer;
    private float bloodDamageCooldown = 0.3f;
    private float bloodDamageTimer;

    private float toxicTimer;
    private float toxicDamageCooldown = 0.3f;
    private float toxicDamageTimer;
    #endregion
    protected float curentHeatlth;


    protected virtual void Start()
    {
        critPower.SetDefaulValue(150);
        curentHeatlth = maxHealth.GetValue();
    }
    protected virtual void Update()
    {
        #region Timer
        fireTimer -= Time.deltaTime;
        fireDamageTimer -= Time.deltaTime;
        iceTimer -= Time.deltaTime;
        iceDamageTimer -= Time.deltaTime;
        lightTimer -= Time.deltaTime;
        lightDamageTimer -= Time.deltaTime;
        bloodTimer -= Time.deltaTime;
        bloodDamageTimer -= Time.deltaTime;
        toxicTimer -= Time.deltaTime;
        toxicDamageTimer -= Time.deltaTime;
        #endregion
        #region reset status
        if (fireTimer < 0) isIgnited = false;
        if (iceTimer < 0) isChilled = false;
        if (lightTimer < 0) isLight = false;
        if (bloodTimer < 0) isBloodThorns = false;
        if (toxicTimer < 0) isToxic = false;
        #endregion
        #region effect status
        if (fireDamageTimer < 0 && isIgnited)
        {
            Debug.Log("Dang hcay");
            fireDamageTimer = fireDamageCoolDown;
        }
        if (iceDamageTimer < 0 && isChilled)
        {
            Debug.Log("Dang lanh");
            iceDamageTimer = iceDamageCooldown;
        }
        if (lightDamageTimer < 0 && isLight)
        {
            Debug.Log("Dang hcay");
            lightDamageTimer = lightDamageCooldown;
        }
        if (bloodDamageTimer < 0 && isBloodThorns)
        {
            Debug.Log("Dang chay mau");
            bloodDamageTimer = bloodDamageCooldown;
        }
        if (toxicDamageTimer < 0 && isToxic)
        {
            Debug.Log("dang trung doc");
            toxicDamageTimer = toxicDamageCooldown;
        }
        #endregion
    }
    public virtual void DoDamage(EntityStats entityStats)
    {
        float totalDamage = damage.GetValue() + Strength.GetValue();
        if (CanCrit())
        {
            // x saìt thýõng õÒ ðây
            totalDamage = CalculateCritDamage(totalDamage);
            Debug.Log("1 " + totalDamage);
        }
        totalDamage = CheckAmor(entityStats, totalDamage);
        //characterStats.TakeDamage(totalDamage);
        DoMagicDamage(entityStats);
    }

    private float CheckAmor(EntityStats entityStats, float totalDamage)
    {
        totalDamage -= entityStats.armor.GetValue();
        return Mathf.Clamp(totalDamage, 0, float.MaxValue);
    }
    public virtual void DoMagicDamage(EntityStats entityStats)
    {
        float fireDamage = this.fireDamage.GetValue();
        float iceDamage = this.iceDamage.GetValue();
        float lightDamage = this.lightDamage.GetValue();
        float bloodDamage = this.bloodDamage.GetValue();
        float toxicDamage = this.toxicDamage.GetValue();

        float totalMagicDamage = fireDamage + iceDamage + lightDamage + Intelligence.GetValue();

        totalMagicDamage -= entityStats.magicResistance.GetValue();
        totalMagicDamage = Mathf.Clamp(totalMagicDamage, 0, int.MaxValue);

        entityStats.TakeDamage(totalMagicDamage);

        if (Mathf.Max(fireDamage, iceDamage, lightDamage, bloodDamage, toxicDamage) <= 0) return;

        bool canUseFire = CheckUseEffect(fireDamage, new float[] { iceDamage, lightDamage, bloodDamage, toxicDamage });
        bool canUseIce = CheckUseEffect(iceDamage, new float[] { fireDamage, lightDamage, bloodDamage, toxicDamage });
        bool canUseLight = CheckUseEffect(lightDamage, new float[] { fireDamage, iceDamage, bloodDamage, toxicDamage });
        bool canUseBlood = CheckUseEffect(bloodDamage, new float[] { fireDamage, iceDamage, lightDamage, toxicDamage });
        bool canUseToxic = CheckUseEffect(toxicDamage, new float[] { fireDamage, iceDamage, lightDamage, bloodDamage });
        Debug.Log(canUseBlood);
        while (!canUseFire && !canUseIce && !canUseLight && !canUseBlood && !canUseToxic)
        {
            if (Random.value < 0.3f && fireDamage > 0)
            {
                canUseFire = true;
                entityStats.ApplyAilement(canUseFire, canUseIce, canUseLight, canUseBlood, canUseToxic);
                Debug.Log("Chaìy");
                return;
            }
            if (Random.value < 0.3f && iceDamage > 0)
            {
                canUseIce = true;
                entityStats.ApplyAilement(canUseFire, canUseIce, canUseLight, canUseBlood, canUseToxic);
                Debug.Log("Laònh");
                return;
            }
            if (Random.value < 0.3f && lightDamage > 0)
            {
                canUseLight = true;
                entityStats.ApplyAilement(canUseFire, canUseIce, canUseLight, canUseBlood, canUseToxic);
                Debug.Log("Tee");
                return;
            }
            if (Random.value < 0.3f && bloodDamage > 0)
            {
                canUseBlood = true;
                entityStats.ApplyAilement(canUseFire, canUseIce, canUseLight, canUseBlood, canUseToxic);
                Debug.Log("chay mau");
                return;
            }
            if (Random.value < 0.3f && toxicDamage > 0)
            {
                canUseToxic = true;
                entityStats.ApplyAilement(canUseFire, canUseIce, canUseLight, canUseBlood,canUseToxic);
                Debug.Log("truìng ðôòc");
                return;
            }
        }
        entityStats.ApplyAilement(canUseFire, canUseIce, canUseLight, canUseBlood, canUseToxic);



    }
    public void ApplyAilement(bool isIgnited, bool isChilled, bool isLight, bool isBloodThorns, bool isToxic)
    {
        if (this.isIgnited || this.isChilled || this.isLight || this.isBloodThorns || this.isToxic) return;

        if (isIgnited)
        {
            this.isIgnited = isIgnited;
            fireTimer = 4f;

        }
        if (isChilled)
        {
            this.isChilled = isChilled;
            iceTimer = 4f;
        }
        if (isLight)
        {
            this.isLight = isLight;
            lightTimer = 4f;
        }
        if (isBloodThorns)
        {
            this.isBloodThorns = isBloodThorns;
            bloodTimer = 4f;
        }
        if (isToxic)
        {
            this.isToxic = isToxic;
            toxicTimer = 4f;
        }
    }
    private bool CheckUseEffect(float ellementMain, float[] ellements)
    {
        bool check = false;
        for (int i = 0; i < ellements.Length; i++)
        {
            if (ellementMain > ellements[i]) check = true;
            else return false;
        }
        return check;
    }

    public virtual void TakeDamage(float damage)
    {
        curentHeatlth -= damage;
    }
    protected virtual void Dead() { }
    private bool CanCrit()
    {
        float totalCritChance = critChance.GetValue();// + cai gi do chua nghi ra
        if (Random.Range(0f, 100f) < totalCritChance)
        {
            return true;
        }
        return false;
    }
    private float CalculateCritDamage(float damage)
    {
        float totalCritDamage = (critPower.GetValue() + Strength.GetValue()) * 0.1f;
        float critDamage = damage * totalCritDamage;
        return Mathf.RoundToInt(critDamage);
    }
}
