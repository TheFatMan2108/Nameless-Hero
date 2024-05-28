using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats 
{
  [SerializeField]  private float baseValue;
    public List<float> modifiers;

    public float GetValue()
    {
        float finalDamage = baseValue;
        foreach (float modifier in modifiers)
        {
            finalDamage += modifier;
        }
        return finalDamage;
    }
    public void SetDefaulValue(float value) =>baseValue = value;
    public void AddModifier(float modifier) => modifiers.Add(modifier);
    public void RemoveModifier(float modifier) => modifiers.Remove(modifier);

}
