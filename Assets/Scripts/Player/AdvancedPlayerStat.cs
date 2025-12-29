using UnityEngine;

[CreateAssetMenu(fileName = "AdvancedPlayerStat", menuName = "Scriptable Objects/AdvancedPlayerStat")]
public class AdvancedPlayerStat : ScriptableObject
{
    public string statName;
    public Sprite icon;
    public string description;
    public float baseValue;
    public float currentValue;
    public string GetName()
    {
        return statName;
    }
    public float GetBaseValue()
    {
        return baseValue;
    }
    public float GetCurrentValue()
    {
        return currentValue;
    }
    public void SetCurrentValue(float value)
    {
        currentValue = value;
    }
    public void ResetCurrentValue()
    {
        currentValue = baseValue;
    }
    public void ModifyCurrentValue(float amount)
    {
        currentValue += amount;
    }
}
