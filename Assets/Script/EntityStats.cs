using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    [Header("Stats")]
    public Stats Vitality;// tang mau 
    public Stats Mind;// tang mana
    public Stats Endurance;//tang the luc
    public Stats Strength;// tang suc manh
    public Stats Dexterity;// tang toc do 
    public Stats Intelligence;// tang sat thuong phep thuat
    [Header("Offensive")]
    public Stats damage; // dame theo vu khi mang theo
    public Stats critChance;// ti le chi mang
    public Stats critPower;// do chi mang
    [Header("Defaul Stats")]
    public Stats maxHealth;// mau toi da
    public Stats armor; // chi so giap - giam sat thuong theo chi so giap hien co
    public Stats magicResistance;// chi so sat thuong phep
    [Header("Macgic stats")]
    public Stats fireDamage;// gay chay theo thoi gian khong bo qua chi so phong thu
    public Stats iceDamage;// gay slow ke dich bi dinh hieu ung giam 90% toc do
    public Stats lightDamage;// gay sat thuong rat lon doi voi quai vat va quai vat khong the co loai hieu ung nay ( sat thuong he thanh )
    public Stats bloodDamage;//gay chay mau theo % mau cua nan nhan theo thoi gian bo qua het chi so phong thu 
    public Stats toxicDamage;//gay nhiem doc theo thoi gian bo qua het chi so phong thu
    protected int currentHealth;

    public bool isIgnited;
    public bool isChilled;
    public bool isLight;
    public bool isBloodThorns;
    public bool isToxic;
    private Entity entity = null;
    private FXEntity fxEntity;
    protected Entity isMe;
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
    public float curentHeatlth;


    protected virtual void Start()
    {
        isMe = GetComponentInParent<Entity>();
        ReloadStats();
        fxEntity = GetComponent<FXEntity>();
        
    }

    public void ReloadStats()
    {
        critPower.SetDefaulValue(150);
        curentHeatlth = GetMaxHealth();
    }

    private void Reset()
    {
        isMe = GetComponentInParent<Entity>();
        critPower.SetDefaulValue(150);
        curentHeatlth = GetMaxHealth();
        fxEntity = GetComponent<FXEntity>();
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
        if (entity == null) return;
        if (fireDamageTimer < 0 && isIgnited)
        {
            Debug.Log("Dang hcay");
            float totalDamage = CheckAmor(isMe, entity.entityStats.fireDamage.GetValue());
            TakeDamage(totalDamage);
            fireDamageTimer = fireDamageCoolDown;
            isMe.changeHealth();
        }
        if ( isChilled)
        {
            Debug.Log("Dang lanh");
            isMe.ChangeSpeed(90,10); // per second
            iceDamageTimer = iceDamageCooldown;
        }
        if (lightDamageTimer < 0 && isLight)
        {
            Debug.Log("Dang giat");
            isMe.Stun(lightTimer);
            lightDamageTimer = lightDamageCooldown;
            isMe.changeHealth();
        }
        if (bloodDamageTimer < 0 && isBloodThorns)
        {
            Debug.Log("Dang chay mau + ");
            TakeDamage((CaculatorBlood()/100f)*isMe.entityStats.GetMaxHealth());
            bloodDamageTimer = bloodDamageCooldown;
            isMe.changeHealth();
        }
        if (toxicDamageTimer < 0 && isToxic)
        {
            Debug.Log("dang trung doc");
            TakeDamage(entity.entityStats.toxicDamage.GetValue());
            toxicDamageTimer = toxicDamageCooldown;
            isMe.changeHealth();
        }
        #endregion
    }

    private float CaculatorBlood()
    {
        float damageBlood = entity.entityStats.bloodDamage.GetValue();
        if (damageBlood >= 3)
        {
            Debug.Log("mau: "+damageBlood);
            return 3;
        }
        else
        {
        return damageBlood;
        }
    }

    public virtual void DoDamage(Entity entity)
    {
        this.entity = entity;
        Debug.Log("Dang chay mau + "+this.entity);
        float totalDamage = damage.GetValue() + Strength.GetValue();
        if (CanCrit())
        {
            // x saìt thýõng õÒ ðây
            totalDamage = CalculateCritDamage(totalDamage);
            Debug.Log("1 " + totalDamage);
        }
        totalDamage = CheckAmor(entity, totalDamage);
        entity.entityStats.TakeDamage(totalDamage);
        DoMagicDamage(entity);
    }

    private float CheckAmor(Entity entity, float totalDamage)
    {
        totalDamage -=entity.entityStats.armor.GetValue();
        return Mathf.Clamp(totalDamage, 0, float.MaxValue);
    }
    public virtual void DoMagicDamage(Entity entityStats)
    {
        float fireDamage = this.fireDamage.GetValue();
        float iceDamage = this.iceDamage.GetValue();
        float lightDamage = this.lightDamage.GetValue();
        float bloodDamage = this.bloodDamage.GetValue();
        float toxicDamage = this.toxicDamage.GetValue();

        float totalMagicDamage = fireDamage + iceDamage + lightDamage + Intelligence.GetValue();

        totalMagicDamage -= entity.entityStats.magicResistance.GetValue();
        totalMagicDamage = Mathf.Clamp(totalMagicDamage, 0, int.MaxValue);

        entity.entityStats.TakeDamage(totalMagicDamage);

        if (Mathf.Max(fireDamage, iceDamage, lightDamage, bloodDamage, toxicDamage) <= 0) return;
        bool canUseFire = CheckUseEffect(fireDamage, new float[] { iceDamage, lightDamage, bloodDamage, toxicDamage });
        bool canUseIce = CheckUseEffect(iceDamage, new float[] { fireDamage, lightDamage, bloodDamage, toxicDamage });
        bool canUseLight = CheckUseEffect(lightDamage, new float[] { fireDamage, iceDamage, bloodDamage, toxicDamage });
        bool canUseBlood = CheckUseEffect(bloodDamage, new float[] { fireDamage, iceDamage, lightDamage, toxicDamage });
        bool canUseToxic = CheckUseEffect(toxicDamage, new float[] { fireDamage, iceDamage, lightDamage, bloodDamage });
        while (!canUseFire && !canUseIce && !canUseLight && !canUseBlood && !canUseToxic)
        {
            if (Random.value < 0.3f && fireDamage > 0)
            {
                canUseFire = true;
               entity.entityStats.ApplyAilement(canUseFire, canUseIce, canUseLight, canUseBlood, canUseToxic);
                Debug.Log("Chaìy");
                return;
            }
            if (Random.value < 0.3f && iceDamage > 0)
            {
                canUseIce = true;
                entity.entityStats.ApplyAilement(canUseFire, canUseIce, canUseLight, canUseBlood, canUseToxic);
                Debug.Log("Laònh");
                return;
            }
            if (Random.value < 0.3f && lightDamage > 0)
            {
                canUseLight = true;
                entity.entityStats.ApplyAilement(canUseFire, canUseIce, canUseLight, canUseBlood, canUseToxic);
                Debug.Log("Tee");
                return;
            }
            if (Random.value < 0.3f && bloodDamage > 0)
            {
                canUseBlood = true;
                entity.entityStats.ApplyAilement(canUseFire, canUseIce, canUseLight, canUseBlood, canUseToxic);
                Debug.Log("chay mau");
                return;
            }
            if (Random.value < 0.3f && toxicDamage > 0)
            {
                canUseToxic = true;
                entity.entityStats.ApplyAilement(canUseFire, canUseIce, canUseLight, canUseBlood,canUseToxic);
                Debug.Log("truìng ðôòc");
                return;
            }
        }
        entity.entityStats.ApplyAilement(canUseFire, canUseIce, canUseLight, canUseBlood, canUseToxic);
    }
    public void ApplyAilement(bool isIgnited, bool isChilled, bool isLight, bool isBloodThorns, bool isToxic)
    {
        if (!fxEntity.gameObject.activeInHierarchy||this.isIgnited || this.isChilled || this.isLight || this.isBloodThorns || this.isToxic) return;

        if (isIgnited)
        {
            this.isIgnited = isIgnited;
            fireTimer = 4f;
            fxEntity.FireFXFor(fireTimer);
        }
        if (isChilled)
        {
            this.isChilled = isChilled;
            iceTimer = 10f;
            fxEntity.IceFXFor(iceTimer);
        }
        if (isLight)
        {
            this.isLight = isLight;
            lightTimer = 4f;
            fxEntity.LightFXFor(lightTimer);
        }
        if (isBloodThorns)
        {
            this.isBloodThorns = isBloodThorns;
            bloodTimer = 10f;
            fxEntity.BleedtFXFor(bloodTimer);
        }
        if (isToxic)
        {
            this.isToxic = isToxic;
            toxicTimer = 10f;
            fxEntity.ToxictFXFor(toxicTimer);
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

    public float GetMaxHealth() => maxHealth.GetValue() + Vitality.GetValue() * 5;
    public void SetEnemy(Entity enemy)
    {
        entity = enemy;
    }
}
