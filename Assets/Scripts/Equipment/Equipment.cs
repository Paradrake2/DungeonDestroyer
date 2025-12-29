using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Armor,
    Accessory
}

public enum EquipmentRarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

public enum EquipmentSlot
{
    Head,
    Chest,
    Legs,
    Weapon,
    Accessory
}


[CreateAssetMenu(fileName = "Equipment", menuName = "Scriptable Objects/Equipment")]
public class Equipment : ScriptableObject
{
    public EquipmentType equipmentType;
    public EquipmentSlot equipmentSlot;
    public EquipmentRarity equipmentRarity;
    public string equipmentName;
    public Sprite icon;
    public int modifierNumber; // Number of modifiers equipment starts with
    public List<EquipmentModifier> modifiers = new List<EquipmentModifier>(); // used modifiers
    public List<PlayerStatHolder> baseStats = new List<PlayerStatHolder>();
    public List<EquipmentModifier> possibleModifiers = new List<EquipmentModifier>(); // possible modifiers to roll from
    public float modifierMultiplier = 1f; // This * playerLevel determines strength of modifiers
    public void SetModifierNumber(int number)
    {
        modifierNumber = number;
    }
    public void SetModifierMultiplier(float multiplier)
    {
        modifierMultiplier = multiplier;
    }
    public int GetModifierNumber() // Used when generating equipment with random modifiers
    {
        return modifierNumber;
    }
    public void AddModifier(EquipmentModifier modifier)
    {
        modifiers.Add(modifier);
    }
    public List<PlayerStatHolder> GetBaseStats()
    {
        return baseStats;
    }
}
